using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour
{
   public void LoadGame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
