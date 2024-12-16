using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] ResultSaver resultSaver;
    public int MaxHealth;
    public int Health;
    [SerializeField] bool canPatrol;
    [SerializeField] float characterDetectionRange;
    [SerializeField] int damage;
    [SerializeField] EnemyHUDController HUD;
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] LayerMask characterLayer;
    [SerializeField] bool is_grounded = false;
    [SerializeField] public int scenario = 0;
    [SerializeField] Vector3 bottomRight;
    [SerializeField] Vector3 topRight;
    [SerializeField] Vector3 topLeft;
    [SerializeField] Vector3 bottomLeft;

    [SerializeField] GameObject Environment;

    [SerializeField] List<GameObject> enemyPrefabs; // List to hold enemy prefabs
    private GameObject selectedPrefab; // The chosen prefab

    private SpriteRenderer shapeSpriteRenderer;
    private Animator shapeAnimator;
    private List<Vector3> speedVectors;
    private int currentSpeedIndex = 0;
    private float movementTimer = 0f;
    private float stopTimer = 0f;
    private bool isStopped = false;
    private List<Vector3> patrolPositions;
    private int patrolPosIndex = 0;
    private BackgroundManager backgroundManager;

    float time;
    private Vector3 previousPosition;

    private void Start()
    {
        Start_function();
    }
    public void Start_function()
    {
        Health = MaxHealth;
        HUD.Setup(this);

        // Get the BackgroundManager reference
        backgroundManager = FindObjectOfType<BackgroundManager>();

        InitializeSpeedVectors();


        // Randomly choose an enemy prefab
        selectedPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Get the shape (child object) components
        Transform shapeTransform = transform.Find("Shape");
        shapeSpriteRenderer = shapeTransform.GetComponent<SpriteRenderer>();
        shapeAnimator = shapeTransform.GetComponent<Animator>();

        // Apply the sprite renderer and animator from the selected prefab
        ApplyRandomPrefabAppearance();
    }
    public int Return_HP_Enemy()
    {
        return Health;
    }
    private void ApplyRandomPrefabAppearance()
    {
        // Get the prefab's SpriteRenderer and Animator from the shape object
        Transform prefabShapeTransform = selectedPrefab.transform.Find("Shape");
        SpriteRenderer prefabSpriteRenderer = prefabShapeTransform.GetComponent<SpriteRenderer>();
        Animator prefabAnimator = prefabShapeTransform.GetComponent<Animator>();

        // Apply the prefab's sprite to the current enemy's sprite renderer
        shapeSpriteRenderer.sprite = prefabSpriteRenderer.sprite;

        // Apply the prefab's AnimatorController to the current enemy's animator
        RuntimeAnimatorController prefabAnimatorController = prefabAnimator.runtimeAnimatorController;
        shapeAnimator.runtimeAnimatorController = prefabAnimatorController;

        // Set the shape's scale to match the selected prefab's shape scale
        Transform shapeTransform = transform.Find("Shape");
        shapeTransform.localScale = prefabShapeTransform.localScale;

        // Apply collider properties to match the prefab
        CircleCollider2D currentCollider = GetComponent<CircleCollider2D>();
        CircleCollider2D prefabCollider = selectedPrefab.GetComponent<CircleCollider2D>();

        if (currentCollider != null && prefabCollider != null)
        {
            currentCollider.radius = prefabCollider.radius;
            currentCollider.offset = prefabCollider.offset;
        }
    }

    private void InitializeSpeedVectors()
    {
        speedVectors = new List<Vector3>();

        // Define ranges for angles
        float[][] angleRanges = new float[][]
        {
            new float[] { 0, 60 },
            new float[] { 60, 120 },
            new float[] { 120, 180 },
            new float[] { 180, 240 },
            new float[] { 240, 300 },
            new float[] { 300, 360 }
        };

        // Generate speed vectors using sine and cosine of random angles
        foreach (var range in angleRanges)
        {
            float angle = Random.Range(range[0], range[1]) * Mathf.Deg2Rad;
            speedVectors.Add(new Vector3(5 * Mathf.Cos(angle), 5 * Mathf.Sin(angle), 0));
        }

        // Shuffle the speed vectors for randomness
        for (int i = 0; i < speedVectors.Count; i++)
        {
            Vector3 temp = speedVectors[i];
            int randomIndex = Random.Range(0, speedVectors.Count);
            speedVectors[i] = speedVectors[randomIndex];
            speedVectors[randomIndex] = temp;
        }
    }

    void FaceMovementDirection()
    {
        Vector3 movementDirection = transform.localPosition - previousPosition;

        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movementDirection.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    public void StopMovement(float duration)
    {
        isStopped = true;
        stopTimer = duration;
    }

    public void SetCanPatrol(bool value)
    {
        canPatrol = value;
    }

    public void GetHit(int damage)
    {
        if (Health <= 0)
        {
            return;
        }
        Health -= damage;
        HUD.Repaint(this);

        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        float originalTimeScale = Time.timeScale;
        Time.timeScale = originalTimeScale;
        resultSaver.SaveSceneTime();
        //  Destroy(gameObject);

    }

    private void Update()
    {
        if (isStopped)
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                isStopped = false;
            }
            return;
        }
        else
        {
            MoveEnemy();
            FaceMovementDirection();
        }

        

        var hit = Physics2D.OverlapCircle(transform.localPosition, characterDetectionRange, characterLayer);
        if (hit)
        {
            hit.gameObject.GetComponent<CharacterController>().GetHit(damage);
        }

        previousPosition = transform.localPosition;
    }
    private void MoveEnemy()
    {
        movementTimer += Time.deltaTime;

        if (movementTimer >= 1f)
        {
            currentSpeedIndex = (currentSpeedIndex + 1) % speedVectors.Count;
            movementTimer = 0f;
        }

        Vector3 movement = speedVectors[currentSpeedIndex] * Time.deltaTime;
        transform.localPosition += movement;

        CheckForWallCollision();
    }
    private void CheckForWallCollision()
    {

        if(transform.position.x>7.5f || transform.position.x < -7.5f || transform.position.y<-3.5f || transform.position.y > 5f)
        {
            currentSpeedIndex = (currentSpeedIndex + 1) % speedVectors.Count;
        }
        //Vector3 pos = transform.localPosition;
        //Camera mainCamera = Camera.main;

        //if (mainCamera != null)
        //{
        //    Vector3 minBounds = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //    Vector3 maxBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //    if (pos.x <= minBounds.x || pos.x >= maxBounds.x || pos.y <= minBounds.y || pos.y >= maxBounds.y)
        //    {
        //        currentSpeedIndex = (currentSpeedIndex + 1) % speedVectors.Count;
        //    }
        //}
    }
    List<Vector3> GeneratePatrolPositions()
    {
        if (scenario == 0)
        {


            Vector3 leftWallPos = backgroundManager.GetLeftWallPosition();
            Vector3 rightWallPos = backgroundManager.GetRightWallPosition();
            Vector3 topWallPos = backgroundManager.GetTopWallPosition();
            Vector3 bottomWallPos = backgroundManager.GetBottomWallPosition();



            bottomRight = new Vector3(
               Random.Range(0, rightWallPos.x - 1.5f),
               Random.Range(bottomWallPos.y + 2f, 0),
               0);

            bottomLeft = new Vector3(
               Random.Range(leftWallPos.x + 1.5f, 0),
               Random.Range(bottomWallPos.y + 2f, 0),
               0);

            topRight = new Vector3(
               Random.Range(0, rightWallPos.x - 1.5f),
               Random.Range(0, topWallPos.y - 1.5f),
               0);

            topLeft = new Vector3(
               Random.Range(leftWallPos.x + 1.5f, 0),
               Random.Range(0, topWallPos.y - 1.5f),
               0);

            transform.localPosition = bottomRight;
        }
        /// VEEERY FUCKING WRONG. FIX TOP LEFT, SECOND SHOULD BE POSITIVE. FUCK ME
        else if (scenario == 1)
        {
            bottomRight = new Vector3(5.3f, -1.8f, 0);
            bottomLeft = new Vector3(-6.7f, -2.9f, 0);
            topRight = new Vector3(3.2f, 0.5f, 0);
            topLeft = new Vector3(-1.4f, -2.1f, 0);
        }
        else if (scenario == 2)
        {
            bottomRight = new Vector3(7.1f, -2.4f, 0);
            bottomLeft = new Vector3(-4.8f, -1.3f, 0);
            topRight = new Vector3(3.8f, 0.8f, 0);
            topLeft = new Vector3(-2.6f, -2.7f, 0);
        }
        else if (scenario == 3)
        {
            bottomRight = new Vector3(1.2f, -2.5f, 0);
            bottomLeft = new Vector3(-3.4f, -0.6f, 0);
            topRight = new Vector3(4.5f, 2.3f, 0);
            topLeft = new Vector3(-6.3f, -1.2f, 0);
        }
        else if (scenario == 4)
        {
            bottomRight = new Vector3(6.5f, -0.9f, 0);
            bottomLeft = new Vector3(-7.2f, -2.8f, 0);
            topRight = new Vector3(2.1f, 1.5f, 0);
            topLeft = new Vector3(-4.5f, -0.4f, 0);
        }
        else if (scenario == 5)
        {
            bottomRight = new Vector3(0.7f, -1.4f, 0);
            bottomLeft = new Vector3(-5.6f, -0.3f, 0);
            topRight = new Vector3(6.3f, 2.1f, 0);
            topLeft = new Vector3(-1.9f, -2.6f, 0);
        }
        else if (scenario == 6)
        {
            bottomRight = new Vector3(4.2f, -1.1f, 0);
            bottomLeft = new Vector3(-2.8f, -2.3f, 0);
            topRight = new Vector3(7.5f, 0.2f, 0);
            topLeft = new Vector3(-6.1f, -1.9f, 0);
        }
        else if (scenario == 7)
        {
            bottomRight = new Vector3(2.9f, -0.7f, 0);
            bottomLeft = new Vector3(-7.4f, -1.2f, 0);
            topRight = new Vector3(5.6f, 1.9f, 0);
            topLeft = new Vector3(-3.1f, -2.5f, 0);
        }
        else if (scenario == 8)
        {
            bottomRight = new Vector3(6.8f, -2.1f, 0);
            bottomLeft = new Vector3(-1.7f, -1.6f, 0);
            topRight = new Vector3(0.3f, 2.0f, 0);
            topLeft = new Vector3(-5.9f, -2.4f, 0);
        }
        else if (scenario == 9)
        {
            bottomRight = new Vector3(3.4f, -1.7f, 0);
            bottomLeft = new Vector3(-4.2f, -0.9f, 0);
            topRight = new Vector3(7.0f, 1.1f, 0);
            topLeft = new Vector3(-2.3f, -2.2f, 0);
        }
        else if (scenario == 10)
        {
            bottomRight = new Vector3(1.9f, -2.3f, 0);
            bottomLeft = new Vector3(-6.4f, -1.0f, 0);
            topRight = new Vector3(5.1f, 0.7f, 0);
            topLeft = new Vector3(-7.3f, -2.5f, 0);
        }

        //bottomRight = bottomRight + Environment.transform.position;
        //bottomLeft = bottomLeft + Environment.transform.position;
        //topRight = topRight + Environment.transform.position;
        //topLeft = topLeft + Environment.transform.position;



        return new List<Vector3> { bottomRight, topRight, topLeft, bottomLeft };
    }

    void MoveToPosition(Vector3 targetPosition, float speed)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        CheckPatrolPositionReached();
    }

    void CheckPatrolPositionReached()
    {
        if (Vector3.Distance(transform.localPosition, patrolPositions[patrolPosIndex]) <= 0.1f)
        {
            patrolPosIndex++;
            if (patrolPosIndex >= patrolPositions.Count)
            {
                patrolPosIndex = 0;
            }
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, characterDetectionRange);
    }
}
