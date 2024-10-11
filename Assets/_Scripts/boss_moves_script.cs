using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_moves_script : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject BullPrefab;

    [SerializeField] bool canpatrol = true;
    [SerializeField] Vector2 characterPosition;

    [SerializeField] float rain_Top_difficulty = 1;
    [SerializeField] float rain_Top_Duration = 4.5f;
    [SerializeField] float rain_Top_Spawn_interval = 4.5f;
    [SerializeField] float rain_Top_RestTime = 2f;
    [SerializeField] float rain_Top_Speed = 5f;
    [SerializeField] int rain_Top_bulletDamage = 1;

    [SerializeField] float rain_Left_difficulty = 1;
    [SerializeField] float rain_Left_Duration = 4.5f;
    [SerializeField] float rain_Left_Spawn_interval = 4.5f;
    [SerializeField] float rain_Left_RestTime = 2f;
    [SerializeField] float rain_Left_Speed = 5f;
    [SerializeField] int rain_Left_bulletDamage = 1;


    [SerializeField] float rain_Right_difficulty = 1;
    [SerializeField] float rain_Right_Duration = 4.5f;
    [SerializeField] float rain_Right_Spawn_interval = 4.5f;
    [SerializeField] float rain_Right_RestTime = 2f;
    [SerializeField] float rain_Right_Speed = 5f;
    [SerializeField] int rain_Right_bulletDamage = 1;

    [SerializeField] float bull_Left_difficulty = 1;
    [SerializeField] float bull_Left_Duration = 1f;
    [SerializeField] float bull_Left_Spawn_interval = 0.7f;
    [SerializeField] float bull_Left_RestTime = 4f;
    [SerializeField] float bull_Left_Speed = 5f;
    [SerializeField] int bull_Left_damage = 1;

    [SerializeField] float bull_Right_difficulty = 1;
    [SerializeField] float bull_Right_Duration = 1f;
    [SerializeField] float bull_Right_Spawn_interval = 0.7f;
    [SerializeField] float bull_Right_RestTime = 4f;
    [SerializeField] float bull_Right_Speed = 5f;
    [SerializeField] int bull_Right_damage = 1;


    [SerializeField] int Circle_Difficulty = 1;
    [SerializeField] float Circle_Duration = 1f;
    [SerializeField] float Circle_Spawn_interval = 0.7f;
    [SerializeField] float Circle_RestTime = 4f;
    [SerializeField] float Circle_Speed = 5f;
    [SerializeField] int Circle_damage = 1;

    [SerializeField] int Star_Difficulty = 1;
    [SerializeField] float Star_Duration = 1f;
    [SerializeField] float Star_Spawn_interval = 0.7f;
    [SerializeField] float Star_RestTime = 4f;
    [SerializeField] float Star_Speed = 5f;
    [SerializeField] int Star_damage = 1;

    [SerializeField] int circle_Random_Difficulty = 1;
    [SerializeField] float circle_Random_Duration = 4.5f;
    [SerializeField] float circle_Random_Spawn_interval = 4.5f;
    [SerializeField] float circle_Random_RestTime = 2f;
    [SerializeField] float circle_Random_Speed = 5f;
    [SerializeField] int circle_Random_damage = 1;


    [SerializeField] int circle_Clockwise_Difficulty = 1;
    [SerializeField] float circle_Clockwise_Duration = 0.7f;
    [SerializeField] float circle_Clockwise_Spawn_interval = 0.7f;
    [SerializeField] float circle_Clockwise_RestTime = 4f;
    [SerializeField] float circle_Clockwise_Speed = 5f;
    [SerializeField] int circle_Clockwise_damage = 1;


    [SerializeField] int circle_AntiClockwise_Difficulty = 1;
    [SerializeField] float circle_AntiClockwise_Duration = 0.7f;
    [SerializeField] float circle_AntiClockwise_Spawn_interval = 0.7f;
    [SerializeField] float circle_AntiClockwise_RestTime = 4f;
    [SerializeField] float circle_AntiClockwise_Speed = 5f;
    [SerializeField] int circle_AntiClockwise_damage = 1;


    [SerializeField] int Shotgun_Difficulty = 1;
    [SerializeField] float Shotgun_Duration = 0.7f;
    [SerializeField] float Shotgun_Spawn_interval = 0.7f;
    [SerializeField] float Shotgun_RestTime = 2f;
    [SerializeField] float Shotgun_Speed = 5f;
    [SerializeField] int Shotgun_damage = 1;


    [SerializeField] int Uzi_Difficulty = 1;
    [SerializeField] float Uzi_Duration = 4.5f;
    [SerializeField] float Uzi_Spawn_interval = 4.5f;
    [SerializeField] float Uzi_RestTime = 2f;
    [SerializeField] float Uzi_Speed = 5f;
    [SerializeField] int Uzi_damage = 1;

    [SerializeField] int M4_Difficulty = 1;
    [SerializeField] float M4_Duration = 4.5f;
    [SerializeField] float M4_Spawn_interval = 4.5f;
    [SerializeField] float M4_RestTime = 2f;
    [SerializeField] float M4_Speed = 5f;
    [SerializeField] int M4_damage = 1;

    [SerializeField] int Pump_Shotgun_Difficulty = 1;
    [SerializeField] float Pump_Shotgun_Duration = 2.2f;
    [SerializeField] float Pump_Shotgun_Spawn_interval = 0.7f;
    [SerializeField] float Pump_Shotgun_RestTime = 2f;
    [SerializeField] float Pump_Shotgun_Speed = 5f;
    [SerializeField] int Pump_Shotgun_damage = 1;

    [SerializeField] int Shuriken_Clockwise_Difficulty = 1;
    [SerializeField] float Shuriken_Clockwise_Duration = 0.7f;
    [SerializeField] float Shuriken_Clockwise_Spawn_interval = 0.7f;
    [SerializeField] float Shuriken_Clockwise_RestTime = 4f;
    [SerializeField] float Shuriken_Clockwise_Speed = 5f;
    [SerializeField] int Shuriken_Clockwise_damage = 1;


    [SerializeField] int Shuriken_AntiClockwise_Difficulty = 1;
    [SerializeField] float Shuriken_AntiClockwise_Duration = 0.7f;
    [SerializeField] float Shuriken_AntiClockwise_Spawn_interval = 0.7f;
    [SerializeField] float Shuriken_AntiClockwise_RestTime = 4f;
    [SerializeField] float Shuriken_AntiClockwise_Speed = 5f;
    [SerializeField] int Shuriken_AntiClockwise_damage = 1;


    [SerializeField] int Half_Shuriken_Clockwise_Difficulty = 1;
    [SerializeField] float Half_Shuriken_Clockwise_Duration = 0.7f;
    [SerializeField] float Half_Shuriken_Clockwise_Spawn_interval = 0.7f;
    [SerializeField] float Half_Shuriken_Clockwise_RestTime = 4f;
    [SerializeField] float Half_Shuriken_Clockwise_Speed = 5f;
    [SerializeField] int Half_Shuriken_Clockwise_damage = 1;


    [SerializeField] int Half_Shuriken_AntiClockwise_Difficulty = 1;
    [SerializeField] float Half_Shuriken_AntiClockwise_Duration = 0.7f;
    [SerializeField] float Half_Shuriken_AntiClockwise_Spawn_interval = 0.7f;
    [SerializeField] float Half_Shuriken_AntiClockwise_RestTime = 4f;
    [SerializeField] float Half_Shuriken_AntiClockwise_Speed = 5f;
    [SerializeField] int Half_Shuriken_AntiClockwise_damage = 1;



    [SerializeField] int Half2_Shuriken_Clockwise_Difficulty = 1;
    [SerializeField] float Half2_Shuriken_Clockwise_Duration = 0.7f;
    [SerializeField] float Half2_Shuriken_Clockwise_Spawn_interval = 0.7f;
    [SerializeField] float Half2_Shuriken_Clockwise_RestTime = 4f;
    [SerializeField] float Half2_Shuriken_Clockwise_Speed = 5f;
    [SerializeField] int Half2_Shuriken_Clockwise_damage = 1;


    [SerializeField] int Half2_Shuriken_AntiClockwise_Difficulty = 1;
    [SerializeField] float Half2_Shuriken_AntiClockwise_Duration = 0.7f;
    [SerializeField] float Half2_Shuriken_AntiClockwise_Spawn_interval = 0.7f;
    [SerializeField] float Half2_Shuriken_AntiClockwise_RestTime = 4f;
    [SerializeField] float Half2_Shuriken_AntiClockwise_Speed = 5f;
    [SerializeField] int Half2_Shuriken_AntiClockwise_damage = 1;



    [SerializeField] int Crusher_Top_Difficulty = 1;
    [SerializeField] float Crusher_Top_Duration = 0.7f;
    [SerializeField] float Crusher_Top_Spawn_interval = 0.7f;
    [SerializeField] float Crusher_Top_RestTime = 4f;
    [SerializeField] float Crusher_Top_Speed = 5f;
    [SerializeField] int Crusher_Top_damage = 1;


    [SerializeField] int Crusher_Bot_Difficulty = 1;
    [SerializeField] float Crusher_Bot_Duration = 0.7f;
    [SerializeField] float Crusher_Bot_Spawn_interval = 0.7f;
    [SerializeField] float Crusher_Bot_RestTime = 4f;
    [SerializeField] float Crusher_Bot_Speed = 5f;
    [SerializeField] int Crusher_Bot_damage = 1;


    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    [SerializeField] float minY = -4.5f;
    [SerializeField] float maxY = 4.5f;




    public Enemy enemy_script;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject Charachter;



    private List<System.Action> bossMoves = new List<System.Action>();
    private List<float> moveDurations = new List<float>();
    private List<float> restTimes = new List<float>();
    private List<float> moveSpeeds = new List<float>();
    private List<float> spawnIntervals = new List<float>();
    private int currentMoveIndex = 0;
    private float moveTimer = 0f;
    private float spawnTimer = 0f;
    private bool isWaitingForNextMove = false;

    private void Start()
    {
        rain_Top_difficulty = Random.Range(1, 5);
        rain_Left_difficulty = Random.Range(1, 5);
        rain_Right_difficulty = Random.Range(1, 5);
        bull_Left_difficulty = Random.Range(1, 5);
        bull_Right_difficulty = Random.Range(1, 5);
        Circle_Difficulty = Random.Range(1, 5);
        circle_AntiClockwise_Difficulty = Random.Range(1, 5);
        circle_Clockwise_Difficulty = Random.Range(1, 5);
        circle_Random_Difficulty = Random.Range(1, 5);
        Shotgun_Difficulty = Random.Range(1, 5);
        Uzi_Difficulty = Random.Range(1, 5);
        Star_Difficulty = Random.Range(1, 5);
        Pump_Shotgun_Difficulty = Random.Range(1, 5);
        Shuriken_Clockwise_Difficulty = Random.Range(1, 5);
        Shuriken_AntiClockwise_Difficulty = Random.Range(1, 5);
        M4_Difficulty = Random.Range(1, 5);
        Crusher_Top_Difficulty = Random.Range(1, 5);
        Crusher_Bot_Difficulty = Random.Range(1, 5);
        Half_Shuriken_Clockwise_Difficulty = Random.Range(1, 5);
        Half_Shuriken_AntiClockwise_Difficulty = Random.Range(1, 5);
        Half2_Shuriken_Clockwise_Difficulty = Random.Range(1, 5);
        Half2_Shuriken_AntiClockwise_Difficulty = Random.Range(1, 5);
        //rain_Bottom_difficulty = Random.Range(1, 5);

        rain_Top_Spawn_interval = 0.7f - rain_Top_difficulty * 0.1f;
        rain_Left_Spawn_interval = 0.7f - rain_Left_difficulty * 0.1f;
        rain_Right_Spawn_interval = 0.7f - rain_Right_difficulty * 0.1f;
        //rain_Bottom_Spawn_interval = 0.5f - rain_Bottom_difficulty * 0.1f;

        bull_Left_Speed = 4f + bull_Left_difficulty;
        bull_Right_Speed = 4f + bull_Right_difficulty;

        circle_Random_Spawn_interval = 0.3f - circle_Random_Difficulty * 0.05f;


        Uzi_Spawn_interval = 0.2f;
        Uzi_Duration = Uzi_Difficulty;

        M4_Spawn_interval = 0.2f;
        M4_Duration = 1 + M4_Difficulty/2;

        List<System.Action> allMoves = new List<System.Action>
        {
            rain_Top,
            rain_Left,
            rain_Right,
            bull_Left,
            bull_Right,
            circleShoot,
            circle_Random,
            circle_Clockwise,
            circle_AntiClockwise,
            Shotgun,
            Uzi,
            Star,
            Pump_Shotgun,
            Shuriken_Clockwise,
            Shuriken_AntiClockwise,
            M4,
            Half_Shuriken_Clockwise,
            Half_Shuriken_AntiClockwise,
            Half2_Shuriken_Clockwise,
            Half2_Shuriken_AntiClockwise,
            Crusher_Top,
            Crusher_Bot

    };

        List<float> allDurations = new List<float>
        {
            rain_Top_Duration,
            rain_Left_Duration,
            rain_Right_Duration,
            bull_Left_Duration,
            bull_Right_Duration,
            Circle_Duration,
            circle_Random_Duration,
            circle_Clockwise_Duration,
            circle_AntiClockwise_Duration,
            Shotgun_Duration,
            Uzi_Duration,
            Star_Duration,
            Pump_Shotgun_Duration,
            Shuriken_Clockwise_Duration,
            Shuriken_AntiClockwise_Duration,
            M4_Duration,
            Half_Shuriken_Clockwise_Duration,
            Half_Shuriken_AntiClockwise_Duration,
            Half2_Shuriken_Clockwise_Duration,
            Half2_Shuriken_AntiClockwise_Duration,
            Crusher_Top_Duration,
            Crusher_Bot_Duration

        };

        List<float> allRestTimes = new List<float>
        {
            rain_Top_RestTime,
            rain_Left_RestTime,
            rain_Right_RestTime,
            bull_Left_RestTime,
            bull_Right_RestTime,
            Circle_RestTime,
            circle_Random_RestTime ,
            circle_Clockwise_RestTime,
            circle_AntiClockwise_RestTime,
            Shotgun_RestTime,
            Uzi_RestTime,
            Star_RestTime,
            Pump_Shotgun_RestTime,
            Shuriken_Clockwise_RestTime,
            Shuriken_AntiClockwise_RestTime,
            M4_RestTime,
            Half_Shuriken_Clockwise_RestTime,
            Half_Shuriken_AntiClockwise_RestTime,
            Half2_Shuriken_Clockwise_RestTime,
            Half2_Shuriken_AntiClockwise_RestTime,
            Crusher_Top_RestTime,
            Crusher_Bot_RestTime
        };

        List<float> allSpeeds = new List<float>
        {
            rain_Top_Speed,
            rain_Left_Speed,
            rain_Right_Speed,
            bull_Left_Speed,
            bull_Right_Speed,
            Circle_Speed ,
            circle_Random_Speed,
            circle_Clockwise_Speed,
            circle_AntiClockwise_Speed,
            Shotgun_Speed,
            Uzi_Speed,
            Star_Speed,
            Pump_Shotgun_Speed,
            Shuriken_Clockwise_Speed,
            Shuriken_AntiClockwise_Speed,
            M4_Speed ,
            Half_Shuriken_Clockwise_Speed,
            Half_Shuriken_AntiClockwise_Speed,
            Half2_Shuriken_Clockwise_Speed,
            Half2_Shuriken_AntiClockwise_Speed,
            Crusher_Top_Speed,
            Crusher_Bot_Speed
        };

        List<float> spawnInterval = new List<float>
        {
            rain_Top_Spawn_interval,
            rain_Left_Spawn_interval,
            rain_Right_Spawn_interval,
            bull_Left_Spawn_interval,
            bull_Right_Spawn_interval,
            Circle_Spawn_interval ,
            circle_Random_Spawn_interval,
            circle_Clockwise_Spawn_interval,
            circle_AntiClockwise_Spawn_interval,
            Shotgun_Spawn_interval,
            Uzi_Spawn_interval,
            Star_Spawn_interval,
            Pump_Shotgun_Spawn_interval,
            Shuriken_Clockwise_Spawn_interval,
            Shuriken_AntiClockwise_Spawn_interval,
            M4_Spawn_interval,
            Half_Shuriken_Clockwise_Spawn_interval,
            Half_Shuriken_AntiClockwise_Spawn_interval,
            Half2_Shuriken_Clockwise_Spawn_interval,
            Half2_Shuriken_AntiClockwise_Spawn_interval,
            Crusher_Top_Spawn_interval,
            Crusher_Bot_Spawn_interval

        };

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, allMoves.Count);
            bossMoves.Add(allMoves[randomIndex]);
            moveDurations.Add(allDurations[randomIndex]);
            restTimes.Add(allRestTimes[randomIndex]);
            moveSpeeds.Add(allSpeeds[randomIndex]);
            spawnIntervals.Add(spawnInterval[randomIndex]);

            allMoves.RemoveAt(randomIndex);
            allDurations.RemoveAt(randomIndex);
            allRestTimes.RemoveAt(randomIndex);
            allSpeeds.RemoveAt(randomIndex);
            spawnInterval.RemoveAt(randomIndex);
        }
    }

    private void Update()
    {
        if (enemy == null) return;

        if (isWaitingForNextMove) return;

        moveTimer += Time.deltaTime;

        if (moveTimer < moveDurations[currentMoveIndex])
        {
            if (currentMoveIndex < 4)
            {
                spawnTimer += Time.deltaTime;
                if (spawnTimer >= spawnIntervals[currentMoveIndex])
                {
                    bossMoves[currentMoveIndex]();
                    spawnTimer = 0f;
                }
            }
        }
        else
        {

            StartCoroutine(WaitForNextMove(restTimes[currentMoveIndex]));
        }
    }

    IEnumerator WaitForNextMove(float restTime)
    {
        isWaitingForNextMove = true;
        yield return new WaitForSeconds(restTime);
        moveTimer = 0f;
        currentMoveIndex++;

        if (currentMoveIndex >= bossMoves.Count) currentMoveIndex = 0;

        isWaitingForNextMove = false;
        enemy_script.SetCanPatrol(true);
    }


    void rain_Top()
    {
        // Generate a random x position within the screen bounds
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, maxY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootBullet(spawnPosition, Vector2.down, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Top_bulletDamage);
    }

    void rain_Left()
    {
        // Generate a random y position within the screen bounds
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(minX, randomY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootBullet(spawnPosition, Vector2.right, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Left_bulletDamage);
    }

    void rain_Right()
    {
        // Generate a random y position within the screen bounds
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(maxX, randomY);

        // Instantiate and shoot the projectile with the appropriate speed
        SpawnAndShootBullet(spawnPosition, Vector2.left, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Right_bulletDamage);
    }

    //void rain_Bottom()
    //{
    //    // Generate a random x position within the screen bounds
    //    float randomX = Random.Range(minX, maxX);
    //    Vector2 spawnPosition = new Vector2(randomX, minY);

    //    // Instantiate and shoot the projectile with the appropriate speed
    //    SpawnAndShootBullet(spawnPosition, Vector2.up, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Top_bulletDamage);
    //}

    void bull_Left()
    {
        // Spawn the bull on the left side, glued to the ground
        Vector2 spawnPosition = new Vector2(minX, minY + 0.5f);

        // Instantiate the projectile at the spawn position
        GameObject newProjectile = Instantiate(BullPrefab, spawnPosition, Quaternion.identity);

        // Flip the X-axis by inverting the local scale
        Vector3 localScale = newProjectile.transform.localScale;
        localScale.x *= -1; // Flip the x-axis
        newProjectile.transform.localScale = localScale;

        // Get the Projectile component from the instantiated object and shoot it with the given speed
        var projectileScript = newProjectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Shoot(Vector2.right, moveSpeeds[currentMoveIndex], bull_Left_damage); // Shoot the projectile in the specified direction with the specified speed and damage
        }

    }

    void bull_Right()
    {
        // Spawn the bull on the right side, glued to the ground
        Vector2 spawnPosition = new Vector2(maxX, minY + 0.5f);

        // Instantiate and shoot the bull projectile to the left
        SpawnAndShootBullet(spawnPosition, Vector2.left, moveSpeeds[currentMoveIndex], BullPrefab, bull_Right_damage);
    }

    void circleShoot()
    {

        int numBullets = 8 + 2 * circle_AntiClockwise_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, circle_Random_Speed, BulletPrefab, Star_damage);
        }



    }




    void circle_Random()
    {
        float angle = Random.Range(0, 360);
        Vector2 bossPosition = enemy.transform.position;


        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        SpawnAndShootBullet(bossPosition, direction, circle_Random_Speed, BulletPrefab, circle_Random_damage);
    }


    void circle_Clockwise()
    {
        int numBullets = 9 + 3 * circle_Clockwise_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Shoot_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void circle_AntiClockwise()
    {
        int numBullets = 9 + 3 * circle_AntiClockwise_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Shoot_AntiClockwise_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Shoot_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, circle_Clockwise_Speed, BulletPrefab, circle_Clockwise_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }
    IEnumerator Shoot_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, circle_AntiClockwise_Speed, BulletPrefab, circle_AntiClockwise_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }

    void SpawnAndShootBullet(Vector2 spawnPosition, Vector2 direction, float speed, GameObject prefab, int damage)
    {
        GameObject newProjectile = Instantiate(prefab, spawnPosition, Quaternion.identity);
        var projectileScript = newProjectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Shoot(direction, speed, damage);
        }
    }


    void Shotgun()
    {
        int numBullets = 9;
        Shotgun_Speed = 4f + Shotgun_Difficulty;
        float angleStep = 40f / numBullets;
        Vector2 bossPosition = enemy.transform.position;
        Vector2 characterPosition = Charachter.transform.position;
        Vector2 directionToCharacter = characterPosition - bossPosition;
        float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;
        float startAngle = baseAngle - 20f;
        for (int i = 0; i < numBullets; i++)
        {
            // Calculate the angle for each bullet
            float bulletAngle = startAngle + i * angleStep;

            // Convert the angle to radians
            Vector2 bulletDirection = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));

            // Spawn and shoot the bullet in the calculated direction
            SpawnAndShootBullet(bossPosition, bulletDirection, Shotgun_Speed, BulletPrefab, Shotgun_damage);
        }
    }





    void Uzi()
    {
        // enemy_script.SetCanPatrol(false);
        StartCoroutine(set_enemy_patrol(Uzi_Duration + 0.2f));


        Vector2 bossPosition = enemy.transform.position;
        Vector2 characterPosition = Charachter.transform.position;
        Vector2 directionToCharacter = characterPosition - bossPosition;
        float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;
        baseAngle = Random.Range(baseAngle - 15, baseAngle + 15);



        Vector2 direction = new Vector2(Mathf.Cos(baseAngle * Mathf.Deg2Rad), Mathf.Sin(baseAngle * Mathf.Deg2Rad));
        SpawnAndShootBullet(bossPosition, direction, Uzi_Speed, BulletPrefab, Uzi_damage);
    }

    void M4()
    {
        // enemy_script.SetCanPatrol(false);
        StartCoroutine(set_enemy_patrol(M4_Duration + 0.2f));


        Vector2 bossPosition = enemy.transform.position;
        Vector2 characterPosition = Charachter.transform.position;
        Vector2 directionToCharacter = characterPosition - bossPosition;
        float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;


        Vector2 direction = new Vector2(Mathf.Cos(baseAngle * Mathf.Deg2Rad), Mathf.Sin(baseAngle * Mathf.Deg2Rad));
        SpawnAndShootBullet(bossPosition, direction, M4_Speed, BulletPrefab, M4_damage);
    }

    void Star()
    {

        enemy_script.SetCanPatrol(false);
        int numBullets = 6 + Star_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        //for (int i = 0; i < numBullets; i++)
        //{
        //    float angle = i * angleStep;
        //    Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        //    SpawnAndShootBullet(bossPosition, direction, circle_Random_Speed, BulletPrefab, Star_damage);
        //}


        StartCoroutine(Shoot_Star(numBullets, angleStep));

    }

    IEnumerator Shoot_Star(int numBullets, float angleStep)
    {
        float angleBase = 0;

        enemy_script.SetCanPatrol(false);
        for (int j = 0; j < 3; j++)
        {

            Vector2 bossPosition = enemy.transform.position;

            for (int i = 0; i < numBullets; i++)
            {
                float angle = angleBase + i * angleStep;
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                SpawnAndShootBullet(bossPosition, direction, circle_Random_Speed, BulletPrefab, Star_damage);

            }
            angleBase = angleBase + 30;
            yield return new WaitForSeconds(0.5f); // Delay between each shot

        }
        enemy_script.SetCanPatrol(true);
    }


    void Pump_Shotgun()
    {

        StartCoroutine(set_enemy_patrol(2.2f));

        enemy_script.SetCanPatrol(false);
        int numBullets = 4 + Pump_Shotgun_Difficulty;
        Shotgun_Speed = 4f + Shotgun_Difficulty;
        float angleStep = 40f / numBullets;
        Vector2 bossPosition = enemy.transform.position;
        Vector2 characterPosition = Charachter.transform.position;
        Vector2 directionToCharacter = characterPosition - bossPosition;
        float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;
        float startAngle = baseAngle - 20f;



        for (int i = 0; i < numBullets; i++)
        {
            float bulletAngle = startAngle + i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Pump_Shotgun_Speed, BulletPrefab, Pump_Shotgun_damage);
        }

    }





    void Shuriken_Clockwise()
    {

        int numBullets = 10 + 4 * Shuriken_Clockwise_Difficulty;

        float angleStep = 3f;

        StartCoroutine(Shuriken_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Shuriken_AntiClockwise()
    {
        int numBullets = 10 + 4 * Shuriken_AntiClockwise_Difficulty;
        float angleStep = 3f;

        StartCoroutine(Shuriken_AntiClockwise_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Shuriken_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = +i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_Clockwise_Speed, BulletPrefab, Shuriken_Clockwise_damage);

            angle = 90 + i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_Clockwise_Speed, BulletPrefab, Shuriken_Clockwise_damage);

            angle = 180 + i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_Clockwise_Speed, BulletPrefab, Shuriken_Clockwise_damage);

            angle = 270 + i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_Clockwise_Speed, BulletPrefab, Shuriken_Clockwise_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }


    IEnumerator Shuriken_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = -i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_AntiClockwise_Speed, BulletPrefab, Shuriken_AntiClockwise_damage);

            angle = 90 - i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_AntiClockwise_Speed, BulletPrefab, Shuriken_AntiClockwise_damage);

            angle = 180 - i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_AntiClockwise_Speed, BulletPrefab, Shuriken_AntiClockwise_damage);

            angle = 270 - i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Shuriken_AntiClockwise_Speed, BulletPrefab, Shuriken_AntiClockwise_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }




    void Crusher_Top()
    {
        int numBullets = 3 + 2 * Crusher_Top_Difficulty;
        float angleStep = 180f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Crusher_Top_BulletsWithDelay(numBullets, angleStep));

    }


    void Crusher_Bot()
    {
        int numBullets = 4 + 2 * Crusher_Bot_Difficulty;
        float angleStep = 180f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Crusher_Bot_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Crusher_Top_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = 90 + i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Crusher_Top_Speed, BulletPrefab, Crusher_Top_damage);

             bossPosition = enemy.transform.position;
             angle = 90 - i * angleStep;
             direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Crusher_Top_Speed, BulletPrefab, Crusher_Top_damage);


            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }
    IEnumerator Crusher_Bot_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = -90 + i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Crusher_Bot_Speed, BulletPrefab, Crusher_Bot_damage);

             bossPosition = enemy.transform.position;
             angle = -90 - i * angleStep;
             direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Crusher_Bot_Speed, BulletPrefab, Crusher_Bot_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }


    void Half_Shuriken_Clockwise()
    {

        int numBullets = 35 + 10 * Half_Shuriken_Clockwise_Difficulty;

        float angleStep = 2f;

        StartCoroutine(Half_Shuriken_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Half_Shuriken_AntiClockwise()
    {
        int numBullets = 35 + 10 * Half_Shuriken_AntiClockwise_Difficulty;
        float angleStep = 2f;

        StartCoroutine(Half_Shuriken_AntiClockwise_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Half_Shuriken_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = +i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half_Shuriken_Clockwise_Speed, BulletPrefab, Half_Shuriken_Clockwise_damage);



            angle = 180 + i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half_Shuriken_Clockwise_Speed, BulletPrefab, Half_Shuriken_Clockwise_damage);



            yield return new WaitForSeconds(0.05f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }


    IEnumerator Half_Shuriken_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = -i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half_Shuriken_AntiClockwise_Speed, BulletPrefab, Half_Shuriken_AntiClockwise_damage);



            angle = 180 - i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half_Shuriken_AntiClockwise_Speed, BulletPrefab, Half_Shuriken_AntiClockwise_damage);



            yield return new WaitForSeconds(0.05f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }






    void Half2_Shuriken_Clockwise()
    {

        int numBullets = 20 + 8 * Half2_Shuriken_Clockwise_Difficulty;

        float angleStep = 2f;

        StartCoroutine(Half2_Shuriken_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Half2_Shuriken_AntiClockwise()
    {
        int numBullets = 20 + 8 * Half2_Shuriken_AntiClockwise_Difficulty;
        float angleStep = 2f;

        StartCoroutine(Half2_Shuriken_AntiClockwise_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Half2_Shuriken_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = 90 + i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half2_Shuriken_Clockwise_Speed, BulletPrefab, Half2_Shuriken_Clockwise_damage);



            angle = 270 + i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half2_Shuriken_Clockwise_Speed, BulletPrefab, Half2_Shuriken_Clockwise_damage);



            yield return new WaitForSeconds(0.05f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }


    IEnumerator Half2_Shuriken_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = 90 - i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half2_Shuriken_AntiClockwise_Speed, BulletPrefab, Half2_Shuriken_AntiClockwise_damage);



            angle = 270 - i * angleStep;
            direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Half2_Shuriken_AntiClockwise_Speed, BulletPrefab, Half2_Shuriken_AntiClockwise_damage);



            yield return new WaitForSeconds(0.05f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }


    IEnumerator set_enemy_patrol(float time)
    {
        enemy_script.SetCanPatrol(false);
        yield return new WaitForSeconds(time);
        enemy_script.SetCanPatrol(true);

    }




}
