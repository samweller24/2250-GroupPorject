using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel2script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnTriggerEnter(Collider col){
         if(col.gameObject.tag == "Player"){
             SceneManager.LoadScene("SamLevel");
             DontDestroyOnLoad(col.gameObject);
             col.gameObject.transform.position = new Vector3(596.4005f,2.31f,716.5336f);
         }
}
}
