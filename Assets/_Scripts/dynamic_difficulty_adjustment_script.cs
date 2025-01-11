using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using Unity.MLAgents.Policies; // Ensure you include this namespace
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class dynamic_difficulty_adjustment_script : MonoBehaviour
{
    [SerializeField] GameObject Main_Env;
    [SerializeField] List<GameObject> enviorments;
    [SerializeField] bool using_models = false;
    [SerializeField] int current_model;
    [SerializeField] List<NNModel> models;
    [SerializeField] bool saving_main=false;
    [SerializeField] bool saving_models=false;
    [SerializeField] bool saving_training = false;
    [SerializeField] public int number_of_moves = 3;
    [SerializeField] List<string> model_results = new List<string>();
    public string filePath = Application.dataPath + "/SceneResults.csv";
    [SerializeField] bool dynamic_adjustment = false;
    [SerializeField] bool training = true;
    [SerializeField] bool constant_levels = true;
    [SerializeField] int current_constant_level=0;
    [SerializeField] int constant_max_level = 10;
    List<List<int>> constant_moves = new List<List<int>>();
    List<List<int>> constant_difficulties = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        constant_difficulties = new List<List<int>>
        {
            new List<int> { 1, 3, 4 },
            new List<int> { 2, 2, 1 },
            new List<int> { 4, 1, 3 },
            new List<int> { 3, 4, 2 },
            new List<int> { 1, 1, 4 },
            new List<int> { 2, 3, 3 },
            new List<int> { 4, 4, 1 },
            new List<int> { 3, 2, 2 },
            new List<int> { 1, 4, 3 },
            new List<int> { 2, 1, 4 }
        };

        constant_moves = new List<List<int>>
        {

            new List<int> { 18, 5, 23 },
            new List<int> { 2, 14, 27 },
            new List<int> { 9, 20, 1 },
            new List<int> { 6, 22, 13 },
            new List<int> { 19, 12, 4 },
            new List<int> { 3, 28, 7 },
            new List<int> { 16, 25, 10 },
            new List<int> { 29, 8, 0 },
            new List<int> { 17, 11, 21 },
            new List<int> { 26, 24, 15 }

            // new List<int> { 9, 10, 11 },
            //new List<int> { 12, 13, 14 },
            //new List<int> { 15, 16, 17 },
            //new List<int> { 18, 19, 20 },
            //new List<int> { 21, 22, 23 },
            //new List<int> { 24, 25, 26 },
            //new List<int> { 27, 28, 29 },
            //new List<int> { 0, 1, 2 },
            //new List<int> { 3, 4, 5 },
            //new List<int> { 6, 7, 8 }




        };

        if (!File.Exists(filePath))
        {


            string headers = $"{"model name or player"},{"time"},{"player hp"},{"enemy hp"},{"player winner"},{"move1"},{"move2"},{"move3"},{"difficulty1"},{"difficulty2"},{"difficulty3"}";
            File.WriteAllText(filePath, headers + "\n"); // Add header
        }
        else
        {
            string headers = $"{"model name or player"},{"time"},{"player hp"},{"enemy hp"},{"player winner"},{"move1"},{"move2"},{"move3"},{"difficulty1"},{"difficulty2"},{"difficulty3"}";
            File.AppendAllText(filePath, headers + "\n"); // Add header
        }


        if (models.Count > 0)
        {
            foreach (GameObject env in enviorments)
            {
                // Find the Character object within the environment
                GameObject character = env.transform.Find("Character")?.gameObject;

                if (character != null)
                {
                    // Get the BehaviorParameters component
                    BehaviorParameters behaviorParams = character.GetComponent<BehaviorParameters>();

                    if (behaviorParams != null)
                    {
                        // Set the model to models[0]
                        behaviorParams.Model = models[0];
                    }
                    else
                    {
                        Debug.LogWarning("BehaviorParameters not found on Character in " + env.name);
                    }
                }
                else
                {
                    Debug.LogWarning("Character object not found in " + env.name);
                }
            }
        }


        if (!dynamic_adjustment)
        {
            GameObject bossMovesObject = Main_Env.transform.Find("Boss_moves").gameObject;
            var bossMovesScript = bossMovesObject.GetComponent<boss_moves_script>();

            if (bossMovesScript != null)
            {
                bossMovesScript.selected_indexes = constant_moves[current_constant_level];
                bossMovesScript.selected_difficulties = constant_difficulties[current_constant_level];
                current_constant_level++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator next_level(string resultData)
    {

        if (!training)
        {
            foreach (GameObject env in enviorments)
            {
                // Find the Character object within the environment
                GameObject ResultSaverObject = env.transform.Find("result saver").gameObject;
                var ResultSaverScript = ResultSaverObject.GetComponent<ResultSaver>();

                if (ResultSaverScript != null)
                {
                    ResultSaverScript.SaveSceneTime();
                }
            }



            yield return new WaitForSeconds(0.2f);
            if (dynamic_adjustment)
            {


                int closest_match = 0;
                int min_abs_hp_difference = 1000;
                int i = 0;
                foreach (string model_result in model_results)
                {
                    string[] model_result_parts = model_result.Split(',');

                    int current_abs_hp_difference = Math.Abs(int.Parse(model_result_parts[2]) - int.Parse(model_result_parts[3]));
                    if (current_abs_hp_difference < min_abs_hp_difference)
                    {
                        min_abs_hp_difference = current_abs_hp_difference;
                        closest_match = i;
                    }
                    i++;
                }

                GameObject bossMovesObject = Main_Env.transform.Find("Boss_moves").gameObject;
                var bossMovesScript = bossMovesObject.GetComponent<boss_moves_script>();

                if (bossMovesScript != null)
                {
                    // Access and log the current value of number_of_moves
                    int currentNumberOfMoves = bossMovesScript.number_of_moves;

                    List<int> selected_indexes = new List<int>();
                    List<int> selected_difficulties = new List<int>();

                    // Change the values of selected_indexes and selected_difficulties

                    string[] model_closest_match_parts = model_results[closest_match].Split(',');
                    selected_indexes.Add(int.Parse(model_closest_match_parts[5]));
                    selected_indexes.Add(int.Parse(model_closest_match_parts[6]));
                    selected_indexes.Add(int.Parse(model_closest_match_parts[7]));


                    selected_difficulties.Add(int.Parse(model_closest_match_parts[8]));
                    selected_difficulties.Add(int.Parse(model_closest_match_parts[9]));
                    selected_difficulties.Add(int.Parse(model_closest_match_parts[10]));

                    bossMovesScript.selected_indexes = selected_indexes;
                    bossMovesScript.selected_difficulties = selected_difficulties;

                }

                model_results = new List<string>();
                string headers = $"{"model name or player"},{"time"},{"player hp"},{"enemy hp"},{"player winner"},{"move1"},{"move2"},{"move3"},{"difficulty1"},{"difficulty2"},{"difficulty3"}";
                File.AppendAllText(filePath, headers + "\n");

            }
            else
            {
                if (current_constant_level < constant_max_level - 1)
                {
                    GameObject bossMovesObject = Main_Env.transform.Find("Boss_moves").gameObject;
                    var bossMovesScript = bossMovesObject.GetComponent<boss_moves_script>();

                    if (bossMovesScript != null)
                    {
                        bossMovesScript.selected_indexes = constant_moves[current_constant_level];
                        bossMovesScript.selected_difficulties = constant_difficulties[current_constant_level];
                        current_constant_level++;
                    }
                }
                else
                {
                    EditorApplication.isPlaying = false;
                }
            }
        }
       

    }

        public void save_results(string resultData)
    {
        string[] resultParts = resultData.Split(',');

        string nnModelName = resultParts[0];
        bool train_situation = false;

        if(saving_training && training)
        {
            train_situation = true;
        }
        else if(!saving_training && !training)
        {
            train_situation = true;
        }




        if (train_situation)
        {

        
        if (nnModelName == "player")
        {
            if (saving_main)
            {
                File.AppendAllText(filePath, resultData + "\n");
            }
            StartCoroutine(next_level(resultData));
              


        }
        else if (nnModelName != "player" )
        {
            model_results.Add(resultData);
            if (saving_models)
            {
                File.AppendAllText(filePath, resultData + "\n");
            }
            
        }

        }
    }

}
