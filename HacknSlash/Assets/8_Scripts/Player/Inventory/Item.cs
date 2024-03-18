using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotTag{None, Head, Chest, Legs, Feet}

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{   
    public Sprite sprite;
    public SlotTag itemTag; 

    [Header("if the equipement can be equipped")]
    public GameObject equipmentPrefab;

    [SerializeReference] public int ID;
    [SerializeReference] public string Name;
    [SerializeReference] public Sprite Icon;
    [SerializeReference] public string Description = new string("empty");

    public Item(int id){
        ID = id;
    }
}
