﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTcamScript : MonoBehaviour
{
     Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 100f;
    public float smoothing = 2.0f;
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,45f);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
