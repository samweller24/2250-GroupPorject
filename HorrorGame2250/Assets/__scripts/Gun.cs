
using UnityEngine;

public class Gun : MonoBehaviour
{
   public int damage = 10;
   public float range = 100f;
   public GameObject fpsCam;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if(enemy != null){
                enemy.TakeDamage(damage);
            }
        }

    }
}
