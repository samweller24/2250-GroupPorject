using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set;}

    private void Awake(){
        Instance = this;
    }

    public GameObject Flashlight;
    public GameObject Axe;
    public GameObject Map;


}
