using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_moves_script : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectilePrefabs; // List of projectiles
    [SerializeField] private List<GameObject> WeightedprojectilePrefab;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject BullPrefab;
    [SerializeField] GameObject WeightedBulletPrefab;
    [SerializeField] GameObject Left_wall;
    [SerializeField] GameObject Right_wall;
    [SerializeField] GameObject Top_wall;
    [SerializeField] GameObject Buttom_wall;

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



    [SerializeField] int Spiral_Clockwise_Difficulty = 1;
    [SerializeField] float Spiral_Clockwise_Duration = 0.7f;
    [SerializeField] float Spiral_Clockwise_Spawn_interval = 0.7f;
    [SerializeField] float Spiral_Clockwise_RestTime = 4f;
    [SerializeField] float Spiral_Clockwise_Speed = 5f;
    [SerializeField] int Spiral_Clockwise_damage = 1;


    [SerializeField] int Spiral_AntiClockwise_Difficulty = 1;
    [SerializeField] float Spiral_AntiClockwise_Duration = 0.7f;
    [SerializeField] float Spiral_AntiClockwise_Spawn_interval = 0.7f;
    [SerializeField] float Spiral_AntiClockwise_RestTime = 4f;
    [SerializeField] float Spiral_AntiClockwise_Speed = 5f;
    [SerializeField] int Spiral_AntiClockwise_damage = 1;


    [SerializeField] int Circle_Weighted_Difficulty = 1;
    [SerializeField] float Circle_Weighted_Duration = 1f;
    [SerializeField] float Circle_Weighted_Spawn_interval = 0.7f;
    [SerializeField] float Circle_Weighted_RestTime = 4f;
    [SerializeField] float Circle_Weighted_Speed = 5f;
    [SerializeField] int Circle_Weighted_damage = 1;

    [SerializeField] int Star_Weighted_Difficulty = 1;
    [SerializeField] float Star_Weighted_Duration = 1f;
    [SerializeField] float Star_Weighted_Spawn_interval = 0.7f;
    [SerializeField] float Star_Weighted_RestTime = 4f;
    [SerializeField] float Star_Weighted_Speed = 5f;
    [SerializeField] int Star_Weighted_damage = 1;





    [SerializeField] int Shotgun_Clockwise_Difficulty = 1;
    [SerializeField] float Shotgun_Clockwise_Duration = 0.7f;
    [SerializeField] float Shotgun_Clockwise_Spawn_interval = 0.7f;
    [SerializeField] float Shotgun_Clockwise_RestTime = 4f;
    [SerializeField] float Shotgun_Clockwise_Speed = 5f;
    [SerializeField] int Shotgun_Clockwise_damage = 1;


    [SerializeField] int Shotgun_AntiClockwise_Difficulty = 1;
    [SerializeField] float Shotgun_AntiClockwise_Duration = 0.7f;
    [SerializeField] float Shotgun_AntiClockwise_Spawn_interval = 0.7f;
    [SerializeField] float Shotgun_AntiClockwise_RestTime = 4f;
    [SerializeField] float Shotgun_AntiClockwise_Speed = 5f;
    [SerializeField] int Shotgun_AntiClockwise_damage = 1;


    [SerializeField] int Circle_Weighted_Random_Difficulty = 1;
    [SerializeField] float Circle_Weighted_Random_Duration = 4.5f;
    [SerializeField] float Circle_Weighted_Random_Spawn_interval = 4.5f;
    [SerializeField] float Circle_Weighted_Random_RestTime = 2f;
    [SerializeField] float Circle_Weighted_Random_Speed = 5f;
    [SerializeField] int Circle_Weighted_Random_damage = 1;


    [SerializeField] int Eruption_Difficulty = 1;
    [SerializeField] float Eruption_Duration = 4.5f;
    [SerializeField] float Eruption_Spawn_interval = 4.5f;
    [SerializeField] float Eruption_RestTime = 2f;
    [SerializeField] float Eruption_Speed = 5f;
    [SerializeField] int Eruption_damage = 1;


    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    [SerializeField] float minY = -4.5f;
    [SerializeField] float maxY = 4.5f;

    [SerializeField] int projectile_int_1 = -1;
    [SerializeField] int projectile_int_2 = -1;
    [SerializeField] int projectile_int_3 = -1;

    [SerializeField] int projectile_weighted1 = -1;
    [SerializeField] int projectile_weighted2 = -1;
    [SerializeField] int projectile_weighted3 = -1;

    public Enemy enemy_script;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject Charachter;
    [SerializeField] List<int> bullet_types_integer;



    [SerializeField] List<System.Action> allMoves;
    [SerializeField] List<float> allDurations;
    [SerializeField] List<float> allRestTimes;
    [SerializeField] List<float> allSpeeds;
    [SerializeField] List<float> spawnInterval;

    private List<System.Action> bossMoves = new List<System.Action>();
    private List<float> moveDurations = new List<float>();
    private List<float> restTimes = new List<float>();
    private List<float> moveSpeeds = new List<float>();
    private List<float> spawnIntervals = new List<float>();
    private int currentMoveIndex = 0;
    private float moveTimer = 0f;
    private float spawnTimer = 0f;
    private bool isWaitingForNextMove = false;

    [SerializeField] public bool can_update=true;

    [SerializeField] public int scenario = 0;
    private void Start()
    {
        Start_function();
    }
    public void Start_function()
    {
        bossMoves = new List<System.Action>();
        moveDurations = new List<float>();
        restTimes = new List<float>();
        moveSpeeds = new List<float>();
        spawnIntervals = new List<float>();


        minX = Left_wall.transform.position.x;
        maxX = Right_wall.transform.position.x;
        minY = Buttom_wall.transform.position.y + 0.5f;
        maxY = Top_wall.transform.position.y;

        if (scenario == 0)
        {



            rain_Top_difficulty = Random.Range(1, 5);
            rain_Left_difficulty = Random.Range(1, 5);
            rain_Right_difficulty = Random.Range(1, 5);
            bull_Left_difficulty = Random.Range(1, 5);
            bull_Right_difficulty = Random.Range(1, 5);
            Circle_Difficulty = Random.Range(1, 5);
            Star_Difficulty = Random.Range(1, 5);
            circle_Random_Difficulty = Random.Range(1, 5);
            circle_AntiClockwise_Difficulty = Random.Range(1, 5);
            circle_Clockwise_Difficulty = Random.Range(1, 5);

            Shotgun_Difficulty = Random.Range(1, 5);
            Uzi_Difficulty = Random.Range(1, 5);
            M4_Difficulty = Random.Range(1, 5);
            Pump_Shotgun_Difficulty = Random.Range(1, 5);

            Shuriken_Clockwise_Difficulty = Random.Range(1, 5);
            Shuriken_AntiClockwise_Difficulty = Random.Range(1, 5);
            Half_Shuriken_Clockwise_Difficulty = Random.Range(1, 5);
            Half_Shuriken_AntiClockwise_Difficulty = Random.Range(1, 5);
            Half2_Shuriken_Clockwise_Difficulty = Random.Range(1, 5);
            Half2_Shuriken_AntiClockwise_Difficulty = Random.Range(1, 5);

            Crusher_Top_Difficulty = Random.Range(1, 5);
            Crusher_Bot_Difficulty = Random.Range(1, 5);
            Spiral_Clockwise_Difficulty = Random.Range(1, 5);
            Spiral_AntiClockwise_Difficulty = Random.Range(1, 5);
            Circle_Weighted_Difficulty = Random.Range(1, 5);
            Star_Weighted_Difficulty = Random.Range(1, 5);
            Shotgun_Clockwise_Difficulty = Random.Range(1, 5);
            Shotgun_AntiClockwise_Difficulty = Random.Range(1, 5);
            Circle_Weighted_Random_Difficulty = Random.Range(1, 5);
            Eruption_Difficulty = Random.Range(1, 5);
            //rain_Bottom_difficulty = Random.Range(1, 5);

            allMoves = new List<System.Action>
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
            Crusher_Bot,
            Spiral_Clockwise,
            Spiral_AntiClockwise,
            circle_Weighted_Shoot,
            Star_Weighted,
            Shotgun_Clockwise,
            Shotgun_AntiClockwise,
            Circle_Weighted_Random,
            Eruption

    };

            allDurations = new List<float>
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
            Crusher_Bot_Duration,
            Spiral_Clockwise_Duration,
            Spiral_AntiClockwise_Duration,
            Circle_Weighted_Duration,
            Star_Weighted_Duration,
            Shotgun_Clockwise_Duration,
            Shotgun_AntiClockwise_Duration,
            Circle_Weighted_Random_Duration,
            Eruption_Duration
        };

             allRestTimes = new List<float>
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
            Crusher_Bot_RestTime,
            Spiral_Clockwise_RestTime,
            Spiral_AntiClockwise_RestTime,
            Circle_Weighted_RestTime,
            Star_Weighted_RestTime,
            Shotgun_Clockwise_RestTime,
            Shotgun_AntiClockwise_RestTime,
            Circle_Weighted_Random_RestTime,
            Eruption_RestTime
        };

             allSpeeds = new List<float>
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
            Crusher_Bot_Speed,
            Spiral_Clockwise_Speed,
            Spiral_AntiClockwise_Speed,
            Circle_Weighted_Speed,
            Star_Weighted_Speed,
            Shotgun_Clockwise_Speed,
            Shotgun_AntiClockwise_Speed,
            Circle_Weighted_Random_Speed,
            Eruption_Speed
        };

             spawnInterval = new List<float>
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
            Crusher_Bot_Spawn_interval,
            Spiral_Clockwise_Spawn_interval,
            Spiral_AntiClockwise_Spawn_interval,
            Circle_Weighted_Spawn_interval,
            Star_Weighted_Spawn_interval,
            Shotgun_Clockwise_Spawn_interval,
            Shotgun_AntiClockwise_Spawn_interval,
            Circle_Weighted_Random_Spawn_interval,
            Eruption_Spawn_interval

        };



        }


        else if (scenario == 1)
        {
            rain_Top_difficulty = 2;
            Circle_Weighted_Difficulty = 4;
            circle_Clockwise_Difficulty = 1;
            allMoves = new List<System.Action>
            {
                rain_Top,
                circle_Weighted_Shoot,
                circle_Clockwise

            };

            allDurations = new List<float>
            {
                rain_Top_Duration,
                Circle_Weighted_Duration,
                circle_Clockwise_Duration
            };

            allRestTimes = new List<float>
            {
                rain_Top_RestTime,
                Circle_Weighted_RestTime,
                circle_Clockwise_RestTime
            };

            allSpeeds = new List<float>
            {
                rain_Top_Speed,
                Circle_Weighted_Speed,
                circle_Clockwise_Speed
            };

            spawnInterval = new List<float>
            {
                rain_Top_Spawn_interval,
                Circle_Weighted_Spawn_interval,
                circle_Clockwise_Spawn_interval
            };
        }
        else if (scenario == 2)
        {
            rain_Right_difficulty = 3; // Randomly chosen
            Crusher_Bot_Difficulty = 1; // Randomly chosen
            Spiral_AntiClockwise_Difficulty = 4; // Randomly chosen
            allMoves = new List<System.Action>
    {
        rain_Right,
        Crusher_Bot,
        Spiral_AntiClockwise
    };

            allDurations = new List<float>
    {
        rain_Right_Duration,
        Crusher_Bot_Duration,
        Spiral_AntiClockwise_Duration
    };

            allRestTimes = new List<float>
    {
        rain_Right_RestTime,
        Crusher_Bot_RestTime,
        Spiral_AntiClockwise_RestTime
    };

            allSpeeds = new List<float>
    {
        rain_Right_Speed,
        Crusher_Bot_Speed,
        Spiral_AntiClockwise_Speed
    };

            spawnInterval = new List<float>
    {
        rain_Right_Spawn_interval,
        Crusher_Bot_Spawn_interval,
        Spiral_AntiClockwise_Spawn_interval
    };
        }
        else if (scenario == 3)
        {
            Circle_Difficulty = 2; // Randomly chosen
            M4_Difficulty = 4; // Randomly chosen
            Half2_Shuriken_AntiClockwise_Difficulty = 1; // Randomly chosen
            allMoves = new List<System.Action>
    {
        circleShoot,
        M4,
        Half2_Shuriken_AntiClockwise
    };

            allDurations = new List<float>
    {
        Circle_Duration,
        M4_Duration,
        Half2_Shuriken_AntiClockwise_Duration
    };

            allRestTimes = new List<float>
    {
        Circle_RestTime,
        M4_RestTime,
        Half2_Shuriken_AntiClockwise_RestTime
    };

            allSpeeds = new List<float>
    {
        Circle_Speed,
        M4_Speed,
        Half2_Shuriken_AntiClockwise_Speed
    };

            spawnInterval = new List<float>
    {
        Circle_Spawn_interval,
        M4_Spawn_interval,
        Half2_Shuriken_AntiClockwise_Spawn_interval
    };
        }
        else if (scenario == 4)
        {
            Shuriken_AntiClockwise_Difficulty = 3; // Randomly chosen
            rain_Left_difficulty = 2; // Randomly chosen
            bull_Right_difficulty = 4; // Randomly chosen

            allMoves = new List<System.Action>
    {
        Shuriken_AntiClockwise,
        rain_Left,
        bull_Right
    };

            allDurations = new List<float>
    {
        Shuriken_AntiClockwise_Duration,
        rain_Left_Duration,
        bull_Right_Duration
    };

            allRestTimes = new List<float>
    {
        Shuriken_AntiClockwise_RestTime,
        rain_Left_RestTime,
        bull_Right_RestTime
    };

            allSpeeds = new List<float>
    {
        Shuriken_AntiClockwise_Speed,
        rain_Left_Speed,
        bull_Right_Speed
    };

            spawnInterval = new List<float>
    {
        Shuriken_AntiClockwise_Spawn_interval,
        rain_Left_Spawn_interval,
        bull_Right_Spawn_interval
    };
        }
        else if (scenario == 5)
        {
            Half_Shuriken_AntiClockwise_Difficulty = 1; // Randomly chosen
            Shotgun_Clockwise_Difficulty = 4; // Randomly chosen
            Eruption_Difficulty = 3; // Randomly chosen
            allMoves = new List<System.Action>
    {
        Half_Shuriken_AntiClockwise,
        Shotgun_Clockwise,
        Eruption
    };

            allDurations = new List<float>
    {
        Half_Shuriken_AntiClockwise_Duration,
        Shotgun_Clockwise_Duration,
        Eruption_Duration
    };

            allRestTimes = new List<float>
    {
        Half_Shuriken_AntiClockwise_RestTime,
        Shotgun_Clockwise_RestTime,
        Eruption_RestTime
    };

            allSpeeds = new List<float>
    {
        Half_Shuriken_AntiClockwise_Speed,
        Shotgun_Clockwise_Speed,
        Eruption_Speed
    };

            spawnInterval = new List<float>
    {
        Half_Shuriken_AntiClockwise_Spawn_interval,
        Shotgun_Clockwise_Spawn_interval,
        Eruption_Spawn_interval
    };
        }
        else if (scenario == 6)
        {
            Spiral_Clockwise_Difficulty = 4; // Randomly chosen
            Pump_Shotgun_Difficulty = 2; // Randomly chosen
            Shotgun_Difficulty = 1; // Randomly chosen
            allMoves = new List<System.Action>
    {
        Spiral_Clockwise,
        Pump_Shotgun,
        Shotgun
    };

            allDurations = new List<float>
    {
        Spiral_Clockwise_Duration,
        Pump_Shotgun_Duration,
        Shotgun_Duration
    };

            allRestTimes = new List<float>
    {
        Spiral_Clockwise_RestTime,
        Pump_Shotgun_RestTime,
        Shotgun_RestTime
    };

            allSpeeds = new List<float>
    {
        Spiral_Clockwise_Speed,
        Pump_Shotgun_Speed,
        Shotgun_Speed
    };

            spawnInterval = new List<float>
    {
        Spiral_Clockwise_Spawn_interval,
        Pump_Shotgun_Spawn_interval,
        Shotgun_Spawn_interval
    };
        }
        else if (scenario == 7)
        {
            Uzi_Difficulty = 3; // Randomly chosen
            bull_Left_difficulty = 2; // Randomly chosen
            Star_Weighted_Difficulty = 4; // Randomly chosen
            allMoves = new List<System.Action>
    {
        Uzi,
        bull_Left,
        Star_Weighted
    };

            allDurations = new List<float>
    {
        Uzi_Duration,
        bull_Left_Duration,
        Star_Weighted_Duration
    };

            allRestTimes = new List<float>
    {
        Uzi_RestTime,
        bull_Left_RestTime,
        Star_Weighted_RestTime
    };

            allSpeeds = new List<float>
    {
        Uzi_Speed,
        bull_Left_Speed,
        Star_Weighted_Speed
    };

            spawnInterval = new List<float>
    {
        Uzi_Spawn_interval,
        bull_Left_Spawn_interval,
        Star_Weighted_Spawn_interval
    };
        }
        else if (scenario == 8)
        {
            Half2_Shuriken_Clockwise_Difficulty = 1; // Randomly chosen
            Circle_Weighted_Random_Difficulty = 4; // Randomly chosen
            Crusher_Top_Difficulty = 3; // Randomly chosen
            allMoves = new List<System.Action>
    {
        Half2_Shuriken_Clockwise,
        Circle_Weighted_Random,
        Crusher_Top
    };

            allDurations = new List<float>
    {
        Half2_Shuriken_Clockwise_Duration,
        Circle_Weighted_Random_Duration,
        Crusher_Top_Duration
    };

            allRestTimes = new List<float>
    {
        Half2_Shuriken_Clockwise_RestTime,
        Circle_Weighted_Random_RestTime,
        Crusher_Top_RestTime
    };

            allSpeeds = new List<float>
    {
        Half2_Shuriken_Clockwise_Speed,
        Circle_Weighted_Random_Speed,
        Crusher_Top_Speed
    };

            spawnInterval = new List<float>
    {
        Half2_Shuriken_Clockwise_Spawn_interval,
        Circle_Weighted_Random_Spawn_interval,
        Crusher_Top_Spawn_interval
    };
        }
        else if (scenario == 9)
        {
            Shotgun_AntiClockwise_Difficulty = 2; // Randomly chosen
            Star_Difficulty = 3; // Randomly chosen
            circle_AntiClockwise_Difficulty = 1; // Randomly chosen
            allMoves = new List<System.Action>
    {
        Shotgun_AntiClockwise,
        Star,
        circle_AntiClockwise
    };

            allDurations = new List<float>
    {
        Shotgun_AntiClockwise_Duration,
        Star_Duration,
        circle_AntiClockwise_Duration
    };

            allRestTimes = new List<float>
    {
        Shotgun_AntiClockwise_RestTime,
        Star_RestTime,
        circle_AntiClockwise_RestTime
    };

            allSpeeds = new List<float>
    {
        Shotgun_AntiClockwise_Speed,
        Star_Speed,
        circle_AntiClockwise_Speed
    };

            spawnInterval = new List<float>
    {
        Shotgun_AntiClockwise_Spawn_interval,
        Star_Spawn_interval,
        circle_AntiClockwise_Spawn_interval
    };
        }
        else if (scenario == 10)
        {
            circle_Random_Difficulty = 4; // Randomly chosen
            Shuriken_Clockwise_Difficulty = 2; // Randomly chosen
            Half_Shuriken_Clockwise_Difficulty = 3; // Randomly chosen
            allMoves = new List<System.Action>
    {
        circle_Random,
        Shuriken_Clockwise,
        Half_Shuriken_Clockwise
    };

            allDurations = new List<float>
    {
        circle_Random_Duration,
        Shuriken_Clockwise_Duration,
        Half_Shuriken_Clockwise_Duration
    };

            allRestTimes = new List<float>
    {
        circle_Random_RestTime,
        Shuriken_Clockwise_RestTime,
        Half_Shuriken_Clockwise_RestTime
    };

            allSpeeds = new List<float>
    {
        circle_Random_Speed,
        Shuriken_Clockwise_Speed,
        Half_Shuriken_Clockwise_Speed
    };

            spawnInterval = new List<float>
    {
        circle_Random_Spawn_interval,
        Shuriken_Clockwise_Spawn_interval,
        Half_Shuriken_Clockwise_Spawn_interval
    };
        }




        set_moves_and_bullets();
        adjust_difficulty_settings();

    }
    public void set_moves_and_bullets()
    {
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

        while (projectile_int_1 == projectile_int_2 || projectile_int_1 == projectile_int_3 || projectile_int_2 == projectile_int_3)
        {
            projectile_int_1 = Random.Range(0, 5);
            projectile_int_2 = Random.Range(0, 5);
            projectile_int_3 = Random.Range(0, 5);
        }
        BulletPrefab = projectilePrefabs[projectile_int_1];



        while (projectile_weighted1 == projectile_weighted2 || projectile_weighted1 == projectile_weighted3 || projectile_weighted2 == projectile_weighted3)
        {
            projectile_weighted1 = Random.Range(0, 5);
            projectile_weighted2 = Random.Range(0, 5);
            projectile_weighted3 = Random.Range(0, 5);
        }
        WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted1];
    }
    public void adjust_difficulty_settings()
    {

        rain_Top_Spawn_interval = 0.7f - rain_Top_difficulty * 0.1f;
        rain_Left_Spawn_interval = 0.7f - rain_Left_difficulty * 0.1f;
        rain_Right_Spawn_interval = 0.7f - rain_Right_difficulty * 0.1f;
        //rain_Bottom_Spawn_interval = 0.5f - rain_Bottom_difficulty * 0.1f;

        bull_Left_Speed = 4f + bull_Left_difficulty;
        bull_Right_Speed = 4f + bull_Right_difficulty;

        circle_Random_Spawn_interval = 0.3f - circle_Random_Difficulty * 0.05f;
        Circle_Weighted_Random_Spawn_interval = 0.3f - Circle_Weighted_Random_Difficulty * 0.05f;
        Eruption_Spawn_interval = 0.3f - Eruption_Difficulty * 0.05f;

        Uzi_Spawn_interval = 0.2f;
        Uzi_Duration = Uzi_Difficulty;

        M4_Spawn_interval = 0.2f;
        M4_Duration = 1 + M4_Difficulty / 2;
    }
    private void Update()
    {
        if (can_update)
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
    }
    public void SetCanUpdate(bool value)
    {
        can_update = value;
    }
    IEnumerator WaitForNextMove(float restTime)
    {
        isWaitingForNextMove = true;
        yield return new WaitForSeconds(restTime);
        moveTimer = 0f;
        currentMoveIndex++;

        if (currentMoveIndex >= bossMoves.Count) currentMoveIndex = 0;
        if (currentMoveIndex == 1)
        {
            BulletPrefab = projectilePrefabs[projectile_int_1];
        }
        if (currentMoveIndex == 2)
        {
            BulletPrefab = projectilePrefabs[projectile_int_2];
        }
        if (currentMoveIndex == 3)
        {
            BulletPrefab = projectilePrefabs[projectile_int_3];
        }

        if (currentMoveIndex == 1)
        {
            WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted1];
        }
        if (currentMoveIndex == 2)
        {
            WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted2];
        }
        if (currentMoveIndex == 3)
        {
            WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted3];
        }
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

        int numBullets = 8 + 2 * Circle_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Circle_Speed, BulletPrefab, Circle_damage);
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

        StartCoroutine(Circle_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void circle_AntiClockwise()
    {
        int numBullets = 9 + 3 * circle_AntiClockwise_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Circle_AntiClockwise_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Circle_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
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
    IEnumerator Circle_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
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
            projectileScript.set_enemy(enemy);


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
                SpawnAndShootBullet(bossPosition, direction, Star_Speed, BulletPrefab, Star_damage);

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
        Shotgun_Speed = 4f + Pump_Shotgun_Difficulty;
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
        int numBullets = 4 + 2 * Crusher_Top_Difficulty;
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








    void Spiral_Clockwise()
    {
        int numBullets = 8 + 4 * Spiral_Clockwise_Difficulty;
        float angleStep = 45f;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Spiral_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Spiral_AntiClockwise()
    {
        int numBullets = 8 + 4 * Spiral_AntiClockwise_Difficulty;
        float angleStep = 45f;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Spiral_AntiClockwise_BulletsWithDelay(numBullets, angleStep));
    }
    IEnumerator Spiral_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Spiral_Clockwise_Speed, BulletPrefab, Spiral_Clockwise_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }
    IEnumerator Spiral_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        enemy_script.SetCanPatrol(false);
        for (int i = 0; i < numBullets; i++)
        {
            Vector2 bossPosition = enemy.transform.position;
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Spiral_AntiClockwise_Speed, BulletPrefab, Spiral_AntiClockwise_damage);

            yield return new WaitForSeconds(0.1f); // Delay between each shot
        }
        enemy_script.SetCanPatrol(true);
    }





    void circle_Weighted_Shoot()
    {

        int numBullets = 8 + 2 * Circle_Weighted_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Circle_Weighted_Speed, WeightedBulletPrefab, Circle_Weighted_damage);
        }



    }


    void Star_Weighted()
    {

        enemy_script.SetCanPatrol(false);
        int numBullets = 6 + Star_Weighted_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        //for (int i = 0; i < numBullets; i++)
        //{
        //    float angle = i * angleStep;
        //    Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        //    SpawnAndShootBullet(bossPosition, direction, circle_Random_Speed, BulletPrefab, Star_damage);
        //}


        StartCoroutine(Shoot_Weighted_Star(numBullets, angleStep));

    }

    IEnumerator Shoot_Weighted_Star(int numBullets, float angleStep)
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
                SpawnAndShootBullet(bossPosition, direction, Star_Speed, WeightedBulletPrefab, Star_damage);

            }
            //angleBase = angleBase + 30;
            yield return new WaitForSeconds(0.5f); // Delay between each shot

        }
        enemy_script.SetCanPatrol(true);
    }








    void Shotgun_Clockwise()
    {
        int numBullets = 3 + Shotgun_Clockwise_Difficulty;
        float angleStep = 90f / numBullets;
        Vector2 bossPosition = enemy.transform.position;
        enemy_script.SetCanPatrol(false);
        StartCoroutine(Shotgun_Clockwise_BulletsWithDelay(numBullets, angleStep));



    }

    IEnumerator Shotgun_Clockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        float angleBase = 0;

        enemy_script.SetCanPatrol(false);
        for (int j = 0; j < 4; j++)
        {

            Vector2 bossPosition = enemy.transform.position;

            for (int i = 0; i < numBullets; i++)
            {
                float angle = angleBase + i * angleStep;
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                SpawnAndShootBullet(bossPosition, direction, Shotgun_Speed, BulletPrefab, Shotgun_damage);

            }
            angleBase = angleBase + 90;
            yield return new WaitForSeconds(0.7f); // Delay between each shot

        }
        enemy_script.SetCanPatrol(true);
    }



    void Shotgun_AntiClockwise()
    {
        int numBullets = 3 + Shotgun_AntiClockwise_Difficulty;
        float angleStep = 90f / numBullets;
        Vector2 bossPosition = enemy.transform.position;
        enemy_script.SetCanPatrol(false);
        StartCoroutine(Shotgun_AntiClockwise_BulletsWithDelay(numBullets, angleStep));



    }

    IEnumerator Shotgun_AntiClockwise_BulletsWithDelay(int numBullets, float angleStep)
    {
        float angleBase = 0;

        enemy_script.SetCanPatrol(false);
        for (int j = 0; j < 4; j++)
        {

            Vector2 bossPosition = enemy.transform.position;

            for (int i = 0; i < numBullets; i++)
            {
                float angle = angleBase + i * angleStep;
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                SpawnAndShootBullet(bossPosition, direction, Shotgun_Speed, BulletPrefab, Shotgun_damage);

            }
            angleBase = angleBase - 90;
            yield return new WaitForSeconds(0.7f); // Delay between each shot

        }
        enemy_script.SetCanPatrol(true);
    }

    void Circle_Weighted_Random()
    {
        StartCoroutine(set_enemy_patrol(Circle_Weighted_Random_Duration));
        float angle = Random.Range(0, 360);
        Vector2 bossPosition = enemy.transform.position;


        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        SpawnAndShootBullet(bossPosition, direction, Circle_Weighted_Random_Speed, WeightedBulletPrefab, Circle_Weighted_Random_damage);
    }


    void Eruption()
    {
        StartCoroutine(set_enemy_patrol(Eruption_Duration));
        float angle = Random.Range(45, 135);
        Vector2 bossPosition = enemy.transform.position;


        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        SpawnAndShootBullet(bossPosition, direction, Eruption_Speed, WeightedBulletPrefab, Eruption_damage);
    }




    IEnumerator set_enemy_patrol(float time)
    {
        enemy_script.SetCanPatrol(false);
        yield return new WaitForSeconds(time);
        enemy_script.SetCanPatrol(true);

    }




}