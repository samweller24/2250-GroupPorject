using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsScript : MonoBehaviour
{
    public void LoadPlayerSelect()
    {
        SceneManager.LoadScene("playerSelect");
    }
}
