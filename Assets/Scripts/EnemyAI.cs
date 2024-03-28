using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int damageAmount = 5;  // Amount of damage to apply to the player.
    public float damageInterval = 2f;  // Time interval between damage ticks.
    
    private bool playerInsideZone;  // To track if the player is inside the zone.
    private float nextDamageTime;  // To track when the next damage tick should occur.

    private void Start()
    {
        nextDamageTime = Time.time + damageInterval;  // Set the initial time for damage.
    }

    private void Update()
    {
        if (playerInsideZone && Time.time >= nextDamageTime)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health -= damageAmount;
            }
            nextDamageTime = Time.time + damageInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = false;
        }
    }

}

