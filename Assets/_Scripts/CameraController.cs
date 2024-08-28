using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 offset;
    [SerializeField] Transform target;
    [SerializeField] CharacterController characterController;
    [SerializeField] float smoothSpeed = 2f; // Speed at which the camera moves towards the target Y position
    [SerializeField] bool boss_room = false;
    void Start()
    {
        if (characterController == null)
        {
            Debug.LogError("CharacterController is not assigned in the CameraController script.");
        }

        if (target == null)
        {
            Debug.LogError("Target is not assigned in the CameraController script.");
        }
    }

    void Update()
    {
        if (!boss_room)
        {
            if (target == null || characterController == null)
                return;

            Vector3 pos = target.position;
            pos.x += offset.x;

            if (characterController.isOnGround)
            {
                // Smoothly transition the camera's Y position to the character's Y position
                pos.y = Mathf.Lerp(transform.position.y, target.position.y + 2, smoothSpeed * Time.deltaTime);
                offset.y = pos.y;
            }
            else if (characterController.FreeFalling)
            {
                pos.y = Mathf.Lerp(transform.position.y, target.position.y, smoothSpeed * 4 * Time.deltaTime);
                offset.y = pos.y;
            }
            else
            {
                // Set the Y position to the offset Y
                pos.y = offset.y;
            }

            pos.z = -10;
            transform.position = pos;
        }
    }

}
