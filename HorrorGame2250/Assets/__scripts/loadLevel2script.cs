using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel2script : MonoBehaviour
{

        // when the trigger is hit, this function covers spawnning the character to the next level
     public void OnTriggerEnter(Collider col){
         if(col.gameObject.tag == "Player"){
             SceneManager.LoadScene("SamLevel");
             //this keeps characeter instance so progression is kept
             DontDestroyOnLoad(col.gameObject);
         
             //sets character to position desired on spawn
             col.gameObject.transform.position = new Vector3(596.4005f,2.31f,716.5336f);
         }
}
}
