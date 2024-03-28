using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private coins coin;
    private Chest chest;
   void OnDestroy()
    {

        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveLogic>().spawnedEnemies.Remove(gameObject);
        }
        if (GameObject.FindGameObjectWithTag("Coins") != null)
        {
            GameObject.FindGameObjectWithTag("Coins").GetComponent<coins>().kills += 1;
        }
        if (GameObject.FindGameObjectWithTag("Chest") != null)
        {
            GameObject.FindGameObjectWithTag("Chest").GetComponent<Chest>().enemyKilled += 1;
        }
     
    }
}
