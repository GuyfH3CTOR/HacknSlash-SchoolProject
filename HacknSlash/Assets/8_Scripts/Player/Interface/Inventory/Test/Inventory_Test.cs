// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Inventory_Test : MonoBehaviour
// {
//     [Header("#### Settings ####")]
//     public static int numberOfSlot = 36;

//     public static Inventory_Test Singleton;
//     public static InventoryItem carriedItem;

//     [Header("#### References ####")]
//     [SerializeField] GameObject inventoryBag;
//     [SerializeField] GameObject slot;
    
//     [SerializeField] List<InventorySlot> inventorySlots = new List<InventorySlot>();

//     [SerializeField] Transform draggableTransform;
//     [SerializeField] InventoryItem itemPrefab;

//     [Header("#### Items List ####")]
//     public List<Item> items = new List<Item>();

//     [Header("#### Debug ####")]
//     [SerializeField] Button giveItemBtn;

//     void Awake(){
//         Singleton = this;
//         Initialization();
//         if(giveItemBtn != null)giveItemBtn.onClick.AddListener(delegate{SpawnInventoryItem();});
//     }

//     void Initialization(){
//         // Create Inventory
//         for(int i = 0; i < numberOfSlot; i++){
//             // Create all inventory Slot with a Parent + Add them all to Slot List
//             inventorySlots.Add(Instantiate(slot, inventoryBag.transform).GetComponent<InventorySlot>());
//         }
//     }

//     public void SpawnInventoryItem(){
//         Item _item = null;
//         if(_item == null){
//             int random = Random.Range(0, items.Count);
//             Debug.Log("items count : " + items.Count);
//             _item = items[random];
//         }

//         for(int i = 0; i < inventorySlots.Count; i++){
//             // Check if the slot is empty
//             if(inventorySlots[i].myItem == null){
//                 Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
//                 break;
//             }
//         }
//     }

//     public void SpawnInventoryItem(Item item){
//         Item _item = item;

//         for(int i = 0; i < inventorySlots.Count; i++){
//             // Check if the slot is empty
//             if(inventorySlots[i].myItem == null){
//                 Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
//                 break;
//             }
//         }
//     }

//     void Update(){
//         if(carriedItem == null)return;
//         carriedItem.transform.position = Input.mousePosition;
//     }

//     public void SetCarriedItem(InventoryItem item){
//         if(carriedItem != null){
//             if(item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag)return;
//             item.activeSlot.SetItem(carriedItem);
//         }

//         if(item.activeSlot.myTag != SlotTag.None){
//             EquipEquipment(item.activeSlot.myTag, null);
//         }

//         carriedItem =item;
//         carriedItem.canvasGroup.blocksRaycasts = false;
//         item.transform.SetParent(draggableTransform);
//     }

//     public void EquipEquipment(SlotTag tag, InventoryItem item = null){
//         switch(tag){
//             case SlotTag.Head:
//                 if(item == null){
//                     // Destroy item.equipmentPrefab on the PlayerObject;
//                     Debug.Log("Unquipped helmet on " + tag);
//                 }else{
//                     // Instantiate item.equipmentPrefab on the Player Object;
//                     Debug.Log("Equipped " + item.myItem.name + "on " + tag);
//                 }break;
//             case SlotTag.Chest:
//                 break;
//             case SlotTag.Legs:
//                 break;
//             case SlotTag.Feet:
//                 break;
//         }
//     }


//     // [Header("========== Bag ==========")]
//     // [Header("Variables")]
//     // public int numberOfSlot = 12;
//     // public List<Item> inv = new List<Item>();
//     // private List<GameObject> slot = new List<GameObject>();

//     // [Header("References")]
//     // public GameObject inventoryBag;
//     // public GameObject g_slot;

//     // [Header("Debuging")]
//     // public bool updateInv;

//     // void Start(){
//     //     Initialization();
//     // }

//     // void Initialization(){
//     //     // Create Inventory
//     //     for(int i = 0; i < numberOfSlot; i++){
//     //         // Create new empty Item 
//     //         // !!!!TODO : Check if necessary
//     //         inv.Add(new Item());
//     //         // Create all inventory Slot with a Parent + Add them all to Slot List
//     //         slot.Add(Instantiate(g_slot, inventoryBag.transform));
//     //     }
//     //     // Empty All Slot of inventory
//     //     for(int c = 0; c < slot.Count; c++){
//     //         // Slot order in hierarchy
//     //         slot[c].name = slot[c].name + c;
//     //         // Initialize Slot GameObject
//     //         slot[c].GetComponentInChildren<SlotScript>().Initialization();
//     //         // Empty Slot
//     //         slot[c].GetComponentInChildren<SlotScript>().EmptySlot();
//     //     }
//     //     UpdateInv();
//     // }

//     // void Update(){
//     //     // Debuging
//     //     if(updateInv){
//     //         UpdateInv();
//     //         updateInv = !updateInv;
//     //     }
//     // }

//     // public void AddItem(Item item){
//     //     // Add Item to Items List
//     //     inv.Add(item);
//     //     UpdateInv();
//     // }

//     // void UpdateInv(){
//     //     // Update All Slot of inventory
//     //     for(int i = 0; i < slot.Count; i++){
//     //         // Check if Item as ID if not EmptySlot() otherwise UpdateSLot()
//     //         if(inv[i].ID == 0){
//     //             // Debug.Log("null");
//     //             // If superior than curent number of item in inv 
//     //             slot[i].GetComponentInChildren<SlotScript>().EmptySlot();
//     //         }else{
//     //             // If inferior or equal than curent number of item in inv 
//     //             slot[i].GetComponentInChildren<SlotScript>().UpdateSlot(inv[i]);
//     //         }
//     //     }
//     // }
// }
