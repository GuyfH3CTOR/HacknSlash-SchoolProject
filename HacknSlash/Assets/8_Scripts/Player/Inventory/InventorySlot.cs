using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Item item;

    public void SetSlotItem(Item newItem){
        item = newItem;
    }
}
