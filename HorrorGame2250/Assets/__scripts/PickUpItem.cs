using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem 
{
    public enum ItemType
    {
         Flashlight,
            Axe,
            Map
       
    }

    public ItemType itemType;
    public int amount;

    public GameObject GetGameObject(){
        switch (itemType){
            default:
            case ItemType.Flashlight: return ItemAssets.Instance.Flashlight;
            case ItemType.Axe: return ItemAssets.Instance.Axe;
            case ItemType.Map: return ItemAssets.Instance.Map;
        }
    }
}
