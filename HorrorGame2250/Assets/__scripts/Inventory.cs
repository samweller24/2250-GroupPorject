using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    //list of items of type pick up
     private List<PickUpItem> itemList;

    //constructor for inventory, sets inventory 
     public Inventory() {
         itemList = new List<PickUpItem>(); 
         Debug.Log("Iventory");

     }

    //function to add items to inventory 
     public void AddItem(PickUpItem item){
         itemList.Add(item);
     }

    //retuns item list 
     public List<PickUpItem> GetItemList(){
         return itemList;
     }
}
