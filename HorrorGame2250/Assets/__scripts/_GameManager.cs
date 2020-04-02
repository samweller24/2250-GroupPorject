using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    //static instance for gamemanager to be loaded in all scenes
    public static _GameManager instance;


    //static player attributes
   public int score = 0;
   public int health = 100;
   public bool playerDied;

    //UI displays for player
    public Text scoreText;
    public Text healthText;
    public Text sceneText;

    //scene variable to track scene/level
   public Scene m_Scene;

    //makes a singleton that controls the entire game 
   private void MakeSingleton(){
       if(instance != null){
            Destroy(gameObject);
       } else {
           instance = this;
           DontDestroyOnLoad(gameObject);
       }
   }

    //whenfirst loaded
   void Awake(){
       MakeSingleton();
       SceneManage();
        
   }

    //update function, contsantly calls checking fucntions
   void Update(){
    SceneManage();
    UpdateHealth();
    UpdateScore();
   }

    //function to get and update health of player
   void UpdateHealth(){
      health = CharacterController.health;
      healthText.text = "Health: "+health+"";
   }

    //function to get and update score of player
    void UpdateScore(){
      score = CharacterController.score;
      scoreText.text = "Score: "+score+"";
   }

//function that controls setting scene displays
   void SceneManage(){
       m_Scene = SceneManager.GetActiveScene();

        //level 4
       if(m_Scene.name == "MainLevel"){
           sceneText.text = "Level 1: The Forest";
           scoreText.text = "Score: "+score+"";
           healthText.text = "Health: "+health+"";
       }
       //level 2
       if(m_Scene.name == "SamLevel"){
           sceneText.text = "Level 2: The Maze";
        
       }
       //levekl 3
       if(m_Scene.name == "KylieLevel"){
           
       }
        
   }

}
