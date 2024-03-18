using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum SlotTag{None, Head, Chest, Legs, Feet}

[Serializable]
public class Item
{   
    // public Sprite sprite;
    // public SlotTag itemTag; 

    [Header("if the equipement can be equipped")]
    public GameObject equipmentPrefab;

    [SerializeReference] public int itemID;
    [SerializeReference] public string itemName;
    [SerializeReference] public Sprite itemIcon;
    [SerializeReference] public string itemDescription = new string("empty");

    public Item(int id){
        itemID = id;
    }
}
