using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 20f; // Add a turn speed for rotation

    private Vector3 targetPosition;
    private bool isMoving = false; // Flag to check if the character should move

    void Start()
    {
        // Initialize the target position to the current position
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // On mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SetTargetPosition(hit.point);
                Debug.Log("Moving to: " + targetPosition); // To confirm click detection
            }
        }

        if (isMoving)
        {
            MoveCharacter();
        }
    }

    void SetTargetPosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
        isMoving = true;
    }

    void MoveCharacter()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the character has reached the target position
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
        else
        {
            // Calculate the direction to turn towards
            Vector3 direction = (targetPosition - transform.position).normalized;
            // Calculate the rotation we should be in to look at the target
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // Rotate over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
    }
}

