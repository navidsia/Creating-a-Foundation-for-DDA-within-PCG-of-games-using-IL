using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class boss_moves_script : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectilePrefabs; // List of projectiles
    [SerializeField] private List<GameObject> WeightedprojectilePrefab;
    [SerializeField] CharacterAgent characterAgent;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject BullPrefab;
    [SerializeField] GameObject WeightedBulletPrefab;
    [SerializeField] GameObject Left_wall;
    [SerializeField] GameObject Right_wall;
    [SerializeField] GameObject Top_wall;
    [SerializeField] GameObject Buttom_wall;

    [SerializeField] bool canpatrol = true;
    [SerializeField] Vector2 characterPosition;

    [SerializeField] int rain_Top_difficulty = 1;
    [SerializeField] float rain_Top_Duration = 4.5f;
    [SerializeField] float rain_Top_Spawn_interval = 4.5f;
    [SerializeField] float rain_Top_RestTime = 2f;
    [SerializeField] float rain_Top_Speed = 5f;
    [SerializeField] int rain_Top_bulletDamage = 1;

    [SerializeField] int rain_Left_difficulty = 1;
    [SerializeField] float rain_Left_Duration = 4.5f;
    [SerializeField] float rain_Left_Spawn_interval = 4.5f;
    [SerializeField] float rain_Left_RestTime = 2f;
    [SerializeField] float rain_Left_Speed = 5f;
    [SerializeField] int rain_Left_bulletDamage = 1;


    [SerializeField] int rain_Right_difficulty = 1;
    [SerializeField] float rain_Right_Duration = 4.5f;
    [SerializeField] float rain_Right_Spawn_interval = 4.5f;
    [SerializeField] float rain_Right_RestTime = 2f;
    [SerializeField] float rain_Right_Speed = 5f;
    [SerializeField] int rain_Right_bulletDamage = 1;

    [SerializeField] int bull_Left_difficulty = 1;
    [SerializeField] float bull_Left_Duration = 1f;
    [SerializeField] float bull_Left_Spawn_interval = 1.5f;
    [SerializeField] float bull_Left_RestTime = 4f;
    [SerializeField] float bull_Left_Speed = 5f;
    [SerializeField] int bull_Left_damage = 1;

    [SerializeField] int bull_Right_difficulty = 1;
    [SerializeField] float bull_Right_Duration = 1f;
    [SerializeField] float bull_Right_Spawn_interval = 1.5f;
    [SerializeField] float bull_Right_RestTime = 4f;
    [SerializeField] float bull_Right_Speed = 5f;
    [SerializeField] int bull_Right_damage = 1;


    [SerializeField] int circleShoot_Difficulty = 1;
    [SerializeField] float circleShoot_Duration = 1f;
    [SerializeField] float circleShoot_Spawn_interval = 0.7f;
    [SerializeField] float circleShoot_RestTime = 4f;
    [SerializeField] float circleShoot_Speed = 5f;
    [SerializeField] int circleShoot_damage = 1;

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


    [SerializeField] int circle_Weighted_Shoot_Difficulty = 1;
    [SerializeField] float circle_Weighted_Shoot_Duration = 1f;
    [SerializeField] float circle_Weighted_Shoot_Spawn_interval = 0.7f;
    [SerializeField] float circle_Weighted_Shoot_RestTime = 4f;
    [SerializeField] float circle_Weighted_Shoot_Speed = 5f;
    [SerializeField] int circle_Weighted_Shoot_damage = 1;

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
    [SerializeField] int current_bullet = -1;
    [SerializeField] int current_bullet_weighted = -1;
    public Enemy enemy_script;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject Charachter;
    [SerializeField] List<int> bullet_types_integer;




    [SerializeField] List<System.Action> allMoves;
    [SerializeField] List<float> allDurations;
    [SerializeField] List<float> allRestTimes;
    [SerializeField] List<float> allSpeeds;
    [SerializeField] List<float> spawnInterval;




    [SerializeField] List<System.Action> bossMoves = new List<System.Action>();
    [SerializeField] List<float> moveDurations = new List<float>();
    [SerializeField] List<float> restTimes = new List<float>();
    [SerializeField] List<float> moveSpeeds = new List<float>();
    [SerializeField] List<float> spawnIntervals = new List<float>();
    [SerializeField] int currentMoveIndex = 0;
    private float moveTimer = 0f;
    private float spawnTimer = 0f;
    private bool isWaitingForNextMove = false;

    [SerializeField] List<int> all_difficulties = new List<int>();
    [SerializeField] public List<int> selected_indexes ;
    [SerializeField] public List<int> selected_difficulties;

    [SerializeField] public bool can_update = true;

    [SerializeField] public int scenario = 0;

    [SerializeField] public int number_of_moves = 3;



    [SerializeField] public int randomIndex;
    private void Start()
    {
        Start_function();
    }
    public void Start_function()
    {
        if (selected_indexes.Count == 0)
        {
            selected_indexes = Enumerable.Repeat(-1, number_of_moves).ToList();
            selected_difficulties = Enumerable.Repeat(-1, number_of_moves).ToList();
        }



        bossMoves = new List<System.Action>();
        moveDurations = new List<float>();
        restTimes = new List<float>();
        moveSpeeds = new List<float>();
        spawnIntervals = new List<float>();


        minX = Left_wall.transform.position.x;
        maxX = Right_wall.transform.position.x;
        minY = Buttom_wall.transform.position.y + 0.5f;
        maxY = Top_wall.transform.position.y;

        rain_Top_RestTime = 7;
        rain_Left_RestTime = 7;
        rain_Right_RestTime = 7;
        bull_Left_RestTime = 6.5f;
        bull_Right_RestTime = 6.5f;
        circleShoot_RestTime = 2;
        Star_RestTime = 3.5f;
        circle_Random_RestTime = 7;
        circle_AntiClockwise_RestTime = 4;
        circle_Clockwise_RestTime = 4;
        Shotgun_RestTime = 2;
        Uzi_RestTime = 3.5f;
        M4_RestTime = 3.5f;
        Pump_Shotgun_RestTime = 3.5f;
        Shuriken_Clockwise_RestTime = 3.5f;
        Shuriken_AntiClockwise_RestTime = 3.5f;
        Half_Shuriken_Clockwise_RestTime = 3.5f;
        Half_Shuriken_AntiClockwise_RestTime = 3.5f;
        Half2_Shuriken_Clockwise_RestTime = 3.5f;
        Half2_Shuriken_AntiClockwise_RestTime = 3.5f;
        //Crusher_Top_RestTime = 0;
        //Crusher_Bot_RestTime = 0;
        //Spiral_Clockwise_RestTime = 0;
        //Spiral_AntiClockwise_RestTime = 0;
        //circle_Weighted_Shoot_RestTime = 0;
        //Star_Weighted_RestTime = 0;
        //Shotgun_Clockwise_RestTime = 0;
        //Shotgun_AntiClockwise_RestTime = 0;
        Circle_Weighted_Random_RestTime = 7;
        Eruption_RestTime = 7;


        if (scenario == 0)
        {



            rain_Top_difficulty = 0;
            rain_Left_difficulty = 0;
            rain_Right_difficulty = 0;
            bull_Left_difficulty = 0;
            bull_Right_difficulty = 0;
            circleShoot_Difficulty = 0;
            Star_Difficulty = 0;
            circle_Random_Difficulty = 0;
            circle_AntiClockwise_Difficulty = 0;
            circle_Clockwise_Difficulty = 0;
            Shotgun_Difficulty = 0;
            Uzi_Difficulty = 0;
            M4_Difficulty = 0;
            Pump_Shotgun_Difficulty = 0;
            Shuriken_Clockwise_Difficulty = 0;
            Shuriken_AntiClockwise_Difficulty = 0;
            Half_Shuriken_Clockwise_Difficulty = 0;
            Half_Shuriken_AntiClockwise_Difficulty = 0;
            Half2_Shuriken_Clockwise_Difficulty = 0;
            Half2_Shuriken_AntiClockwise_Difficulty = 0;
            Crusher_Top_Difficulty = 0;
            Crusher_Bot_Difficulty = 0;
            Spiral_Clockwise_Difficulty = 0;
            Spiral_AntiClockwise_Difficulty = 0;
            circle_Weighted_Shoot_Difficulty = 0;
            Star_Weighted_Difficulty = 0;
            Shotgun_Clockwise_Difficulty = 0;
            Shotgun_AntiClockwise_Difficulty = 0;
            Circle_Weighted_Random_Difficulty = 0;
            Eruption_Difficulty = 0;
            //rain_Bottom_difficulty = Random.Range(1, 5);
            adjust_difficulty_settings();

            allMoves = new List<System.Action>
        {
                //rain_Top,
                //rain_Left,
                //rain_Right,
                //bull_Left,
                //bull_Right,
                //circleShoot,
                //circle_Random,
                //circle_Clockwise,
                //circle_AntiClockwise,
                //Shotgun,
                //Uzi,
                //Star,
                //Pump_Shotgun,
                //Shuriken_Clockwise,
                //Shuriken_AntiClockwise,
                //M4,
                //Half_Shuriken_Clockwise,
                //Half_Shuriken_AntiClockwise,
                //Half2_Shuriken_Clockwise,
                //Half2_Shuriken_AntiClockwise,
                //Crusher_Top,
                //Crusher_Bot,
                //Spiral_Clockwise,
                //Spiral_AntiClockwise,
                //circle_Weighted_Shoot,
                //Star_Weighted,
                //Shotgun_Clockwise,
                //Shotgun_AntiClockwise,
                //Circle_Weighted_Random,
                //Eruption

            rain_Top, // 0
            rain_Left, // 1
            rain_Right, // 2
            bull_Left, // 3
            bull_Right, // 4
            circleShoot, // 5
            Star, // 6
            circle_Random, // 7
            circle_AntiClockwise, // 8
            circle_Clockwise, // 9
            Shotgun, // 10
            Uzi, // 11
            M4, // 12
            Pump_Shotgun, // 13
            Shuriken_Clockwise, // 14
            Shuriken_AntiClockwise, // 15
            Half_Shuriken_Clockwise, // 16
            Half_Shuriken_AntiClockwise, // 17
            Half2_Shuriken_Clockwise, // 18
            Half2_Shuriken_AntiClockwise, // 19
            Crusher_Top, // 20
            Crusher_Bot, // 21
            Spiral_Clockwise, // 22
            Spiral_AntiClockwise, // 23
            circle_Weighted_Shoot, // 24
            Star_Weighted, // 25
            Shotgun_Clockwise, // 26
            Shotgun_AntiClockwise, // 27
            Circle_Weighted_Random, // 28
            Eruption //29

        };

            allDurations = new List<float>
        {
            //rain_Top_Duration,
            //rain_Left_Duration,
            //rain_Right_Duration,
            //bull_Left_Duration,
            //bull_Right_Duration,
            //Circle_Duration,
            //circle_Random_Duration,
            //circle_Clockwise_Duration,
            //circle_AntiClockwise_Duration,
            //Shotgun_Duration,
            //Uzi_Duration,
            //Star_Duration,
            //Pump_Shotgun_Duration,
            //Shuriken_Clockwise_Duration,
            //Shuriken_AntiClockwise_Duration,
            //M4_Duration,
            //Half_Shuriken_Clockwise_Duration,
            //Half_Shuriken_AntiClockwise_Duration,
            //Half2_Shuriken_Clockwise_Duration,
            //Half2_Shuriken_AntiClockwise_Duration,
            //Crusher_Top_Duration,
            //Crusher_Bot_Duration,
            //Spiral_Clockwise_Duration,
            //Spiral_AntiClockwise_Duration,
            //Circle_Weighted_Duration,
            //Star_Weighted_Duration,
            //Shotgun_Clockwise_Duration,
            //Shotgun_AntiClockwise_Duration,
            //Circle_Weighted_Random_Duration,
            //Eruption_Duration

            rain_Top_Duration,
            rain_Left_Duration,
            rain_Right_Duration,
            bull_Left_Duration,
            bull_Right_Duration,
            circleShoot_Duration,
            Star_Duration,
            circle_Random_Duration,
            circle_AntiClockwise_Duration,
            circle_Clockwise_Duration,
            Shotgun_Duration,
            Uzi_Duration,
            M4_Duration,
            Pump_Shotgun_Duration,
            Shuriken_Clockwise_Duration,
            Shuriken_AntiClockwise_Duration,
            Half_Shuriken_Clockwise_Duration,
            Half_Shuriken_AntiClockwise_Duration,
            Half2_Shuriken_Clockwise_Duration,
            Half2_Shuriken_AntiClockwise_Duration,
            Crusher_Top_Duration,
            Crusher_Bot_Duration,
            Spiral_Clockwise_Duration,
            Spiral_AntiClockwise_Duration,
            circle_Weighted_Shoot_Duration,
            Star_Weighted_Duration,
            Shotgun_Clockwise_Duration,
            Shotgun_AntiClockwise_Duration,
            Circle_Weighted_Random_Duration,
            Eruption_Duration
        };

            allRestTimes = new List<float>
        {
            //rain_Top_RestTime,
            //rain_Left_RestTime,
            //rain_Right_RestTime,
            //bull_Left_RestTime,
            //bull_Right_RestTime,
            //circleShoot_RestTime,
            //circle_Random_RestTime,
            //circle_Clockwise_RestTime,
            //circle_AntiClockwise_RestTime,
            //Shotgun_RestTime,
            //Uzi_RestTime,
            //Star_RestTime,
            //Pump_Shotgun_RestTime,
            //Shuriken_Clockwise_RestTime,
            //Shuriken_AntiClockwise_RestTime,
            //M4_RestTime,
            //Half_Shuriken_Clockwise_RestTime,
            //Half_Shuriken_AntiClockwise_RestTime,
            //Half2_Shuriken_Clockwise_RestTime,
            //Half2_Shuriken_AntiClockwise_RestTime,
            //Crusher_Top_RestTime,
            //Crusher_Bot_RestTime,
            //Spiral_Clockwise_RestTime,
            //Spiral_AntiClockwise_RestTime,
            //circle_Weighted_Shoot_RestTime,
            //Star_Weighted_RestTime,
            //Shotgun_Clockwise_RestTime,
            //Shotgun_AntiClockwise_RestTime,
            //Circle_Weighted_Random_RestTime,
            //Eruption_RestTime

            rain_Top_RestTime,
            rain_Left_RestTime,
            rain_Right_RestTime,
            bull_Left_RestTime,
            bull_Right_RestTime,
            circleShoot_RestTime,
            Star_RestTime,
            circle_Random_RestTime,
            circle_AntiClockwise_RestTime,
            circle_Clockwise_RestTime,
            Shotgun_RestTime,
            Uzi_RestTime,
            M4_RestTime,
            Pump_Shotgun_RestTime,
            Shuriken_Clockwise_RestTime,
            Shuriken_AntiClockwise_RestTime,
            Half_Shuriken_Clockwise_RestTime,
            Half_Shuriken_AntiClockwise_RestTime,
            Half2_Shuriken_Clockwise_RestTime,
            Half2_Shuriken_AntiClockwise_RestTime,
            Crusher_Top_RestTime,
            Crusher_Bot_RestTime,
            Spiral_Clockwise_RestTime,
            Spiral_AntiClockwise_RestTime,
            circle_Weighted_Shoot_RestTime,
            Star_Weighted_RestTime,
            Shotgun_Clockwise_RestTime,
            Shotgun_AntiClockwise_RestTime,
            Circle_Weighted_Random_RestTime,
            Eruption_RestTime
        };

            allSpeeds = new List<float>
        {
            //rain_Top_Speed,
            //rain_Left_Speed,
            //rain_Right_Speed,
            //bull_Left_Speed,
            //bull_Right_Speed,
            //circleShoot_Speed ,
            //circle_Random_Speed,
            //circle_Clockwise_Speed,
            //circle_AntiClockwise_Speed,
            //Shotgun_Speed,
            //Uzi_Speed,
            //Star_Speed,
            //Pump_Shotgun_Speed,
            //Shuriken_Clockwise_Speed,
            //Shuriken_AntiClockwise_Speed,
            //M4_Speed ,
            //Half_Shuriken_Clockwise_Speed,
            //Half_Shuriken_AntiClockwise_Speed,
            //Half2_Shuriken_Clockwise_Speed,
            //Half2_Shuriken_AntiClockwise_Speed,
            //Crusher_Top_Speed,
            //Crusher_Bot_Speed,
            //Spiral_Clockwise_Speed,
            //Spiral_AntiClockwise_Speed,
            //circle_Weighted_Shoot_Speed,
            //Star_Weighted_Speed,
            //Shotgun_Clockwise_Speed,
            //Shotgun_AntiClockwise_Speed,
            //Circle_Weighted_Random_Speed,
            //Eruption_Speed

            rain_Top_Speed,
            rain_Left_Speed,
            rain_Right_Speed,
            bull_Left_Speed,
            bull_Right_Speed,
            circleShoot_Speed,
            Star_Speed,
            circle_Random_Speed,
            circle_AntiClockwise_Speed,
            circle_Clockwise_Speed,
            Shotgun_Speed,
            Uzi_Speed,
            M4_Speed,
            Pump_Shotgun_Speed,
            Shuriken_Clockwise_Speed,
            Shuriken_AntiClockwise_Speed,
            Half_Shuriken_Clockwise_Speed,
            Half_Shuriken_AntiClockwise_Speed,
            Half2_Shuriken_Clockwise_Speed,
            Half2_Shuriken_AntiClockwise_Speed,
            Crusher_Top_Speed,
            Crusher_Bot_Speed,
            Spiral_Clockwise_Speed,
            Spiral_AntiClockwise_Speed,
            circle_Weighted_Shoot_Speed,
            Star_Weighted_Speed,
            Shotgun_Clockwise_Speed,
            Shotgun_AntiClockwise_Speed,
            Circle_Weighted_Random_Speed,
            Eruption_Speed

        };

            spawnInterval = new List<float>
        {
            //rain_Top_Spawn_interval,
            //rain_Left_Spawn_interval,
            //rain_Right_Spawn_interval,
            //bull_Left_Spawn_interval,
            //bull_Right_Spawn_interval,
            //circleShoot_Spawn_interval ,
            //circle_Random_Spawn_interval,
            //circle_Clockwise_Spawn_interval,
            //circle_AntiClockwise_Spawn_interval,
            //Shotgun_Spawn_interval,
            //Uzi_Spawn_interval,
            //Star_Spawn_interval,
            //Pump_Shotgun_Spawn_interval,
            //Shuriken_Clockwise_Spawn_interval,
            //Shuriken_AntiClockwise_Spawn_interval,
            //M4_Spawn_interval,
            //Half_Shuriken_Clockwise_Spawn_interval,
            //Half_Shuriken_AntiClockwise_Spawn_interval,
            //Half2_Shuriken_Clockwise_Spawn_interval,
            //Half2_Shuriken_AntiClockwise_Spawn_interval,
            //Crusher_Top_Spawn_interval,
            //Crusher_Bot_Spawn_interval,
            //Spiral_Clockwise_Spawn_interval,
            //Spiral_AntiClockwise_Spawn_interval,
            //circle_Weighted_Shoot_Spawn_interval,
            //Star_Weighted_Spawn_interval,
            //Shotgun_Clockwise_Spawn_interval,
            //Shotgun_AntiClockwise_Spawn_interval,
            //Circle_Weighted_Random_Spawn_interval,
            //Eruption_Spawn_interval


            rain_Top_Spawn_interval,
            rain_Left_Spawn_interval,
            rain_Right_Spawn_interval,
            bull_Left_Spawn_interval,
            bull_Right_Spawn_interval,
            circleShoot_Spawn_interval,
            Star_Spawn_interval,
            circle_Random_Spawn_interval,
            circle_AntiClockwise_Spawn_interval,
            circle_Clockwise_Spawn_interval,
            Shotgun_Spawn_interval,
            Uzi_Spawn_interval,
            M4_Spawn_interval,
            Pump_Shotgun_Spawn_interval,
            Shuriken_Clockwise_Spawn_interval,
            Shuriken_AntiClockwise_Spawn_interval,
            Half_Shuriken_Clockwise_Spawn_interval,
            Half_Shuriken_AntiClockwise_Spawn_interval,
            Half2_Shuriken_Clockwise_Spawn_interval,
            Half2_Shuriken_AntiClockwise_Spawn_interval,
            Crusher_Top_Spawn_interval,
            Crusher_Bot_Spawn_interval,
            Spiral_Clockwise_Spawn_interval,
            Spiral_AntiClockwise_Spawn_interval,
            circle_Weighted_Shoot_Spawn_interval,
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
            circle_Weighted_Shoot_Difficulty = 4;
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
                circle_Weighted_Shoot_Duration,
                circle_Clockwise_Duration
            };

            allRestTimes = new List<float>
            {
                rain_Top_RestTime,
                circle_Weighted_Shoot_RestTime,
                circle_Clockwise_RestTime
            };

            allSpeeds = new List<float>
            {
                rain_Top_Speed,
                circle_Weighted_Shoot_Speed,
                circle_Clockwise_Speed
            };

            spawnInterval = new List<float>
            {
                rain_Top_Spawn_interval,
                circle_Weighted_Shoot_Spawn_interval,
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
            circleShoot_Difficulty = 2; // Randomly chosen
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
        circleShoot_Duration,
        M4_Duration,
        Half2_Shuriken_AntiClockwise_Duration
    };

            allRestTimes = new List<float>
    {
        circleShoot_RestTime,
        M4_RestTime,
        Half2_Shuriken_AntiClockwise_RestTime
    };

            allSpeeds = new List<float>
    {
        circleShoot_Speed,
        M4_Speed,
        Half2_Shuriken_AntiClockwise_Speed
    };

            spawnInterval = new List<float>
    {
        circleShoot_Spawn_interval,
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

        all_difficulties = new List<int>();
        all_difficulties.Add(rain_Top_difficulty);
        all_difficulties.Add(rain_Left_difficulty);
        all_difficulties.Add(rain_Right_difficulty);
        all_difficulties.Add(bull_Left_difficulty);
        all_difficulties.Add(bull_Right_difficulty);
        all_difficulties.Add(circleShoot_Difficulty);
        all_difficulties.Add(Star_Difficulty);
        all_difficulties.Add(circle_Random_Difficulty);
        all_difficulties.Add(circle_AntiClockwise_Difficulty);
        all_difficulties.Add(circle_Clockwise_Difficulty);
        all_difficulties.Add(Shotgun_Difficulty);
        all_difficulties.Add(Uzi_Difficulty);
        all_difficulties.Add(M4_Difficulty);
        all_difficulties.Add(Pump_Shotgun_Difficulty);
        all_difficulties.Add(Shuriken_Clockwise_Difficulty);
        all_difficulties.Add(Shuriken_AntiClockwise_Difficulty);
        all_difficulties.Add(Half_Shuriken_Clockwise_Difficulty);
        all_difficulties.Add(Half_Shuriken_AntiClockwise_Difficulty);
        all_difficulties.Add(Half2_Shuriken_Clockwise_Difficulty);
        all_difficulties.Add(Half2_Shuriken_AntiClockwise_Difficulty);
        all_difficulties.Add(Crusher_Top_Difficulty);
        all_difficulties.Add(Crusher_Bot_Difficulty);
        all_difficulties.Add(Spiral_Clockwise_Difficulty);
        all_difficulties.Add(Spiral_AntiClockwise_Difficulty);
        all_difficulties.Add(circle_Weighted_Shoot_Difficulty);
        all_difficulties.Add(Star_Weighted_Difficulty);
        all_difficulties.Add(Shotgun_Clockwise_Difficulty);
        all_difficulties.Add(Shotgun_AntiClockwise_Difficulty);
        all_difficulties.Add(Circle_Weighted_Random_Difficulty);
        all_difficulties.Add(Eruption_Difficulty);



       
        if (selected_indexes.Count==0 || selected_indexes == null)
        {

            set_moves_and_bullets(new List<int> {-1,-1,-1} , new List<int> { -1, -1, -1 });
            
        }
        else
        {
            
            set_moves_and_bullets(selected_indexes, selected_difficulties);
            
        }


    }

    private void Update()
    {
        if (can_update)
        {
            minX = Left_wall.transform.position.x;
            maxX = Right_wall.transform.position.x;
            minY = Buttom_wall.transform.position.y + 0.5f;
            maxY = Top_wall.transform.position.y;

            if (enemy == null) return;

            if (isWaitingForNextMove) return;

            bossMoves[currentMoveIndex]();
            StartCoroutine(WaitForNextMove(restTimes[currentMoveIndex]));

            //moveTimer += Time.deltaTime;

            //if (moveTimer < moveDurations[currentMoveIndex])
            //{
            //    if (currentMoveIndex < 30)
            //    {
            //        spawnTimer += Time.deltaTime;
            //        if (spawnTimer >= spawnIntervals[currentMoveIndex])
            //        {
            //            bossMoves[currentMoveIndex]();
            //            spawnTimer = 0f;
            //        }
            //    }
            //}
            //else
            //{
            //    StartCoroutine(WaitForNextMove(restTimes[currentMoveIndex]));
            //}
        }
    }

    public void set_moves_and_bullets(List<int> indexes = null, List<int> difficulties = null)
    {
        bossMoves = new List<System.Action>();
        moveDurations = new List<float>();
        restTimes = new List<float>();
        moveSpeeds = new List<float>();
        spawnIntervals = new List<float>();
        randomIndex = 0;



        List<int> indices = Enumerable.Range(0, allMoves.Count).ToList();
        indices = indices.OrderBy(x => Random.value).ToList(); // Shuffle the indices.

        if (indexes[0] == -1 || indexes == null)
        {
            for (int i = 0; i < number_of_moves; i++)
            {
                selected_indexes[i] = indices[i];
            }
        }

        for (int i = 0; i < number_of_moves; i++)
        {

            if (selected_difficulties[i] == -1 || selected_difficulties == null)
            {


                randomIndex = selected_indexes[i];
                all_difficulties[randomIndex] = Random.Range(1, 5);
                selected_difficulties[i] = all_difficulties[randomIndex];
                update_difficulties();

            }
            else
            {
                randomIndex = selected_indexes[i];
                all_difficulties[randomIndex] =selected_difficulties[i];
                //selected_difficulties[i] = all_difficulties[randomIndex];
                update_difficulties();
            }
            //else
            //{
            //    check_this_fuckery3 = true;

            //    randomIndex = indexes[i];
            //    all_difficulties[randomIndex] = difficulties[i];
            //    update_difficulties();
            //}
           
            bossMoves.Add(allMoves[randomIndex]);
            moveDurations.Add(allDurations[randomIndex]);
            restTimes.Add(allRestTimes[randomIndex]);
            moveSpeeds.Add(allSpeeds[randomIndex]);
            spawnIntervals.Add(spawnInterval[randomIndex]); 

            if (indexes == null)
            {
                allMoves.RemoveAt(randomIndex);
                allDurations.RemoveAt(randomIndex);
                allRestTimes.RemoveAt(randomIndex);
                allSpeeds.RemoveAt(randomIndex);
                spawnInterval.RemoveAt(randomIndex);
            }

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



    public void update_difficulties()
    {
        int i = 0;
        rain_Top_difficulty = all_difficulties[i++];
        rain_Left_difficulty = all_difficulties[i++];
        rain_Right_difficulty = all_difficulties[i++];
        bull_Left_difficulty = all_difficulties[i++];
        bull_Right_difficulty = all_difficulties[i++];
        circleShoot_Difficulty = all_difficulties[i++];
        Star_Difficulty = all_difficulties[i++];
        circle_Random_Difficulty = all_difficulties[i++];
        circle_AntiClockwise_Difficulty = all_difficulties[i++];
        circle_Clockwise_Difficulty = all_difficulties[i++];
        Shotgun_Difficulty = all_difficulties[i++];
        Uzi_Difficulty = all_difficulties[i++];
        M4_Difficulty = all_difficulties[i++];
        Pump_Shotgun_Difficulty = all_difficulties[i++];
        Shuriken_Clockwise_Difficulty = all_difficulties[i++];
        Shuriken_AntiClockwise_Difficulty = all_difficulties[i++];
        Half_Shuriken_Clockwise_Difficulty = all_difficulties[i++];
        Half_Shuriken_AntiClockwise_Difficulty = all_difficulties[i++];
        Half2_Shuriken_Clockwise_Difficulty = all_difficulties[i++];
        Half2_Shuriken_AntiClockwise_Difficulty = all_difficulties[i++];
        Crusher_Top_Difficulty = all_difficulties[i++];
        Crusher_Bot_Difficulty = all_difficulties[i++];
        Spiral_Clockwise_Difficulty = all_difficulties[i++];
        Spiral_AntiClockwise_Difficulty = all_difficulties[i++];
        circle_Weighted_Shoot_Difficulty = all_difficulties[i++];
        Star_Weighted_Difficulty = all_difficulties[i++];
        Shotgun_Clockwise_Difficulty = all_difficulties[i++];
        Shotgun_AntiClockwise_Difficulty = all_difficulties[i++];
        Circle_Weighted_Random_Difficulty = all_difficulties[i++];
        Eruption_Difficulty = all_difficulties[i++];
        adjust_difficulty_settings();
    }
    public void adjust_difficulty_settings()
    {

        rain_Top_Spawn_interval = 0.7f - rain_Top_difficulty * 0.1f;
        rain_Left_Spawn_interval = 0.7f - rain_Left_difficulty * 0.1f;
        rain_Right_Spawn_interval = 0.7f - rain_Right_difficulty * 0.1f;
        //rain_Bottom_Spawn_interval = 0.5f - rain_Bottom_difficulty * 0.1f;

        bull_Left_Duration = (2f + bull_Left_difficulty) * 1.5f;
        bull_Right_Duration = (2f + bull_Right_difficulty) * 1.5f;

        circle_Random_Spawn_interval = 0.3f - circle_Random_Difficulty * 0.05f;
        Circle_Weighted_Random_Spawn_interval = 0.3f - Circle_Weighted_Random_Difficulty * 0.05f;
        Eruption_Spawn_interval = 0.3f - Eruption_Difficulty * 0.05f;

        Uzi_Spawn_interval = 0.2f;
        Uzi_Duration = 1 + Uzi_Difficulty / 2f;

        M4_Spawn_interval = 0.3f;
        M4_Duration = 1 + M4_Difficulty / 2;
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
        if (currentMoveIndex == 0)
        {
            BulletPrefab = projectilePrefabs[projectile_int_1];
            WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted1];

            current_bullet = projectile_int_1;
            current_bullet_weighted = projectile_weighted1;

        }
        if (currentMoveIndex == 1)
        {
            BulletPrefab = projectilePrefabs[projectile_int_2];
            WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted2];

            current_bullet = projectile_int_2;
            current_bullet_weighted = projectile_weighted2;
        }
        if (currentMoveIndex == 2)
        {
            BulletPrefab = projectilePrefabs[projectile_int_3];
            WeightedBulletPrefab = WeightedprojectilePrefab[projectile_weighted3];


            current_bullet = projectile_int_3;
            current_bullet_weighted = projectile_weighted3;
        }





        isWaitingForNextMove = false;
        enemy_script.SetCanPatrol(true);
    }


    void rain_Top()
    {
        // Generate a random x position within the screen bounds
        float wait_time = 0.7f - rain_Top_difficulty * 0.1f;

        // Instantiate and shoot the projectile with the appropriate speed
        //  SpawnAndShootBullet(spawnPosition, Vector2.down, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Top_bulletDamage);
        StartCoroutine(shoot_rain_Top(wait_time));
    }
    IEnumerator shoot_rain_Top(float wait_time)
    {


        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 5f && can_update)
        {
            float randomX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(randomX, maxY);
            // Spawn and shoot the bullet
            SpawnAndShootBullet(spawnPosition, Vector2.down, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Top_bulletDamage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
    }



    void rain_Left()
    {
        // Generate a random x position within the screen bounds
        float wait_time = 0.7f - rain_Left_difficulty * 0.1f;

        // Instantiate and shoot the projectile with the appropriate speed
        //  SpawnAndShootBullet(spawnPosition, Vector2.down, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Top_bulletDamage);
        StartCoroutine(shoot_rain_Left(wait_time));
    }
    IEnumerator shoot_rain_Left(float wait_time)
    {


        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 5f && can_update)
        {
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(maxX, randomY);
            // Spawn and shoot the bullet
            SpawnAndShootBullet(spawnPosition, Vector2.left, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Left_bulletDamage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
    }


    void rain_Right()
    {
        // Generate a random x position within the screen bounds
        float wait_time = 0.7f - rain_Right_difficulty * 0.1f;

        // Instantiate and shoot the projectile with the appropriate speed
        //  SpawnAndShootBullet(spawnPosition, Vector2.down, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Top_bulletDamage);
        StartCoroutine(shoot_rain_Right(wait_time));
    }
    IEnumerator shoot_rain_Right(float wait_time)
    {


        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 5f && can_update)
        {
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(minX, randomY);
            // Spawn and shoot the bullet
            SpawnAndShootBullet(spawnPosition, Vector2.right, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Right_bulletDamage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
    }




    //void rain_Left()
    //{
    //    // Generate a random y position within the screen bounds
    //    float randomY = Random.Range(minY, maxY);
    //    Vector2 spawnPosition = new Vector2(minX, randomY);

    //    // Instantiate and shoot the projectile with the appropriate speed
    //    SpawnAndShootBullet(spawnPosition, Vector2.right, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Left_bulletDamage);
    //}

    //void rain_Right()
    //{
    //    // Generate a random y position within the screen bounds
    //    float randomY = Random.Range(minY, maxY);
    //    Vector2 spawnPosition = new Vector2(maxX, randomY);

    //    // Instantiate and shoot the projectile with the appropriate speed
    //    SpawnAndShootBullet(spawnPosition, Vector2.left, moveSpeeds[currentMoveIndex], BulletPrefab, rain_Right_bulletDamage);
    //}

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

        StartCoroutine(shoot_bull_Left(1.5f));
    }
    IEnumerator shoot_bull_Left(float wait_time)
    {
        bull_Left_Speed = 4f + bull_Right_difficulty;
        for (int i = 0; i < 3; i++)
        {
            if (can_update)
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
                projectileScript.Shoot(Vector2.right, bull_Left_Speed, bull_Left_damage); // Shoot the projectile in the specified direction with the specified speed and damage
            }
            yield return new WaitForSeconds(wait_time);
            }
        }
    }



    void bull_Right()
    {

        StartCoroutine(shoot_bull_Right(1.5f));
    }
    IEnumerator shoot_bull_Right(float wait_time)
    {
        bull_Right_Speed = 4f + bull_Right_difficulty;
        for (int i = 0; i < 3; i++)
        {
            if (can_update)
            {
                // Spawn the bull on the left side, glued to the ground
                Vector2 spawnPosition = new Vector2(maxX, minY + 0.5f);

                // Instantiate the projectile at the spawn position
                GameObject newProjectile = Instantiate(BullPrefab, spawnPosition, Quaternion.identity);

                // Flip the X-axis by inverting the local scale
                Vector3 localScale = newProjectile.transform.localScale;
                //localScale.x *= -1; // Flip the x-axis
                newProjectile.transform.localScale = localScale;

                // Get the Projectile component from the instantiated object and shoot it with the given speed
                var projectileScript = newProjectile.GetComponent<Projectile>();
                if (projectileScript != null)
                {
                    projectileScript.Shoot(Vector2.left, bull_Right_Speed, bull_Right_damage); // Shoot the projectile in the specified direction with the specified speed and damage
                }
                yield return new WaitForSeconds(wait_time);
            }
        }
    }

    //void bull_Right()
    //{
    //    // Spawn the bull on the right side, glued to the ground
    //    Vector2 spawnPosition = new Vector2(maxX, minY + 0.5f);

    //    // Instantiate and shoot the bull projectile to the left
    //    SpawnAndShootBullet(spawnPosition, Vector2.left, moveSpeeds[currentMoveIndex], BullPrefab, bull_Right_damage);
    //}

    void circleShoot()
    {

        int numBullets = 10 + 2 * circleShoot_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, circleShoot_Speed, BulletPrefab, circleShoot_damage);
        }



    }




    void circle_Random()
    {
        float wait_time = 0.3f - circle_Random_Difficulty * 0.05f;


        StartCoroutine(shoot_circle_Random(wait_time));
    }


    IEnumerator shoot_circle_Random(float wait_time)
    {


        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 5f && can_update)
        {
            float angle = Random.Range(0, 360);
            Vector2 bossPosition = enemy.transform.position;

            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, circle_Random_Speed, BulletPrefab, circle_Random_damage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
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
            float angle = -i * angleStep;
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

            characterAgent.bullets.Add(newProjectile);

            projectileScript.Shoot(direction, speed, damage);
        }
    }



    void Shotgun()
    {
        int numBullets = 9;
        Shotgun_Speed = 4f + Shotgun_Difficulty;
        float angleStep = 30f / numBullets;
        Vector2 bossPosition = enemy.transform.position;
        Vector2 characterPosition = Charachter.transform.position;
        Vector2 directionToCharacter = characterPosition - bossPosition;
        float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;
        float startAngle = baseAngle - 15f;
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

        float wait_time = 0.2f - circle_Random_Difficulty * 0.03f;


        StartCoroutine(shoot_Uzi(wait_time));
    }


    IEnumerator shoot_Uzi(float wait_time)
    {

        enemy_script.SetCanPatrol(false);

        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 1.5f && can_update)
        {
            Vector2 bossPosition = enemy.transform.position;
            Vector2 characterPosition = Charachter.transform.position;
            Vector2 directionToCharacter = characterPosition - bossPosition;
            float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;
            baseAngle = Random.Range(baseAngle - 15, baseAngle + 15);



            Vector2 direction = new Vector2(Mathf.Cos(baseAngle * Mathf.Deg2Rad), Mathf.Sin(baseAngle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Uzi_Speed, BulletPrefab, Uzi_damage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
        enemy_script.SetCanPatrol(true);


    }

    //void M4()
    //{
    //    // enemy_script.SetCanPatrol(false);
    //    StartCoroutine(set_enemy_patrol(M4_Duration + 0.2f));


    //    Vector2 bossPosition = enemy.transform.position;
    //    Vector2 characterPosition = Charachter.transform.position;
    //    Vector2 directionToCharacter = characterPosition - bossPosition;
    //    float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;


    //    Vector2 direction = new Vector2(Mathf.Cos(baseAngle * Mathf.Deg2Rad), Mathf.Sin(baseAngle * Mathf.Deg2Rad));
    //    SpawnAndShootBullet(bossPosition, direction, M4_Speed, BulletPrefab, M4_damage);
    //}


    void M4()
    {

        float wait_time = 0.35f - circle_Random_Difficulty * 0.05f;


        StartCoroutine(shoot_M4(wait_time));
    }


    IEnumerator shoot_M4(float wait_time)
    {

        enemy_script.SetCanPatrol(false);
        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 1.5f && can_update)
        {
            Vector2 bossPosition = enemy.transform.position;
            Vector2 characterPosition = Charachter.transform.position;
            Vector2 directionToCharacter = characterPosition - bossPosition;
            float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;


            Vector2 direction = new Vector2(Mathf.Cos(baseAngle * Mathf.Deg2Rad), Mathf.Sin(baseAngle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, M4_Speed, BulletPrefab, M4_damage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
        enemy_script.SetCanPatrol(true);

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



        // enemy_script.SetCanPatrol(true);
        StartCoroutine(shoot_Pump_Shotgun());
    }

    IEnumerator shoot_Pump_Shotgun()
    {


        enemy_script.SetCanPatrol(false);

        for (int z = 0; z < 3; z++)
        {
            int numBullets = 5;
            Pump_Shotgun_Speed = 4f + Pump_Shotgun_Difficulty;
            float angleStep = 20f / numBullets;
            Vector2 bossPosition = enemy.transform.position;
            Vector2 characterPosition = Charachter.transform.position;
            Vector2 directionToCharacter = characterPosition - bossPosition;
            float baseAngle = Mathf.Atan2(directionToCharacter.y, directionToCharacter.x) * Mathf.Rad2Deg;
            float startAngle = baseAngle - 10f;



            for (int i = 0; i < numBullets; i++)
            {
                float bulletAngle = startAngle + i * angleStep;
                Vector2 direction = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));
                SpawnAndShootBullet(bossPosition, direction, Pump_Shotgun_Speed, BulletPrefab, Pump_Shotgun_damage);
            }

            yield return new WaitForSeconds(0.5f); // Delay between each shot
        }


        enemy_script.SetCanPatrol(true);


    }



    void Shuriken_Clockwise()
    {

        int numBullets = 4 + 2 * Shuriken_Clockwise_Difficulty;

        float angleStep = 5f;

        StartCoroutine(Shuriken_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Shuriken_AntiClockwise()
    {
        int numBullets = 4 + 2 * Shuriken_AntiClockwise_Difficulty;
        float angleStep = 5f;

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
        int numBullets = 4 + Crusher_Top_Difficulty;
        float angleStep = 180f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Crusher_Top_BulletsWithDelay(numBullets, angleStep));

    }


    void Crusher_Bot()
    {
        int numBullets = 4 + Crusher_Bot_Difficulty;
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

        int numBullets = 6 + 3 * Half_Shuriken_Clockwise_Difficulty;

        float angleStep = 4f;

        StartCoroutine(Half_Shuriken_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Half_Shuriken_AntiClockwise()
    {
        int numBullets = 6 + 3 * Half_Shuriken_AntiClockwise_Difficulty;
        float angleStep = 4f;

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

        int numBullets = 6 + 3 * Half2_Shuriken_Clockwise_Difficulty;

        float angleStep = 4f;

        StartCoroutine(Half2_Shuriken_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Half2_Shuriken_AntiClockwise()
    {
        int numBullets = 6 + 3 * Half2_Shuriken_AntiClockwise_Difficulty;
        float angleStep = 4f;

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
        int numBullets = 8 + 3 * Spiral_Clockwise_Difficulty;
        float angleStep = 45f;
        Vector2 bossPosition = enemy.transform.position;

        StartCoroutine(Spiral_Clockwise_BulletsWithDelay(numBullets, angleStep));

    }


    void Spiral_AntiClockwise()
    {
        int numBullets = 8 + 3 * Spiral_AntiClockwise_Difficulty;
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
            float angle = -i * angleStep;
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

        int numBullets = 10 + 2 * circle_Weighted_Shoot_Difficulty;
        float angleStep = 360f / numBullets;
        Vector2 bossPosition = enemy.transform.position;

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, circleShoot_Speed, WeightedBulletPrefab, circleShoot_damage);
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

    //void Circle_Weighted_Random()
    //{
    //    StartCoroutine(set_enemy_patrol(Circle_Weighted_Random_Duration));
    //    float angle = Random.Range(0, 360);
    //    Vector2 bossPosition = enemy.transform.position;


    //    Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    //    SpawnAndShootBullet(bossPosition, direction, Circle_Weighted_Random_Speed, WeightedBulletPrefab, Circle_Weighted_Random_damage);
    //}


    void Circle_Weighted_Random()
    {
        float wait_time = 0.3f - circle_Random_Difficulty * 0.05f;


        StartCoroutine(shoot_Circle_Weighted_Random(wait_time));
    }


    IEnumerator shoot_Circle_Weighted_Random(float wait_time)
    {

        enemy_script.SetCanPatrol(false);

        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 5f && can_update)
        {
            //StartCoroutine(set_enemy_patrol(Circle_Weighted_Random_Duration));
            float angle = Random.Range(0, 360);
            Vector2 bossPosition = enemy.transform.position;


            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Circle_Weighted_Random_Speed, WeightedBulletPrefab, Circle_Weighted_Random_damage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
        }
        enemy_script.SetCanPatrol(true);

    }





    void Eruption()
    {
        float wait_time = 0.3f - circle_Random_Difficulty * 0.05f;


        StartCoroutine(shoot_Eruption(wait_time));
    }


    IEnumerator shoot_Eruption(float wait_time)
    {

        enemy_script.SetCanPatrol(false);

        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < 5f && can_update)
        {
            //StartCoroutine(set_enemy_patrol(Eruption_Duration));
            float angle = Random.Range(45, 135);
            Vector2 bossPosition = enemy.transform.position;


            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            SpawnAndShootBullet(bossPosition, direction, Eruption_Speed, WeightedBulletPrefab, Eruption_damage);

            yield return new WaitForSeconds(wait_time); // Delay between each shot

            elapsedTime += wait_time; // Increment elapsed time
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