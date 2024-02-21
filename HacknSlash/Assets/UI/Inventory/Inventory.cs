using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("========== Bag ==========")]
    [Header("Variables")]
    public int numberOfSlot = 12;
    public List<Item> inv = new List<Item>();
    public List<GameObject> slot = new List<GameObject>();

    [Header("References")]
    public GameObject inventoryBag;
    public GameObject g_slot;

    [Header("Debuging")]
    public bool updateInv;

    void Start(){
        Initialization();
    }

    void Initialization(){
        for(int i = 0; i < numberOfSlot; i++){
            // Create new empty Item 
            // !!!!TODO : Check if necessary
            // inv.Add(new Item());
            // Create all inventory Slot with a Parent + Add them all to Slot List
            slot.Add(Instantiate(g_slot, inventoryBag.transform));
        }
        UpdateInv();
    }

    void Update(){
        // Debuging
        if(updateInv){
            UpdateInv();
            updateInv = !updateInv;
        }
    }

    public void AddItem(Item item){
        // Add Item to Items List
        inv.Add(item);
        UpdateInv();
    }

    void UpdateInv(){
        // Update All Slot of inventory
        for(int i = 0; i < slot.Count; i++){
            slot[i].GetComponentInChildren<SlotScript>().UpdateSlot(inv[i]);
        }
    }
}
