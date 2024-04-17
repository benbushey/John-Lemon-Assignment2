using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public float fieldOfViewAngle = 45.0f; // Degrees

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (player != null)
        {
            // Draw a line directly to the player.
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, player.position);

            // Draw the field of view lines.
            Gizmos.color = Color.blue;
            Vector3 rightFOVLine = Quaternion.Euler(0, fieldOfViewAngle, 0) * transform.forward * 5; // 5 is the length of the line.
            Vector3 leftFOVLine = Quaternion.Euler(0, -fieldOfViewAngle, 0) * transform.forward * 5;

            Gizmos.DrawLine(transform.position, transform.position + rightFOVLine);
            Gizmos.DrawLine(transform.position, transform.position + leftFOVLine);

            // Optionally, use the dot product to determine if the player is within the FOV and change color accordingly
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float dotProduct = Vector3.Dot(directionToPlayer, transform.forward);
            float cosThreshold = Mathf.Cos(fieldOfViewAngle * Mathf.Deg2Rad);

            if (dotProduct > cosThreshold)
            {
                // Player is within the FOV
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, player.position);
            }
        }
    }
}