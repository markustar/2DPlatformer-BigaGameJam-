using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Health health;
    public GameObject press;
    public bool playerIN;
    public GameObject distrik;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R) && playerIN == true)
        {
            health.health += 30;
            Destroy(distrik);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            press.SetActive(true);
            playerIN = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            press.SetActive(false);
            playerIN = false;
        }
    }
}
