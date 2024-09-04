using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    [SerializeField] bool canPatrol;
    [SerializeField] List<PatrolMovement> patrolPositions;
    [SerializeField] LayerMask characterLayer;
    [SerializeField] float characterDetectionRange;
    [SerializeField] int damage;
    [SerializeField] EnemyHUDController HUD;
    List<Vector3> patrolPositionCopy;
    int patrolPosIndex = 0;

    float time;
    private Vector3 previousPosition;

    private void Start()
    {
        MaxHealth = Health;
        HUD.Setup(this);
        patrolPositionCopy = new List<Vector3>();
        foreach (PatrolMovement t in patrolPositions)
        {
            patrolPositionCopy.Add(new Vector3(t.patrolPosition.position.x, t.patrolPosition.position.y,
                t.patrolPosition.position.z));
        }

        // Initialize previousPosition with the starting position
        previousPosition = transform.position;
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
        Destroy(gameObject);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (canPatrol)
        {
            MoveToPosition(patrolPositionCopy[patrolPosIndex], patrolPositions[patrolPosIndex].duration);
            FaceMovementDirection(); // Check and update facing direction
        }

        var hit = Physics2D.OverlapCircle(transform.position, characterDetectionRange, characterLayer);
        if (hit)
        {
            hit.gameObject.GetComponent<CharacterController>().GetHit(damage);
        }

        // Update the previous position for the next frame
        previousPosition = transform.position;
    }

    void MoveToPosition(Vector3 pos, float duration)
    {
        var t = duration;
        var prevIndex = patrolPosIndex - 1;
        if (patrolPosIndex < 1)
        {
            prevIndex = patrolPositionCopy.Count - 1;
        }
        var newPos = Vector3.Lerp(patrolPositionCopy[prevIndex], pos, time / t);
        transform.position = newPos;
        CheckPatrolPositionReached();
    }

    void CheckPatrolPositionReached()
    {
        if (Vector3.Distance(patrolPositionCopy[patrolPosIndex], transform.position) <= 0.1f)
        {
            patrolPosIndex++;
            if (patrolPosIndex >= patrolPositionCopy.Count)
            {
                patrolPosIndex = 0;
            }
            time = 0;
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

[System.Serializable]
class PatrolMovement
{
    public Transform patrolPosition;
    public float duration;
}
