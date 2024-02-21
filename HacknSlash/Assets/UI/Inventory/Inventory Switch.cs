using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    [Header("========== Inventory ==========")]
    [Header("References")]
    public GameObject g_InventoryPanel;
    public GameObject g_pressFtoOpenInventory;

    void Update(){
        // Switch to open and close Inventory
        if(Input.GetKeyDown(KeyCode.E)) {
            // InventoryTouchIndicator
            if(g_pressFtoOpenInventory.activeSelf) {
                // Close
                g_pressFtoOpenInventory.SetActive(false);
            }else{
                // Open
                g_pressFtoOpenInventory.SetActive(true);
            }
            // Inventory
            if(g_InventoryPanel.activeSelf) {
                // Close
                g_InventoryPanel.SetActive(false);
            }else{
                // Open
                g_InventoryPanel.SetActive(true);
            }
        }
    }
}
