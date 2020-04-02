
using UnityEngine;

//gun class
public class Gun : MonoBehaviour
{
    //variables used for gun and its fucntions
   public int damage = 10;
   public float range = 100f;
   public GameObject fpsCam;


    // Update is called once per frame
    void Update()
    {
        //if left click, shoot function activates
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    //function that controls shoot
    void Shoot(){
        //raycast to track bullet
        RaycastHit hit;
        //if statement contorlling ray
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            //enemy hit condition
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null){
                //if hit, take damage 
                enemy.TakeDamage(damage);
            }
        }

    }
}
