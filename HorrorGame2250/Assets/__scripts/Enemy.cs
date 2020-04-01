
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int health = 100;
  private int damage = 25;
  public AudioSource zombieSource;
  private bool zombieClose;

  void Start(){
    zombieSource = GetComponent<AudioSource>();
  }

  void Update(){
    if(zombieClose){
      zombieSource.Play();
    }
    if(!zombieClose){
       zombieSource.Stop();
    }
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

