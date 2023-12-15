using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_2 : MonoBehaviour
{
    [SerializeField] GameObject menuOb;
    [SerializeField] GameObject tutorialOb;

    void Start()
    {
        UnloadTutorial();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Spel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadTutorial()
    {
        tutorialOb.SetActive(true);
        menuOb.SetActive(false);
    }

    public void UnloadTutorial()
    {
        tutorialOb.SetActive(false);
        menuOb.SetActive(true);
    }
}
