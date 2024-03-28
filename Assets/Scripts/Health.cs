using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxhealth = 100;

    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
        if (health <= 0)
        {
            StartCoroutine(ReloadSceneAfterDelay(0.2f));
        }
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        if(this.gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
