using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    [SerializeField] bool canPatrol;
    [SerializeField] float characterDetectionRange;
    [SerializeField] int damage;
    [SerializeField] EnemyHUDController HUD;
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] LayerMask characterLayer;

    private List<Vector3> patrolPositions;
    private int patrolPosIndex = 0;
    private BackgroundManager backgroundManager;

    float time;
    private Vector3 previousPosition;

    private void Start()
    {
        MaxHealth = Health;
        HUD.Setup(this);

        // Get the BackgroundManager reference
        backgroundManager = FindObjectOfType<BackgroundManager>();

        patrolPositions = GeneratePatrolPositions();

        // Initialize previousPosition with the starting position
        previousPosition = transform.position;
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
        SceneManager.LoadScene(1);
        Destroy(gameObject);
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

    // Generate 4 patrol positions in the 4 quarters using wall positions
    List<Vector3> GeneratePatrolPositions()
    {
        // Get the wall positions from the BackgroundManager
        Vector3 leftWallPos = backgroundManager.GetLeftWallPosition();
        Vector3 rightWallPos = backgroundManager.GetRightWallPosition();
        Vector3 topWallPos = backgroundManager.GetTopWallPosition();
        Vector3 bottomWallPos = backgroundManager.GetBottomWallPosition();

        // Calculate the center points of each quarter based on wall positions
        Vector3 bottomRight = new Vector3(
            Random.Range(0, rightWallPos.x - 0.2f),
            Random.Range(bottomWallPos.y + 0.9f, 0),
            0);

        Vector3 bottomLeft = new Vector3(
            Random.Range(leftWallPos.x + 0.2f, 0),
            Random.Range(bottomWallPos.y + 0.2f, 0),
            0);

        Vector3 topRight = new Vector3(
            Random.Range(0, rightWallPos.x - 0.2f),
            Random.Range(0, topWallPos.y - 0.2f),
            0);

        Vector3 topLeft = new Vector3(
            Random.Range(leftWallPos.x + 0.2f, 0),
            Random.Range(0, topWallPos.y - 0.2f),
            0);

        // Return the patrol positions in order (starting from bottom-right)
        return new List<Vector3> { bottomRight, topRight, topLeft, bottomLeft };
    }

    // Moves the enemy towards the next patrol position
    void MoveToPosition(Vector3 targetPosition, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        CheckPatrolPositionReached();
    }

    // Check if the patrol position is reached and update the index accordingly
    void CheckPatrolPositionReached()
    {
        if (Vector3.Distance(transform.position, patrolPositions[patrolPosIndex]) <= 0.1f)
        {
            patrolPosIndex++;
            if (patrolPosIndex >= patrolPositions.Count)
            {
                patrolPosIndex = 0; // Loop back to the starting position (bottom-right)
            }
        }
    }

    void FaceMovementDirection()
    {
        // Calculate the direction of movement by checking the change in position
        Vector3 movementDirection = transform.position - previousPosition;

        if (movementDirection.x > 0) // Moving right
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movementDirection.x < 0) // Moving left
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
