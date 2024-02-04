using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{    
    [SerializeReference] protected int ID;
    [SerializeReference] protected string Name;

    public Item(int id,string name)
    {
        ID = id;
        Name = name;
    }
}
