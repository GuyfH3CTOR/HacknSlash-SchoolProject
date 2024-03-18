using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    [Header("#### Settings ####")]
    public Item item = null;
    public bool full;

    [Header("#### References ####")]
    public Image image;

    public void SetSlotItem(Item newItem){
        item = newItem;
        image.sprite = item.itemIcon;
        image.color = new Vector4(1,1,1,1);
        full = true;
    }
}
