using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to load the next scene 
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();


    }
}
