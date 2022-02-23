using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level 0", LoadSceneMode.Single);
    }
    public void Menu()
    {
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit"); 
    }
}
