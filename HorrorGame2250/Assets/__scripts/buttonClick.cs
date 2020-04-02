using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonClickClass : MonoBehaviour
{
    //controls yes button
    public Button yes;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        //if yes is clicked, load game
        Button btn = yes.GetComponent<Button>();
		btn.onClick.AddListener(LoadGame);
    }

    //function that loads game
    void LoadGame(){
         SceneManager.LoadScene("MainLevel");
    }

    //wuits game if chosen
    void QuitGame()
    {
        Application.Quit();
    }
}
