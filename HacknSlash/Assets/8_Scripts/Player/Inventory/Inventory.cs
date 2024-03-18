using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("#### Settings ####")]
    public int numberOfSlot = 36;

    [Header("#### References ####")]
    public GameObject inventoryBag;
    public GameObject slot;
    
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    [Header("#### Items List ####")]
    public List<Item> items = new List<Item>();

    [Header("#### Debug ####")]
    public Button giveItemBtn;

    void Awake(){
        Initialization();
        // Set Button
        // if(giveItemBtn != null)giveItemBtn.onClick.AddListener(delegate{AddItem(Item item = new Item());});
    }

    void Initialization(){
        // Create Inventory
        for(int i = 0; i < numberOfSlot; i++){
            // Create all inventory Slot with a Parent + Add them all to Slot List
            inventorySlots.Add(Instantiate(slot, inventoryBag.transform).GetComponent<InventorySlot>());
        }
    }

    public bool AddItem(Item _item){
        for(int i = 0; i < inventorySlots.Count; i++){
            if(inventorySlots[i].item == null){
                inventorySlots[i].SetSlotItem(_item);
                items.Add(_item);
                UpdateStats();
                return true;
            }
        }
        return false;
    }

    void UpdateStats(){
        foreach(var item in items){

        }
    }
}
