using System.Collections;
using Unity.MLAgents.Integrations.Match3;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    [SerializeField] ResultSaver resultSaver;
    [SerializeField] GameObject shape;
    [SerializeField] public float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float groundDetectionRange;
    [SerializeField] int damage;
    [SerializeField] public int health;
    [SerializeField] LayerMask groundMask;
    [SerializeField] int maxJumpCount;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] public float deathHeight;
    [SerializeField] Animator animator;
    [SerializeField] float maxFallingSpeed = -20f;
    [SerializeField] float limitFallingSpeed = -19.9f;
    [SerializeField] float cameraFallingSpeed = -5f;
    [SerializeField] float total_input;
    [SerializeField] public int max_health;
    [SerializeField] Projectile BulletPrefab;

    // Melee attack fields
    [SerializeField] Transform attackPoint;  
    [SerializeField] public float attackRange = 0.5f;
    [SerializeField] float attackAngle = 120f; 
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] PhysicsMaterial2D noFrictionMaterial;
    [SerializeField] PhysicsMaterial2D groundFrictionMaterial;
    [SerializeField] float rollSpeed = 5f;  
    [SerializeField] float speed_of_this_shit;  
    [SerializeField] float rollDuration = 0.4f;  
    [SerializeField] bool isRolling = false;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] public int scenario = 0;
    public int _jumpCount;
    public bool isOnGround;
    public bool isRight = true;
    public bool isHittable;
    public bool FreeFalling;
    public bool can_attack = true;
    [SerializeField] public bool can_update=true;
    void Start()
    {
        Start_function();
    }

    public void Start_function()
    {

        isHittable = true;
        health = max_health;
        can_attack = true;
        isHittable = true;
        isRight = true;
        _jumpCount = 0;
        isOnGround = true;
        var scale = shape.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        shape.transform.localScale = scale;
        Vector3 randomStartPosition = new Vector3();
        if (scenario == 0)
        {
            randomStartPosition = new Vector3(Random.Range(-7f, 7f), -2.9f, transform.position.z);
        }
        else if (scenario == 1)
        {
            randomStartPosition = new Vector3(-4f, -2.9f, transform.position.z);
        }
        else if (scenario == 2)
        {
            randomStartPosition = new Vector3(3f, -2.9f, transform.position.z);
        }
        else if (scenario == 3)
        {
            randomStartPosition = new Vector3(6.5f, -2.9f, transform.position.z);
        }
        else if (scenario == 4)
        {
            randomStartPosition = new Vector3(-5f, -2.9f, transform.position.z);
        }
        else if (scenario == 5)
        {
            randomStartPosition = new Vector3(0f, -2.9f, transform.position.z);
        }
        else if (scenario == 6)
        {
            randomStartPosition = new Vector3(1f, -2.9f, transform.position.z);
        }
        else if (scenario == 7)
        {
            randomStartPosition = new Vector3(-2f, -2.9f, transform.position.z);
        }
        else if (scenario == 8)
        {
            randomStartPosition = new Vector3(2f, -2.9f, transform.position.z);
        }
        else if (scenario == 9)
        {
            randomStartPosition = new Vector3(6f, -2.9f, transform.position.z);
        }
        else if (scenario == 10)
        {
            randomStartPosition = new Vector3(-6.5f, -2.9f, transform.position.z);
        }

        transform.position = randomStartPosition;
        if (randomStartPosition[0] > 0)
        {

        }

        HUDController.instance.Repaint(health, max_health);
    }

    void Update()
    {
        if (can_update)
        {

        CheckHeightDeath();
        CheckFreeFalling();
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        GroundDetection();
        //MoveLogic(horizontalInput);
        FlipCheck(horizontalInput);


        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
           MeleeAttack();
        }

        // Roll logic
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
      //   Roll();
        }
        GetFacingDirection();
        UpdateFriction();
        }

    }
    public void SetisHittable(bool value)
    {
        isHittable = value;
    }
    public int Return_HP_Player()
    {
        return health;
    }
    private void Shoot()
    {
        var projectile = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

        // Convert the direction to a Vector2
        Vector2 direction = isRight ? Vector2.right : Vector2.left;

        // Pass the Vector2 direction and damage to the Shoot method
      //  projectile.Shoot(direction, damage);
    }
    public void Roll()
    {
        if (!isRolling)
        {
            // Play attack animation
            animator.SetBool("is_rolling", true);
            isRolling = true;
            //// Determine the roll direction based on the character's facing direction
            //float rollDirection = transform.localScale.x; // Assuming positive scale.x means facing right

            //// Apply force for rolling
            //Vector2 rollForce = new Vector2(50f * rollDirection, 0f);
            //rigidbody2D.AddForce(rollForce, ForceMode2D.Impulse);

            //// Detect enemies in range of attack

            Invoke("ResetRollCooldown", 0.36f);
        }
    }
    private void ResetRollCooldown()
    {
        isRolling = false;
        animator.SetBool("is_rolling", false);

    }
    public void MeleeAttack()
    {
        if (can_attack)
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

        Invoke("ResetAttackCooldown", 0.3f);
        }
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
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);
        animator.SetBool("attack3", false);
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
        resultSaver.SaveSceneTime();
    }

    public void FlipCheck(float input)
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

    public void MoveLogic(float input)
    {
        FlipCheck(input);
        if (isRolling)
        {
            int current_Direction = 1;
            if (!isRight)
            {
                current_Direction = -1;
            }
         
            var v = rigidbody2D.velocity;
            v.x = current_Direction * movementSpeed * 2;
            rigidbody2D.velocity = new Vector2(v.x, rigidbody2D.velocity.y);
        }
        else
        {
            total_input = input;
            animator.SetBool("IsMoving", Mathf.Abs(input) > 0);
            var v = rigidbody2D.velocity;
            v.x = input * movementSpeed;
            rigidbody2D.velocity = new Vector2(v.x, rigidbody2D.velocity.y);
        }

    }

    public void Jump()
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
