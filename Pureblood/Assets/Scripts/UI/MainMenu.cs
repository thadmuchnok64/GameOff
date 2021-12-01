using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsObject;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditsObject.SetActive(true);
    }


    public void StartGame()
    {

        SceneManager.LoadScene("Arcdenn");

    }




}
