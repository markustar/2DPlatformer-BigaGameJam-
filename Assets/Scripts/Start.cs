using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public GameObject PanelOfSettings;
    public GameObject PanelOfCreators;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Settings()
    {
        PanelOfSettings.SetActive(true);
    }
    public void Creators()
    {
        PanelOfCreators.SetActive(true);
    }

    public void Back()
    {
        PanelOfCreators.SetActive(false);
        PanelOfSettings.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
