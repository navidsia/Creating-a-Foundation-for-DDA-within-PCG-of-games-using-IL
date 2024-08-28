using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeDuration;
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] float detectionRadius;

    bool hasShot;
    float _duration;
    Vector2 _direction;
    int _damage;

    public void Shoot(Vector2 direction, int damage)
    {
        hasShot = true;
        _duration = lifeDuration;
        _direction = direction;
        _damage = damage;
        gameObject.layer = 7;

    }

    private void Update()
    {
        if (!hasShot)
            return;

        Move();

        var hit = Physics2D.OverlapCircle(transform.position, detectionRadius, detectionLayer);
        if (hit)
        {
            if (hit.gameObject.TryGetComponent<CharacterController>(out var charachter))
            {
                charachter.GetHit(_damage);
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

    private void Move()
    {
        var pos = transform.position;
        pos += (Vector3)_direction * speed * Time.deltaTime;
        transform.position = pos;
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
