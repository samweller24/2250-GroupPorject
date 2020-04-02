using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    //variables need to display the user inventory on screeen
    //instance of iventory and it components 
  private Inventory inventory; 
  private Transform itemSlotContainer;
  private Transform itemSlotTemplate;

    //awake functions, finds according slots that are used in UI display
  private void Awake(){
      itemSlotContainer = transform.Find("ItemSlotContainer");
      itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
  }
    
    //function to set inventory when need, also refreshes upon new items
  public void SetInventory(Inventory inventory ){
      this.inventory = inventory;
      RefreshInventoryItems();
    
  }

//when new items are added, refresh occurs and fills out the UI inventory
  private void RefreshInventoryItems(){
       int x = 0;
       int y = 0;
       float itemSlotCellSize = 30f;
       //foreach to iterate through items in the inventory 
       foreach (PickUpItem item in inventory.GetItemList())
       {
           //sets each item to according place in UI display
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           itemSlotRectTransform.anchoredPosition = new Vector2( x* itemSlotCellSize, y * itemSlotCellSize);
           Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
           image.sprite = item.GetGameObject().GetComponent<Image>().overrideSprite;
           x += 3;
           //no more than 12 items allowed
           if (x > 12){
               break;
           }
       }
  }


}
