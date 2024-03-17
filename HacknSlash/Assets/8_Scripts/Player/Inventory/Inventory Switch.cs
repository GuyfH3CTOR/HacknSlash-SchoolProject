using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    [Header("========== Inventory ==========")]
    [Header("References")]
    public GameObject g_InventoryPanel;

    void Update(){
        // Switch to open and close Inventory
        if(Input.GetKeyDown(KeyCode.E)) {
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
