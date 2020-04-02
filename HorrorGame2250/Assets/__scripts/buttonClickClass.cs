using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour
{
    //loads game on button click
   public void LoadGame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
