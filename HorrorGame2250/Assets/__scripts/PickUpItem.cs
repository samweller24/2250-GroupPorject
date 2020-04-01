using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem 
{
    public enum ItemType
    {
         Flashlight,
            Gun,
            Map,
            Boot
       
    }

    public ItemType itemType;
    public int amount;

    public GameObject GetGameObject(){
        switch (itemType){
            default:
            case ItemType.Flashlight: return ItemAssets.Instance.Flashlight;
            case ItemType.Gun: return ItemAssets.Instance.Gun;
            case ItemType.Map: return ItemAssets.Instance.Map;
            case ItemType.Boot: return ItemAssets.Instance.Boot;
            

        }
    }
}
