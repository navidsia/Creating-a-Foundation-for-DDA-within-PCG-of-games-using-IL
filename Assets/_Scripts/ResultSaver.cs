using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    [SerializeField] int iteration = 1;
    [SerializeField] int max_iteration = 2;
    [SerializeField] BackgroundManager backgroundManager;
    [SerializeField] boss_moves_script boss_moves;
    [SerializeField] bool follow_scenario = true;
    [SerializeField] bool scenario_end = false;
    [SerializeField] SpriteRenderer Black_Screen;

    void Start()
    {
        // Record the scene's start time
        sceneStartTime = Time.time;

        // Set the file path (adjust the path as needed)
        filePath = Application.dataPath + "/SceneResults.csv";

        // Check if file exists, create it with a header if not
        if (!File.Exists(filePath))
        {
            string headers = $"{"model name or player"},{"time"},{"player hp"},{"enemy hp"},{"player winner"}";
            File.WriteAllText(filePath, headers + "\n"); // Add header
        }

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

    public void SaveSceneTime()
    {
        if (iteration <= max_iteration)
        {
            scenario_end = true;
            StartCoroutine(HandleBlackScreenTransparency(1f, 5f));
            if (saving)
            {
                string nnModelName = behaviorParameters.Model == null ? "player" : behaviorParameters.Model.name;
                int playerHP = characterController.Return_HP_Player();
                int enemyHP = enemy.Return_HP_Enemy();
                float sceneDuration = Time.time - sceneStartTime; // Calculate time elapsed
                player_winner = playerHP > enemyHP ? 1 : 0;

                string resultData = $"{nnModelName},{sceneDuration},{playerHP},{enemyHP},{player_winner}";

                // Append the time to the file
                File.AppendAllText(filePath, resultData + "\n");
            }

            iteration++;
            if (iteration > max_iteration)
            {
                EditorApplication.isPlaying = false;
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
