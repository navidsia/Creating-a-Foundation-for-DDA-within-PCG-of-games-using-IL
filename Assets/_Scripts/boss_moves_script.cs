using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_moves_script : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab; // Reference to the projectile prefab
    [SerializeField] float spawnInterval = 1f;    // Time interval between spawns
    [SerializeField] float minX = -8f;            // Minimum x position (adjust according to your screen width)
    [SerializeField] float maxX = 8f;             // Maximum x position (adjust according to your screen width)
    [SerializeField] float spawnY = 5f;           // Y position to spawn bullets just below the top of the screen
    [SerializeField] int bulletDamage = 1;       // Damage dealt by each bullet

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBullet), spawnInterval, spawnInterval);
    }

    void SpawnBullet()
    {
        // Generate a random x position within the screen bounds
        float randomX = Random.Range(minX, maxX);

        // Set the spawn position
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        // Instantiate the projectile at the spawn position
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Get the Projectile component from the instantiated object and shoot it downwards
        var projectileScript = newProjectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Shoot(Vector2.down, bulletDamage); // Shoot the projectile downwards with specified damage
        }
    }
}
