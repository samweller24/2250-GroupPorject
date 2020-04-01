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

   private void MakeSingleton(){
       if(instance != null){
            Destroy(gameObject);
       } else {
           instance = this;
           DontDestroyOnLoad(gameObject);
       }
   }

   void Awake(){
       MakeSingleton();
       SceneManage();
        
   }


   void Update(){
    SceneManage();
    UpdateHealth();
    UpdateScore();
   }

   void UpdateHealth(){
      health = CharacterController.health;
      healthText.text = "Health: "+health+"";
   }

    void UpdateScore(){
      score = CharacterController.score;
      scoreText.text = "Score: "+score+"";
   }

   void SceneManage(){
       m_Scene = SceneManager.GetActiveScene();

       if(m_Scene.name == "MainLevel"){
           sceneText.text = "Level 1";
           scoreText.text = "Score: "+score+"";
           healthText.text = "Health: "+health+"";
       }
       if(m_Scene.name == "SamLevel"){
           sceneText.text = "Level 2: The Maze";
       }
       if(m_Scene.name == "KylieLevel"){
           
       }
        
   }

}
