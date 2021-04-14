using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadGame()
    {
        Handheld.Vibrate();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Handheld.Vibrate();
        Application.Quit(); 
    }

    public void NewGame()
    {
        Handheld.Vibrate();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Menu()
    {
        Handheld.Vibrate();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }



}
