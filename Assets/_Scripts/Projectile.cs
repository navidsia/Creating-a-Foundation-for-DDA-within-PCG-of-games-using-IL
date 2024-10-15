using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeDuration;
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] float detectionRadius;
    [SerializeField] bool not_weighted = true;

    bool hasShot;
    float _duration;
    int _damage;
    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, float speed, int damage)
    {
        hasShot = true;
        _duration = lifeDuration;
        _damage = damage;
        gameObject.layer = 7;

        // Set the velocity of the Rigidbody2D based on the direction and speed
        _rigidbody.velocity = direction * speed;

        // Optional: Disable gravity if you want a non-weighted projectile
        if (not_weighted)
        {
            _rigidbody.gravityScale = 0;
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

        if (_duration > 0)
        {
            _duration -= Time.deltaTime;
            if (_duration <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
