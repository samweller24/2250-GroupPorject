using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for item types encountered in the game 
public class PickUpItem 
{

    //enum for possible types - there are 4
    public enum ItemType
    {
         Flashlight,
            Gun,
            Map,
            Boot
       
    }

    //item type and amouont are used when setting inventory 
    public ItemType itemType;
    public int amount;

    //gets game object in game that repersents type, this is used to take gameobjects and repersent them in inventory 
    public GameObject GetGameObject(){
        switch (itemType){
            default:
            //case for each type
            case ItemType.Flashlight: return ItemAssets.Instance.Flashlight;
            case ItemType.Gun: return ItemAssets.Instance.Gun;
            case ItemType.Map: return ItemAssets.Instance.Map;
            case ItemType.Boot: return ItemAssets.Instance.Boot;
            

        }
    }
}
