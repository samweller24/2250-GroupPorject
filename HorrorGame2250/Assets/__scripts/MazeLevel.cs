using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
