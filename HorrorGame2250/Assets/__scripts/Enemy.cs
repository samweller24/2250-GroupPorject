
using UnityEngine;

public class Enemy : MonoBehaviour
{
  //varibales associaetd with the enemy 
  public int health = 100;
  private int damage = 25;

//lets an enemy take damage
  public void TakeDamage(int amount){
      health -= amount;
      if(health <= 0){
            Die();
      }
  }
  
  //gives damage if colldiing with a aplyer
 void OnCollisionEnter(Collision collision){
   if(collision.gameObject.tag == "Player"){
     //finds player damage function and sets it with parameter for damage 
   CharacterController player = collision.transform.GetComponent<CharacterController>();
   player.TakeDamage(damage);
   }
  }

  //function destroys enemy when health < 0
  void Die(){
    Destroy(gameObject);
  }
 }

