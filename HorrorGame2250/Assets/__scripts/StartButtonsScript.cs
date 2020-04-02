using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsScript : MonoBehaviour
{
    //Loads the next scene
    public void LoadPlayerSelect()
    {
        SceneManager.LoadScene("playerSelect");
    }

    //quits applications if desired
    public void QuitGame()
    {
        Application.Quit();
    }
}
