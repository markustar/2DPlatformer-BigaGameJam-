using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items; // An array of items to drop from the chest
    public Transform[] chestSpawnPoints; // An array of possible chest spawn points
    public int enemyKilledThreshold = 5; // Number of enemies to be killed before spawning a chest
    public int enemyKilled = 0;
    public GameObject chestPrefab;

    private bool chestSpawned = false;

    private void Update()
    {
        // Check if the enemykilled threshold is met and a chest hasn't been spawned yet
        if (!chestSpawned && enemyKilled >= enemyKilledThreshold)
        {
            SpawnChestRandomly();
            chestSpawned = true; // Set to true so it doesn't spawn more than once
        }
    }

    private void SpawnChestRandomly()
    {
        if (items.Length > 0 && chestSpawnPoints.Length > 0 && enemyKilled >= enemyKilledThreshold)
        {
            int randomIndex = Random.Range(0, chestSpawnPoints.Length);
            Transform selectedSpawnPoint = chestSpawnPoints[randomIndex];

            int randomItemIndex = Random.Range(0, items.Length);
            GameObject selectedItem = items[randomItemIndex];

            enemyKilled = 0;

            // Instantiate the selected item at the random spawn point
            Instantiate(chestPrefab, selectedSpawnPoint.position, Quaternion.identity);
            
            // Reset the enemyKilled count to 0 only when a chest spawns
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        if (items.Length > 0)
        {
            int randomIndex = Random.Range(0, items.Length);
            GameObject selectedItem = items[randomIndex];

            // Instantiate the selected item at the chest's position
            Instantiate(selectedItem, transform.position, Quaternion.identity);

            // Optionally, you can destroy the chest after it's been opened
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("The chest does not contain any items.");
        }
    }
}
