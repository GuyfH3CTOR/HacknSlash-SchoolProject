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
    public GameObject itemLogs;
    [Header("Prefab")]
    public GameObject Log;
    
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
        // Debug.Log("AddItem : "+_item.itemName);
        // Debug.Log("inventorySlots.Count "+inventorySlots.Count);
        for(int i = 0; i < inventorySlots.Count; i++){
            if(!inventorySlots[i].full){
                inventorySlots[i].SetSlotItem(_item);
                items.Add(_item);
                UpdateStats();
                ItemLog _itemLog = Instantiate(Log, itemLogs.transform).GetComponent<ItemLog>();
                // Debug.Log("itemlog ref : "+_itemLog);
                _itemLog.SetLog(_item);
                // Debug.Log("AddItem : "+_item.itemName+" To slot number "+i);
                return true;
            }else{
                // Debug.Log("InventorySlot : "+i+" Full");
            }
        }
        return false;
    }

    void UpdateStats(){
        foreach(var item in items){

        }
    }
}
