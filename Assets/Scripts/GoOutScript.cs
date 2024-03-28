using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOutScript : MonoBehaviour
{
    public Transform player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the player's current position
            Vector3 currentPlayerPosition = player.transform.position;

            // Invert the x-coordinate to move to the opposite side
            currentPlayerPosition.x *= -1;

            // Assign the new position to the player
            player.transform.position = currentPlayerPosition;
        }
    }
}
