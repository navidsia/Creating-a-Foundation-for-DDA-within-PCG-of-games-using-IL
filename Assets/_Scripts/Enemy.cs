using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] Vector3 bottomRight;
    [SerializeField] Vector3 topRight;
    [SerializeField] Vector3 topLeft;
    [SerializeField] Vector3 bottomLeft;

    [SerializeField] List<GameObject> enemyPrefabs; // List to hold enemy prefabs
    private GameObject selectedPrefab; // The chosen prefab

    private SpriteRenderer shapeSpriteRenderer;
    private Animator shapeAnimator;

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
        Health = 10;
        MaxHealth = Health;
        HUD.Setup(this);

        // Get the BackgroundManager reference
        backgroundManager = FindObjectOfType<BackgroundManager>();

        patrolPositions = GeneratePatrolPositions();

        // Initialize previousPosition with the starting position
        previousPosition = transform.position;

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
        time += Time.deltaTime;

        if (canPatrol)
        {
            MoveToPosition(patrolPositions[patrolPosIndex], movementSpeed);
            FaceMovementDirection();
        }

        var hit = Physics2D.OverlapCircle(transform.position, characterDetectionRange, characterLayer);
        if (hit)
        {
            hit.gameObject.GetComponent<CharacterController>().GetHit(damage);
        }

        previousPosition = transform.position;
    }

    List<Vector3> GeneratePatrolPositions()
    {
        Vector3 leftWallPos = backgroundManager.GetLeftWallPosition();
        Vector3 rightWallPos = backgroundManager.GetRightWallPosition();
        Vector3 topWallPos = backgroundManager.GetTopWallPosition();
        Vector3 bottomWallPos = backgroundManager.GetBottomWallPosition();

         bottomRight = new Vector3(
            Random.Range(0, rightWallPos.x - 1f),
            Random.Range(bottomWallPos.y + 1.5f, 0),
            0);

         bottomLeft = new Vector3(
            Random.Range(leftWallPos.x + 1f, 0),
            Random.Range(bottomWallPos.y + 1.5f, 0),
            0);

         topRight = new Vector3(
            Random.Range(0, rightWallPos.x - 1f),
            Random.Range(0, topWallPos.y - 1f),
            0);

         topLeft = new Vector3(
            Random.Range(leftWallPos.x + 1f, 0),
            Random.Range(0, topWallPos.y - 1f),
            0);

        transform.position = bottomRight;
        return new List<Vector3> { bottomRight, topRight, topLeft, bottomLeft };
    }

    void MoveToPosition(Vector3 targetPosition, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        CheckPatrolPositionReached();
    }

    void CheckPatrolPositionReached()
    {
        if (Vector3.Distance(transform.position, patrolPositions[patrolPosIndex]) <= 0.1f)
        {
            patrolPosIndex++;
            if (patrolPosIndex >= patrolPositions.Count)
            {
                patrolPosIndex = 0;
            }
        }
    }

    void FaceMovementDirection()
    {
        Vector3 movementDirection = transform.position - previousPosition;

        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movementDirection.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, characterDetectionRange);
    }
}
