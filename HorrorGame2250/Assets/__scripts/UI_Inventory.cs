﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
  private Inventory inventory; 
  private Transform itemSlotContainer;
  private Transform itemSlotTemplate;

  private void Awake(){
      itemSlotContainer = transform.Find("ItemSlotContainer");
      itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
  }
 
  public void SetInventory(Inventory inventory ){
      this.inventory = inventory;
      RefreshInventoryItems();
    
  }

  private void RefreshInventoryItems(){
    
       int x = 0;
       int y = 0;
       float itemSlotCellSize = 30f;
       foreach (PickUpItem item in inventory.GetItemList())
       {
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           itemSlotRectTransform.anchoredPosition = new Vector2( x* itemSlotCellSize, y * itemSlotCellSize);
           Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
           image.sprite = item.GetGameObject().GetComponent<Image>().overrideSprite;
           x += 3;
           if (x > 12){
               break;
           }
       }
  }


}
