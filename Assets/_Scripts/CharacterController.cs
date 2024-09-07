using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] GameObject shape;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float groundDetectionRange;
    [SerializeField] int damage;
    [SerializeField] int health;
    [SerializeField] LayerMask groundMask;
    [SerializeField] int maxJumpCount;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float deathHeight;
    [SerializeField] Animator animator;
    [SerializeField] float maxFallingSpeed = -20f;
    [SerializeField] float limitFallingSpeed = -19.9f;
    [SerializeField] float cameraFallingSpeed = -5f;
    [SerializeField] float total_input;
    [SerializeField] int max_health;
    [SerializeField] Projectile BulletPrefab;

    // Melee attack fields
    [SerializeField] Transform attackPoint;  // Point from where melee attack originates
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float attackAngle = 120f; // Attack angle in degrees
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] PhysicsMaterial2D noFrictionMaterial;
    [SerializeField] PhysicsMaterial2D groundFrictionMaterial;

    Rigidbody2D rigidbody2D;
    int _jumpCount;
    public bool isOnGround;
    bool isRight = true;
    bool isHittable;
    public bool FreeFalling;
    public bool can_attack = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isHittable = true;
    }

    void Update()
    {
        CheckHeightDeath();
        CheckFreeFalling();
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        GroundDetection();
        MoveLogic(horizontalInput);
        FlipCheck(horizontalInput);
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
            //Shoot();
        }
        UpdateFriction();
    }
    private void Shoot()
    {
        var projectile = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

        // Convert the direction to a Vector2
        Vector2 direction = isRight ? Vector2.right : Vector2.left;

        // Pass the Vector2 direction and damage to the Shoot method
      //  projectile.Shoot(direction, damage);
    }

    private void MeleeAttack()
    {
        // Play attack animation
        int which_attack = Random.Range(1, 4);
        animator.SetBool("attack"+ which_attack.ToString(), true);

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 directionToEnemy = enemy.transform.position - attackPoint.position;
            float angleBetween = Vector2.Angle(GetFacingDirection(), directionToEnemy);

            if (angleBetween <= attackAngle / 2)
            {
                enemy.GetComponent<Enemy>().GetHit(damage);
            }
        }

        can_attack = false;
        Invoke("StopAttack", 0.04f);
        Invoke("ResetAttackCooldown", 0.3f);
    }

    private Vector2 GetFacingDirection()
    {
        return isRight ? Vector2.right : Vector2.left;
    }

    private void StopAttack()
    {
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);
        animator.SetBool("attack3", false);
    }

    private void ResetAttackCooldown()
    {
        can_attack = true;
    }

    private void CheckHeightDeath()
    {
        if (transform.position.y < deathHeight)
            Die();
    }

    public void GetHit(int damage)
    {
        if (!isHittable)
            return;

        if (health <= 0)
            return;

        health -= damage;

        if (health <= 0)
            Die();
        else
            StartInvulnerability();

        HUDController.instance.Repaint(health, max_health);
    }

    private void StartInvulnerability()
    {
        isHittable = false;
        animator.SetBool("Hurt", true);
        Invoke("StopInvulnerabilityAnimation", 0.05f);
        Invoke("StopInvulnerability", 1f);
    }

    private void StopInvulnerability()
    {
        animator.SetBool("Hurt", false);
        isHittable = true;
    }

    private void StopInvulnerabilityAnimation()
    {
        animator.SetBool("Hurt", false);
    }

    private void Die()
    {
        SceneManager.LoadScene(1);
    }

    private void FlipCheck(float input)
    {
        if (input < 0 && isRight)
            Flip();
        else if (input > 0 && !isRight)
            Flip();
    }

    private void Flip()
    {
        var scale = shape.transform.localScale;
        scale.x *= -1;
        shape.transform.localScale = scale;
        isRight = !isRight;
    }

    private void GroundDetection()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRange, groundMask);
        if (!isOnGround && hit)
        {
            _jumpCount = 0;
            animator.SetBool("is_jumping", false);
        }
        isOnGround = hit;
        animator.SetBool("is_on_ground", hit);
    }

    private void MoveLogic(float input)
    {
        total_input = input;
        animator.SetBool("IsMoving", Mathf.Abs(input) > 0);
        var v = rigidbody2D.velocity;
        v.x = input * movementSpeed;
        rigidbody2D.velocity = new Vector2(v.x, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (_jumpCount >= maxJumpCount)
            return;
        animator.SetBool("is_jumping", true);
        var v = rigidbody2D.velocity;
        v.y = jumpForce;
        rigidbody2D.velocity = v;
        _jumpCount++;
    }

    private void CheckFreeFalling()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            animator.SetBool("is_falling", true);
        }
        else
        {
            animator.SetBool("is_falling", false);
        }
        if (rigidbody2D.velocity.y < cameraFallingSpeed)
        {
            FreeFalling = true;
        }
        if (rigidbody2D.velocity.y < limitFallingSpeed)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxFallingSpeed);
        }
        else
        {
            FreeFalling = false;
        }
    }

    private void UpdateFriction()
    {
        if (isOnGround)
        {
            rigidbody2D.sharedMaterial = groundFrictionMaterial;
        }
        else
        {
            rigidbody2D.sharedMaterial = noFrictionMaterial;
        }
    }

    // Draw the attack range in the Unity Editor
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;

        // Draw attack sector
        int segments = 30; // Number of segments to draw the sector
        float angleStep = attackAngle / segments;
        float startAngle = -attackAngle / 2;

        Vector2 facingDirection = GetFacingDirection();
        float baseAngle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;

        Vector3 previousPoint = attackPoint.position;

        for (int i = 0; i <= segments; i++)
        {
            float currentAngle = baseAngle + startAngle + angleStep * i;
            float rad = currentAngle * Mathf.Deg2Rad;
            Vector3 newPoint = attackPoint.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * attackRange;
            if (i > 0)
            {
                Gizmos.DrawLine(previousPoint, newPoint);
            }
            previousPoint = newPoint;
        }

        // Draw lines from attack point to edges
        float leftAngle = baseAngle + startAngle;
        float rightAngle = baseAngle + startAngle + attackAngle;

        Vector3 leftPoint = attackPoint.position + new Vector3(Mathf.Cos(leftAngle * Mathf.Deg2Rad), Mathf.Sin(leftAngle * Mathf.Deg2Rad), 0) * attackRange;
        Vector3 rightPoint = attackPoint.position + new Vector3(Mathf.Cos(rightAngle * Mathf.Deg2Rad), Mathf.Sin(rightAngle * Mathf.Deg2Rad), 0) * attackRange;

        Gizmos.DrawLine(attackPoint.position, leftPoint);
        Gizmos.DrawLine(attackPoint.position, rightPoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDetectionRange);
    }
}
