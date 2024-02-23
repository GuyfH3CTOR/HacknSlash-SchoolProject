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
    public GameObject g_icon;
    private SpriteRenderer s_icon;

    void Start(){
        Initialization();
    }

    public void Initialization(){
        // Get the Sprite Renderer
        s_icon = g_icon.GetComponent<SpriteRenderer>();
    }

    public void UpdateSlot(Item _item){
        // Update Slot Information of Item
        item = _item;
        // Update Slot Icon
        UpdateIcon();
    }
    public void EmptySlot(){
        // Debug.Log("s_icon "+s_icon);
        s_icon.color = new Color(1f,1f,1f,0f);
    }

    void UpdateIcon(){
        // Check if there is an Icon
        if(item.Icon != null) {
            s_icon.sprite = item.Icon;
            // Opacity 100% (because it is NOT a white sprite)
            s_icon.color = new Color(1f,1f,1f,1f);
        }else{
            // Opacity 0% (because it is a white sprite)
            s_icon.color = new Color(1f,1f,1f,0f);
        }
    }
}
