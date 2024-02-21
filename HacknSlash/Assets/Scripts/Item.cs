using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{    
    [SerializeReference] public int ID;
    [SerializeReference] public string Name;
    [SerializeReference] public Sprite Icon;
    [SerializeReference] public string Description = new string("empty");

    public Item(){
        // Empty Item
    }
    public Item(int id,string name){
        ID = id;
        Name = name;
    }
}
