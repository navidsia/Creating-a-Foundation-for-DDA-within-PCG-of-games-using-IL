using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using Unity.MLAgents.Policies;

public class ResultSaver : MonoBehaviour
{
    private float sceneStartTime;
    private string filePath;
    private string player_winner = ""; // 0 for enemy won and 1 for player won

    [SerializeField] Enemy enemy;
    [SerializeField] CharacterController characterController;
    [SerializeField] CharacterAgent characterAgent;
    //[SerializeField] bool saving;
    [SerializeField] Unity.MLAgents.Policies.BehaviorParameters behaviorParameters;
    [SerializeField] int iteration = 1;
    [SerializeField] int max_iteration = 2;
    [SerializeField] BackgroundManager backgroundManager;
    [SerializeField] boss_moves_script boss_moves;
    [SerializeField] dynamic_difficulty_adjustment_script dda_script;
    [SerializeField] bool follow_scenario = true;
    [SerializeField] bool scenario_end = false;
    [SerializeField] SpriteRenderer Black_Screen;
    [SerializeField] bool training = false;
    [SerializeField] List<NNModel> models;
    [SerializeField] int current_model;
    [SerializeField] BehaviorParameters charachter_model;
    [SerializeField] bool is_main = false;
    void Start()
    {
        current_model = 0;
        Application.runInBackground = true;
        // Record the scene's start time
        sceneStartTime = Time.time;

        // Set the file path (adjust the path as needed)
        filePath = Application.dataPath + "/SceneResults.csv";

        // Check if file exists, create it with a header if not
        //if (!File.Exists(filePath))
        //{
        //    string headers = $"{"model name or player"},{"time"},{"player hp"},{"enemy hp"},{"player winner"}";
        //    File.WriteAllText(filePath, headers + "\n"); // Add header
        //}

        if (follow_scenario)
        {
            boss_moves.scenario = iteration;
            enemy.scenario = iteration;
            characterController.scenario = iteration;
            reload_scene();
        }
    }

    private void Update()
    {
        //if (elapsedTime > 60f)
        //{
        //    SaveSceneTime();
        //}
        if (scenario_end)
        {
            characterAgent.SetCan_Move(false);
            enemy.SetCanPatrol(false);
            characterController.SetisHittable(false);
            characterController.can_update = false;
            boss_moves.SetCanUpdate(false);

            // Start fading to black

        }
    }

    private IEnumerator HandleBlackScreenTransparency(float targetAlpha, float duration)
    {
        if (!training)
        {
            float startAlpha = Black_Screen.color.a;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
                Black_Screen.color = new Color(Black_Screen.color.r, Black_Screen.color.g, Black_Screen.color.b, newAlpha);
                yield return null;
            }

            // Ensure final alpha is set
            Black_Screen.color = new Color(Black_Screen.color.r, Black_Screen.color.g, Black_Screen.color.b, targetAlpha);
        }

    }

    public void SaveSceneTime()
    {
        
        if (iteration <= max_iteration)
        {
            scenario_end = true;
            StartCoroutine(HandleBlackScreenTransparency(1f, 5f));
            //if (saving)
            //{
            string nnModelName = behaviorParameters.Model == null ? "player" : behaviorParameters.Model.name;
            int playerHP = characterController.Return_HP_Player();
            int enemyHP = enemy.Return_HP_Enemy();
            float sceneDuration = Time.time - sceneStartTime; // Calculate time elapsed


            int move1 = boss_moves.selected_indexes[0];
            int difficulty1 = boss_moves.selected_difficulties[0];

            int move2 = boss_moves.selected_indexes[1];
            int difficulty2 = boss_moves.selected_difficulties[1];

            int move3 = boss_moves.selected_indexes[2];
            int difficulty3 = boss_moves.selected_difficulties[2];

            int ismainint = 0;
            if(is_main) ismainint = 1;

            if (playerHP == 0) player_winner = "0";
            else if (enemyHP == 0) player_winner = "1";
            else player_winner = "";

            string resultData = $"{nnModelName},{sceneDuration},{playerHP},{enemyHP},{player_winner},{move1},{move2},{move3},{difficulty1},{difficulty2},{difficulty3},{ismainint}";

            // Append the time to the file
            //File.AppendAllText(filePath, resultData + "\n");
            dda_script.save_results(resultData);


            sceneStartTime = Time.time;
            //}

            iteration++;
            if (iteration > max_iteration)
            {
                current_model++;
                if (current_model >= models.Count)
                {
                    EditorApplication.isPlaying = false;
                }
                else
                {
                    charachter_model.Model = models[current_model];
                    iteration = 0;
                    if (follow_scenario)
                    {
                        boss_moves.scenario = iteration;
                        enemy.scenario = iteration;
                        characterController.scenario = iteration;
                    }
                   // StartCoroutine(ReloadSceneWithDelay());


                }
            }
             if (follow_scenario)
            {
                boss_moves.scenario = iteration;
                enemy.scenario = iteration;
                characterController.scenario = iteration;
            }
                

            StartCoroutine(ReloadSceneWithDelay());
        }

    }

    private IEnumerator ReloadSceneWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        reload_scene();
    }

    public void reload_scene()
    {

        scenario_end = false;
        StartCoroutine(HandleBlackScreenTransparency(0f, 1f));
        characterAgent.Start_function();
        enemy.Start_function();
        characterController.Start_function();
        boss_moves.Start_function();
        backgroundManager.Start_function();
        StartCoroutine(start_movement());
        // SceneManager.LoadScene(1);
    }

    private IEnumerator start_movement()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 5 seconds
        movement_begin();
    }
    public void movement_begin()
    {
        characterAgent.SetCan_Move(true);
        enemy.SetCanPatrol(true);
        characterController.SetisHittable(true);
        characterController.can_update=true;
        boss_moves.SetCanUpdate(true);
    }
}
