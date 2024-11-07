using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class CharacterAgent : Agent
{
    private CharacterController characterController;
    private Rigidbody2D agentRigidbody;
    private bool isRight = true;
    private int jumpCount = 0;
    public float movementSpeed = 5f;

    [SerializeField] private Transform Enemy;
    [SerializeField] GameObject Left_wall;
    [SerializeField] GameObject Right_wall;
    [SerializeField] GameObject Top_wall;
    [SerializeField] GameObject Buttom_wall;

    private List<int> recordedActions = new List<int>(); // To store user actions
    private int actionIndex = 0; // To track which action to take from recorded actions

    public override void Initialize()
    {
        characterController = GetComponent<CharacterController>();
        agentRigidbody = GetComponent<Rigidbody2D>();

        GameObject enemyObject = GameObject.FindWithTag("Enemy");
        if (enemyObject != null)
        {
            Enemy = enemyObject.transform;  // Set Enemy as the transform of the enemy
        }
        else
        {
            Debug.LogError("Enemy object not found. Make sure the enemy has the correct tag.");
        }
    }

    public override void OnEpisodeBegin()
    {
        // Reset position and health
        if (transform.position.y < -5f)
        {
            characterController.health = characterController.max_health;
            transform.position = new Vector2(0, 0); // Reset position
            agentRigidbody.velocity = Vector2.zero;
        }
        jumpCount = 0;
        actionIndex = 0; // Reset action index at the beginning of an episode
        recordedActions.Clear(); // Clear recorded actions
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(agentRigidbody.position.x);
        sensor.AddObservation(agentRigidbody.position.y);
        sensor.AddObservation(agentRigidbody.velocity.x);
        sensor.AddObservation(agentRigidbody.velocity.y);
        sensor.AddObservation(characterController.isOnGround);
        sensor.AddObservation(characterController.health);
        sensor.AddObservation(isRight);

        if (Enemy != null)
        {
            sensor.AddObservation(Enemy.position.x);
            sensor.AddObservation(Enemy.position.y);
        }

        sensor.AddObservation(Left_wall.transform.position.x);
        sensor.AddObservation(Right_wall.transform.position.x);
        sensor.AddObservation(Buttom_wall.transform.position.y + 0.5f);
        sensor.AddObservation(Top_wall.transform.position.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int movementAction = actions.DiscreteActions[0];
        int jumpAction = actions.DiscreteActions[1];
        int attackAction = actions.DiscreteActions[2];
        int dashAction = actions.DiscreteActions[3];

        // Record actions for mimicry if not yet fully recorded
        if (recordedActions.Count < 400) // Limit recording to a certain number of actions (100 * 4 for 4 actions)
        {
            recordedActions.Add(movementAction);
            recordedActions.Add(jumpAction);
            recordedActions.Add(attackAction);
            recordedActions.Add(dashAction);
        }

        // Mimic user movements during training, if recorded actions exist
        if (actionIndex < recordedActions.Count)
        {
            // Retrieve recorded actions based on the current action index
            movementAction = recordedActions[actionIndex++];
            if (actionIndex < recordedActions.Count) jumpAction = recordedActions[actionIndex++];
            if (actionIndex < recordedActions.Count) attackAction = recordedActions[actionIndex++];
            if (actionIndex < recordedActions.Count) dashAction = recordedActions[actionIndex++];
        }

        // Movement logic
        float moveInput = 0f;
        switch (movementAction)
        {
            case 0:
                moveInput = -1f; // Move left
                break;
            case 1:
                moveInput = 0f; // Idle
                break;
            case 2:
                moveInput = 1f; // Move right
                break;
        }

        // Move agent
      //  agentRigidbody.velocity = new Vector2(moveInput * movementSpeed, agentRigidbody.velocity.y);

        // Perform jump if requested
        if (jumpAction == 1 && characterController.isOnGround)
        {
            characterController.Jump();
            jumpCount++;
        }

        // Perform dash if requested
        if (dashAction == 1)
        {
            characterController.Roll();
        }

        // Handle attacking
        if (attackAction == 1)
        {
            characterController.MeleeAttack();
            AddReward(1.0f); // Reward for a successful attack
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = 1; // Default action (no movement)
        discreteActions[1] = 0; // Default jump
        discreteActions[2] = 0; // Default attack
        discreteActions[3] = 0; // Default dash

        if (Input.GetKey(KeyCode.D))
        {
            discreteActions[0] = 2; // Move right
        }
        else if (Input.GetKey(KeyCode.A))
        {
            discreteActions[0] = 0; // Move left
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            discreteActions[1] = 1; // Jump
        }

        if (Input.GetMouseButtonDown(0))
        {
            discreteActions[2] = 1; // Attack
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            discreteActions[3] = 1; // Dash
        }
    }
}
