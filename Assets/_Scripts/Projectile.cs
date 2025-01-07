using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeDuration;
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] float detectionRadius;
    [SerializeField] bool not_weighted = true;
    [SerializeField] bool rounded = true;
    [SerializeField] Enemy enemy;
    bool hasShot;
    float _duration;
    int _damage;
    Rigidbody2D _rigidbody;
    Coroutine rotationCoroutine;
    int rotationDirection; // -1 for left (counterclockwise), 1 for right (clockwise)

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void set_enemy(GameObject enemy_input)
    {
        enemy = enemy_input.GetComponent<Enemy>();
    }
    public void Shoot(Vector2 direction, float speed, int damage)
    {
        hasShot = true;
        _duration = 0;
        _damage = damage;
        gameObject.layer = 7;

        // Set the velocity of the Rigidbody2D based on the direction and speed
        _rigidbody.velocity = direction * speed;

        // Optional: Disable gravity if you want a non-weighted projectile
        if (not_weighted)
        {
            _rigidbody.gravityScale = 0;
        }

        // Randomly choose rotation direction (50% chance for clockwise or counterclockwise)
        rotationDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        // Start the rotation coroutine
        if (rounded)
        {
            rotationCoroutine = StartCoroutine(RotateProjectile());
        }



    }

    private void Update()
    {
        if (!hasShot)
            return;

        var hit = Physics2D.OverlapCircle(transform.position, detectionRadius, detectionLayer);
        if (hit)
        {
            if (hit.gameObject.TryGetComponent<CharacterController>(out var character))
            {
                character.GetHit(_damage);
            }
            Die();
            return;
        }

        if (_duration < lifeDuration)
        {
            _duration += Time.deltaTime;
        }
        else
        {
            Die();
        }
    }

    IEnumerator RotateProjectile()
    {
        while (true)
        {
            // Rotate the projectile based on the chosen direction
            transform.Rotate(0, 0, 15 * rotationDirection);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Die()
    {
        // Stop rotation when the projectile is destroyed
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
