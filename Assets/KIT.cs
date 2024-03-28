using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIT : MonoBehaviour
{
    public Health health;
    public GameObject press;
    public bool playerIN;
    public GameObject distrik;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R) && playerIN == true)
        {
            health.health = health.maxhealth;
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
