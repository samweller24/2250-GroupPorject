﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //finds gameobject player to dollow
        player = GameObject.Find("PlayerController");
    }

    // Update is called once per frame
    void Update()
    {
        //updates poition accordingly
        gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
}
