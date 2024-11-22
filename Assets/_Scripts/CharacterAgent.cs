using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System.Collections.Generic;

public class CharacterAgent : Agent
{
    private CharacterController characterController;
    private Rigidbody2D agentRigidbody;
    public float movementSpeed = 5f;

    [SerializeField] private Transform Enemy;
    [SerializeField] GameObject Left_wall;
    [SerializeField] GameObject Right_wall;
    [SerializeField] GameObject Top_wall;
    [SerializeField] GameObject Bottom_wall;
    [SerializeField] bool can_move=true;
    [SerializeField] public List<GameObject> bullets;
    public override void Initialize()
    {
        Start_function();
    }
    public void Start_function()
    {
        characterController = GetComponent<CharacterController>();
        agentRigidbody = GetComponent<Rigidbody2D>();

        GameObject enemyObject = GameObject.FindWithTag("Enemy");
        if (enemyObject != null)
        {
            Enemy = enemyObject.transform;
        }
        else
        {
            Debug.LogError("Enemy object not found. Make sure the enemy has the correct tag.");
        }
    }
    public void SetCan_Move(bool value)
    {
        can_move = value;
    }
    public override void OnEpisodeBegin()
    {
        // Reset position and state
        if (transform.position.y < -5f)
        {
            characterController.health = characterController.max_health;
            transform.position = new Vector2(0, 0); // Reset position
            agentRigidbody.velocity = Vector2.zero;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Add basic observations
        sensor.AddObservation(agentRigidbody.position.x);
        sensor.AddObservation(agentRigidbody.position.y);
        sensor.AddObservation(agentRigidbody.velocity.x);
        sensor.AddObservation(agentRigidbody.velocity.y);
        sensor.AddObservation(characterController.isOnGround);
        sensor.AddObservation(characterController.health);

        if (Enemy != null)
        {
            sensor.AddObservation(Enemy.position.x);
            sensor.AddObservation(Enemy.position.y);
        }

        sensor.AddObservation(Left_wall.transform.position.x);
        sensor.AddObservation(Right_wall.transform.position.x);
        sensor.AddObservation(Bottom_wall.transform.position.y);
        sensor.AddObservation(Top_wall.transform.position.y);

        // Clean up null bullets from the list
        bullets.RemoveAll(bullet => bullet == null);

        // Add observations for the nearest 20 bullets
        List<GameObject> validBullets = new List<GameObject>(bullets);
        validBullets.Sort((a, b) =>
        {
            float distA = Vector2.Distance(agentRigidbody.position, a.transform.position);
            float distB = Vector2.Distance(agentRigidbody.position, b.transform.position);
            return distA.CompareTo(distB);
        });

        for (int i = 0; i < 20; i++)
        {
            if (i < validBullets.Count)
            {
                var bulletRigidbody = validBullets[i].GetComponent<Rigidbody2D>();
                if (bulletRigidbody != null)
                {
                    sensor.AddObservation(bulletRigidbody.position.x);
                    sensor.AddObservation(bulletRigidbody.position.y);
                    sensor.AddObservation(bulletRigidbody.velocity.x);
                    sensor.AddObservation(bulletRigidbody.velocity.y);
                }
            }
            else
            {
                // Add default observations if there are fewer than 20 bullets
                sensor.AddObservation(0f); // Position x
                sensor.AddObservation(0f); // Position y
                sensor.AddObservation(0f); // Velocity x
                sensor.AddObservation(0f); // Velocity y
            }

        }
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        if (can_move)
        {

       
        int movementLeft = actions.DiscreteActions[0];
        int movementRight = actions.DiscreteActions[1];
        int jumpAction = actions.DiscreteActions[2];
        int attackAction = actions.DiscreteActions[3];
        int dashAction = actions.DiscreteActions[4];

        // Movement logic
        //   float moveInput = 0f;
        //   switch (movementAction)
        //   {
        //       case 0:
        //           moveInput = -1f; // Move left
        //           break;
        //       case 1:
        //           moveInput = 0f; // Idle
        //           break;
        //       case 2:
        //           moveInput = 1f; // Move right
        //           break;
        //   }

        // Move agent
        //  agentRigidbody.velocity = new Vector2(moveInput * movementSpeed, agentRigidbody.velocity.y);

        // Perform jump if requested

        if (movementLeft == 1  && movementRight == 0)
        {
            characterController.MoveLogic(1);
        }

        if (movementRight == 1 && movementLeft == 0)
        {
            characterController.MoveLogic(-1);
        }
        if (movementRight == 0 && movementLeft == 0)
        {
            characterController.MoveLogic(0);
        }


        if (jumpAction == 1)
        {
            characterController.Jump();
        }

        // Perform dash if requested
        if (dashAction == 1)
        {
          //  characterController.Roll();
        }

        // Handle attacking
        if (attackAction == 1)
        {
            characterController.MeleeAttack();
        }
    }
}

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = 0; // Default action (no left)
        discreteActions[1] = 0; // Default action (no right)
        discreteActions[2] = 0; // Default jump
        discreteActions[3] = 0; // Default attack
        discreteActions[4] = 0; // Default dash

        // Use independent if statements
        if (Input.GetKey(KeyCode.D))
        {
            discreteActions[0] = 1; // Move right
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            discreteActions[1] = 1; // Move left
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            discreteActions[2] = 1; // Jump
        }

        if (Input.GetMouseButtonDown(0))
        {
            discreteActions[3] = 1; // Attack
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
        //    discreteActions[4] = 1; // Dash
        }

    }

}
