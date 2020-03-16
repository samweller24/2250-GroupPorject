﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTmovement : MonoBehaviour
{
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
         Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical")*speed;
        float strafe = Input.GetAxis("Horizontal")*speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe,0,translation);

        if(Input.GetKeyDown("escape")){
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
