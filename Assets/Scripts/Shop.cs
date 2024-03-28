using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Color buttonColor;
    public Text change;
    public Button button;
    public GameObject Light;
    public Text priseText;
    public Health healthS;
    public Gun gun;
    public float prise;
    public coins coin;
    public GameObject Panel;
    private float changeprise = 1.5f;
    public Movement move;

    private void Start()
    {
        changeprise = 1.5f;
    }

    private void Update()
    {
        priseText.text = prise.ToString();
    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        Panel.SetActive(true);
    }

    public void CloseShop()
    {
        Time.timeScale = 1;
        Panel.SetActive(false);
    }

    public void UpgradeHealth()
    {
        if (coin.kills >= prise)
        {
            healthS.maxhealth += 20;
            healthS.health = healthS.maxhealth;
            coin.kills -= prise;
            GetUpgradePrise();
        }
    }

    public void UpgradeGun()
    {
        if (coin.kills >= prise)
        {
            gun.damageEnemy += 10;
            coin.kills -= prise;
            GetUpgradePrise();
        }
    }

    public void BuyLights()
    {
        if (coin.kills >= prise)
        {
            change.text = "PURCHASED";
            Destroy(priseText);
            
            // Access the Image component and set its color
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = buttonColor;
            }
            
            Light.SetActive(true);
            coin.kills -= prise;
            button.interactable = false;
        }
    }

    public void DoubleJump()
    {
        if (coin.kills >= prise)
        {
            change.text = "PURCHASED";
            Destroy(priseText);
            
            // Access the Image component and set its color
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = buttonColor;
            }
            
            move.doubleJumpEnabled = true;
            coin.kills -= prise;
            button.interactable = false;
        }
    }

    private void GetUpgradePrise()
    {
        prise *= changeprise;
        if (healthS.maxhealth == 120 || gun.damageEnemy == 30)
        {
            changeprise = 2f;
        }
    }
}
