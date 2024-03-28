using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour
{
    public float kills;

    public Text textkills;

    private void Start() {
        kills = 0;
    }

    private void Update() {
        textkills.text = kills.ToString();    
    }


}
