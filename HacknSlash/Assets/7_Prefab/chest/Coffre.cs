using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : Interactable_Obj
{
    [Header("Object Settings :")]

    public GameObject g_Mesh;
    public Item item;

    [Header("Open Animation :")]
    public AudioSource as_ChestOpen;
    public Animation a_ChestAnimation;
    public ParticleSystem ps_ChestParticule;


    public override void Interaction()
    {
        // Get player
        GameObject player = GameObject.Find("Player");

        // Check if there is enough space in player inventory
        if(player.GetComponentInChildren<Inventory>().inv.Count < player.GetComponentInChildren<Inventory>().numberOfSlot){
            base.Interaction();
            Inventory inventory = player.GetComponentInChildren<Inventory>();
            inventory.AddItem(item);
        }
    }

    // public override void InteractEffect()
    // {
    //     base.InteractEffect();
    //     as_ChestOpen.Play(0);
    //     a_ChestAnimation.Play("New Animation");
    //     ps_ChestParticule.Play();
    // }
}
