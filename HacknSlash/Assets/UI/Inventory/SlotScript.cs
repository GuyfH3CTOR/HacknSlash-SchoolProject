using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [Header("========== Bag ==========")]
    [Header("Variables")]
    public Item item;
    [Header("References")]
    private SpriteRenderer I_icon;

    void Start(){
        Initialization();
    }

    void Initialization(){
        // Get the Sprite Renderer
        I_icon = GetComponentInChildren<SpriteRenderer>();
    }

    public void UpdateSlot(Item _item){
        // Update Slot Information of Item
        item = _item;
        // Update Slot Icon
        UpdateIcon();
    }

    void UpdateIcon(){
        // Check if there is an Icon
        if(item.Icon != null) {
            I_icon.sprite = item.Icon;
            // Opacity 100% (because it is NOT a white sprite)
            I_icon.color = new Color(1f,1f,1f,1f);
        }else{
            // Opacity 0% (because it is a white sprite)
            I_icon.color = new Color(1f,1f,1f,0f);
        }
    }
}
