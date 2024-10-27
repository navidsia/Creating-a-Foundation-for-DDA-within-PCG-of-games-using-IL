using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies; // List of enemy prefabs
    private GameObject currentEnemy; // Reference to the instantiated enemy

    void Start()
    {
        SpawnRandomEnemy();
    }

    // Function to spawn a random enemy
    private void SpawnRandomEnemy()
    {
        if (enemies.Count > 0)
        {
            // Pick a random index
            int randomIndex = Random.Range(0, enemies.Count);

            // Instantiate the enemy prefab at a specific position (can change Vector3.zero)
            currentEnemy = Instantiate(enemies[randomIndex], Vector3.zero, Quaternion.identity);
            Debug.Log("Spawned Enemy: " + currentEnemy.name);
        }
        else
        {
            Debug.LogError("No enemy prefabs in the list!");
        }
    }

    // Getter method to access the spawned enemy
    public GameObject GetCurrentEnemy()
    {
        return currentEnemy;
    }
}
