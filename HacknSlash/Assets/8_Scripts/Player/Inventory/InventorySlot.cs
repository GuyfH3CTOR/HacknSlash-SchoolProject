using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem myItem{get;set;}

    public SlotTag myTag;

    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Middle){
            if(Inventory.carriedItem == null)return;
            if(myTag != SlotTag.None && Inventory.carriedItem.myItem.itemTag != myTag)return;
            SetItem(Inventory.carriedItem);
        }
    }

    public void SetItem(InventoryItem item){
        Inventory.carriedItem = null;

        // Reset Old slot
        item.activeSlot.myItem = null;

        // Set current slot
        myItem = item;
        myItem.activeSlot = this;
        myItem.transform.SetParent(transform);
        myItem.canvasGroup.blocksRaycasts = true;

        if(myTag != SlotTag.None){
            Inventory.Singleton.EquipEquipment(myTag, myItem);
        }
    }
}
