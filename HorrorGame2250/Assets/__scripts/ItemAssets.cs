using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    //setter getter for istance
    public static ItemAssets Instance { get; private set;}

    //sets instance of inventory assets
    private void Awake(){
        Instance = this;
    }

    //gameobjects for iventory 
    public GameObject Flashlight;
    public GameObject Gun;
    public GameObject Map;
    public GameObject Boot;


}
