 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
    //variables used in first person camera
    Vector2 mouseLook;
    Vector2 smoothV;
    //sensitivy for reaction speed
    public float sensitivity = 100f;
    public float smoothing = 2.0f;

    //tranform that camera is on 
    public Transform playerBody;
    float xRotation = 0f;
   
   
    void Update()
    {
        //gets axis of mouse and sets it to sensitivty etc
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //allows the camera to react to mouse movement
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,45f);
        //sets movement of mouse to camera and displays it in game
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
