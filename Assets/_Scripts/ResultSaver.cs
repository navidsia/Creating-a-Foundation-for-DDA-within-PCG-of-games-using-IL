using System.IO;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSaver : MonoBehaviour
{
    private float sceneStartTime;
    private string filePath;
    private int player_winner = 0; // 0 for enemy won and 1 for player won

    [SerializeField] Enemy enemy;
    [SerializeField] CharacterController characterController;
    [SerializeField] CharacterAgent characterAgent;
    [SerializeField] bool saving;
    [SerializeField] Unity.MLAgents.Policies.BehaviorParameters behaviorParameters;
    [SerializeField] int iteration =1;
    [SerializeField] int max_iteration =2;
    [SerializeField] BackgroundManager backgroundManager;
    [SerializeField] boss_moves_script boss_moves;
    [SerializeField] bool follow_scenario = true;
    void Start()
    {
        // Record the scene's start time
        sceneStartTime = Time.time;

        // Set the file path (adjust the path as needed)
        filePath = Application.dataPath + "/SceneResults.csv";

        // Determine NN model name or default to "player"


        // Check if file exists, create it with a header if not
        if (!File.Exists(filePath))
        {
            string headers = $"{"model name or player"},{"time"},{"player hp"},{"enemy hp"},{"player winner"}";
            File.WriteAllText(filePath, headers + "\n"); // Add header
        }

        if (follow_scenario)
        {
            boss_moves.scenario = iteration;
            reload_scene();
        }
    }

    private void Update()
    {
    }

    /// <summary>
    /// Saves how long the scene has taken into the Excel file (CSV format).
    /// </summary>
    public void SaveSceneTime()
    {
        if (iteration <= max_iteration)
        {


            if (saving)
            {
                string nnModelName = behaviorParameters.Model == null ? "player" : behaviorParameters.Model.name;
                int playerHP = characterController.Return_HP_Player();
                int enemyHP = enemy.Return_HP_Enemy();
                float sceneDuration = Time.time - sceneStartTime; // Calculate time elapsed
                if (playerHP > enemyHP) player_winner = 1; else player_winner = 0;

                string resultData = $"{nnModelName},{sceneDuration},{playerHP},{enemyHP},{player_winner}";

                // Append the time to the file
                File.AppendAllText(filePath, resultData + "\n");

            }

                iteration = iteration + 1;
            if (iteration > max_iteration)
            {
                EditorApplication.isPlaying = false;
            }
            boss_moves.scenario = iteration;
            reload_scene();
        }

    }

    public void reload_scene()
    {
        characterAgent.Start_function();
        enemy.Start_function();
        characterController.Start_function();
        boss_moves.Start_function();
        backgroundManager.Start_function();
       // SceneManager.LoadScene(1);
    }


}
