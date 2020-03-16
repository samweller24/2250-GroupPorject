using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour
{
    public Button yes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Button btn = yes.GetComponent<Button>();
		btn.onClick.AddListener(LoadGame);
    }

    void LoadGame(){
         SceneManager.LoadScene("MainArea");
    }
}
