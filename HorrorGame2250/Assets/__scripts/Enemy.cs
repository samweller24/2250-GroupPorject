
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float health = 100f;
  private float damage = 10f;
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


  public void TakeDamage(float amount){
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

