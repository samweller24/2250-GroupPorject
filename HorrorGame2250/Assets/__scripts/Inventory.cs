using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
     private List<PickUpItem> itemList;

     public Inventory() {
         itemList = new List<PickUpItem>(); 
         Debug.Log("Iventory");

     }

     public void AddItem(PickUpItem item){
         itemList.Add(item);
     }

     public List<PickUpItem> GetItemList(){
         return itemList;
     }
}
