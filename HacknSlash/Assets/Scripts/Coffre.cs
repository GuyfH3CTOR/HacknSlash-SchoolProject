using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : Interactable_Obj
{
    public GameObject g_Mesh;
    public Item item;

    public override void Interaction()
    {
        base.Interaction();
        GameObject player = GameObject.Find("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.AddItem(new Item(1 ,"chest item"));
    }

    public override void InteractEffect()
    {
        base.InteractEffect();
        g_Mesh.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
