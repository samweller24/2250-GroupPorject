
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int health = 100;
  private int damage = 50;
  public AudioSource zombieSource;
  private bool zombieClose;

  void Start(){
    zombieSource = GetComponent<AudioSource>();
  }

  void Update(){
    
  }
  
  //implement this code later on - cuasing a crash at the moment
  void OnTriggerEnter(Collider col){
    if(col.gameObject.tag == "Player"){
      zombieClose = true;
      zombieSource.Play();
    }
  }

  void OnTriggerExit(){
    zombieClose = false; 
    zombieSource.Stop();
  }


  public void TakeDamage(int amount){
      health -= amount;
      if(health <= 0){
            Die();
      }
  }
  
 void OnCollisionEnter(Collision collision){
   if(collision.gameObject.tag == "Player"){
   CharacterController player = collision.transform.GetComponent<CharacterController>();
   player.TakeDamage(damage);
   }
  }

  void Die(){
    Destroy(gameObject);
  }
 }

