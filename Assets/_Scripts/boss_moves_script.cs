using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_moves_script : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;  // Reference to the projectile prefab
    [SerializeField] float rain_difficulty = 1;
    [SerializeField] float rain_spawnInterval = 1f;     // Time interval between spawns
    [SerializeField] float rain_minX = -8f;             // Minimum x position (adjust according to your screen width)
    [SerializeField] float rain_maxX = 8f;              // Maximum x position (adjust according to your screen width)
    [SerializeField] float rain_minY = -4.5f;           // Minimum y position (adjust according to your screen height)
    [SerializeField] float rain_maxY = 4.5f;            // Maximum y position (adjust according to your screen height)

    // Separate duration fields for each move
    [SerializeField] float rain_Top_Duration = 4.5f;
    [SerializeField] float rain_Left_Duration = 4.5f;
    [SerializeField] float rain_Right_Duration = 4.5f;
    [SerializeField] float rain_Bottom_Duration = 4.5f;

    // Separate rest time fields for each move
    [SerializeField] float rain_Top_RestTime = 2f;
    [SerializeField] float rain_Left_RestTime = 2f;
    [SerializeField] float rain_Right_RestTime = 2f;
    [SerializeField] float rain_Bottom_RestTime = 2f;

    // Separate speed fields for each move
    [SerializeField] float rain_Top_Speed = 5f;
    [SerializeField] float rain_Left_Speed = 5f;
    [SerializeField] float rain_Right_Speed = 5f;
    [SerializeField] float rain_Bottom_Speed = 5f;

    [SerializeField] int rain_bulletDamage = 1;         // Damage dealt by each bullet
    [SerializeField] GameObject enemy;             // Reference to the enemy GameObject

    private List<System.Action> bossMoves = new List<System.Action>();  // List of selected boss moves
    private List<float> moveDurations = new List<float>();              // List of corresponding move durations
    private List<float> restTimes = new List<float>();                  // List of corresponding rest times
    private List<float> moveSpeeds = new List<float>();                 // List of corresponding move speeds
    private int currentMoveIndex = 0;              // Current boss move index
    private float moveTimer = 0f;                  // Timer to track how long the current move has been running
    private float spawnTimer = 0f;                 // Timer to track the time between bullet spawns
    private bool isWaitingForNextMove = false;     // Flag to check if waiting for the next move

    private void Start()
    {
        rain_difficulty = Random.Range(1, 5);
        rain_spawnInterval = 0.5f - rain_difficulty * 0.1f;

        // Initialize the list of all possible boss moves and their properties
        List<System.Action> allMoves = new List<System.Action>
        {
            rain_Top,
            rain_Left,
            rain_Right,
            rain_Bottom
        };

        List<float> allDurations = new List<float>
        {
            rain_Top_Duration,
            rain_Left_Duration,
            rain_Right_Duration,
            rain_Bottom_Duration
        };

        List<float> allRestTimes = new List<float>
        {
            rain_Top_RestTime,
            rain_Left_RestTime,
            rain_Right_RestTime,
            rain_Bottom_RestTime
        };

        List<float> allSpeeds = new List<float>
        {
            rain_Top_Speed,
            rain_Left_Speed,
            rain_Right_Speed,
            rain_Bottom_Speed
        };

        // Randomly select 3 unique boss moves, their durations, rest times, and speeds
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, allMoves.Count);
            bossMoves.Add(allMoves[randomIndex]);
            moveDurations.Add(allDurations[randomIndex]);
            restTimes.Add(allRestTimes[randomIndex]);
            moveSpeeds.Add(allSpeeds[randomIndex]);

            allMoves.RemoveAt(randomIndex);  // Remove the chosen move to avoid duplicates
            allDurations.RemoveAt(randomIndex);  // Remove the corresponding duration to keep them in sync
            allRestTimes.RemoveAt(randomIndex);  // Remove the corresponding rest time to keep them in sync
            allSpeeds.RemoveAt(randomIndex);  // Remove the corresponding speed to keep them in sync
        }
    }

    private void Update()
    {
        // Check if the enemy still exists
        if (enemy == null)
        {
            return; // Stop executing if the enemy is destroyed
        }

        // If waiting for the next move, don't proceed until the delay is over
        if (isWaitingForNextMove)
        {
            return;
        }

        // Update the move timer
        moveTimer += Time.deltaTime;

        // Execute the current boss move for its corresponding duration
        if (moveTimer < moveDurations[currentMoveIndex])
        {
            // Update the spawn timer
            spawnTimer += Time.deltaTime;

            // Check if it's time to spawn the next bullet
            if (spawnTimer >= rain_spawnInterval)
            {
                bossMoves[currentMoveIndex]();  // Execute the current boss move
                spawnTimer = 0f;  // Reset the spawn timer
            }
        }
        else
        {
            // Move to the next boss move with a custom rest time
            StartCoroutine(WaitForNextMove(restTimes[currentMoveIndex]));
        }
    }

    IEnumerator WaitForNextMove(float restTime)
    {
        isWaitingForNextMove = true;
        yield return new WaitForSeconds(restTime);  // Wait for the specified rest time
        moveTimer = 0f;
        currentMoveIndex++;

        // If all moves have been executed, restart from the first move
        if (currentMoveIndex >= bossMoves.Count)
        {
            currentMoveIndex = 0;
        }

        isWaitingForNextMove = false;
    }

    void rain_Top()
    {
        // Generate a random x position within the screen bounds
        float randomX = Random.Range(rain_minX, rain_maxX);
        Vector2 spawnPosition = new Vector2(randomX, rain_maxY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootProjectile(spawnPosition, Vector2.down, moveSpeeds[currentMoveIndex]);
    }

    void rain_Left()
    {
        // Generate a random y position within the screen bounds
        float randomY = Random.Range(rain_minY, rain_maxY);
        Vector2 spawnPosition = new Vector2(rain_minX, randomY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootProjectile(spawnPosition, Vector2.right, moveSpeeds[currentMoveIndex]);
    }

    void rain_Right()
    {
        // Generate a random y position within the screen bounds
        float randomY = Random.Range(rain_minY, rain_maxY);
        Vector2 spawnPosition = new Vector2(rain_maxX, randomY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootProjectile(spawnPosition, Vector2.left, moveSpeeds[currentMoveIndex]);
    }

    void rain_Bottom()
    {
        // Generate a random x position within the screen bounds
        float randomX = Random.Range(rain_minX, rain_maxX);
        Vector2 spawnPosition = new Vector2(randomX, rain_minY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootProjectile(spawnPosition, Vector2.up, moveSpeeds[currentMoveIndex]);
    }

    void SpawnAndShootProjectile(Vector2 spawnPosition, Vector2 direction, float speed)
    {
        // Instantiate the projectile at the spawn position
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Get the Projectile component from the instantiated object and shoot it with the given speed
        var projectileScript = newProjectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Shoot(direction, speed, rain_bulletDamage); // Shoot the projectile in the specified direction with the specified speed
        }
    }
}
