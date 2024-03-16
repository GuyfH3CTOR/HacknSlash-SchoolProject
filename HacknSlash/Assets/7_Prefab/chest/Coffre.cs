using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : Interactable_Obj
{
    [Header("#### Chest Settings ####")]

    public GameObject g_Mesh;
    public Item item;

    [Header("#### Chest Openning References ####")]
    public AudioSource audioSource;
    public Animation ChestOpenAnimation;
    public ParticleSystem particules;

    public override bool InteractionCondition()
    {
        // Get player
        GameObject player = GameObject.Find("Player");
        // Check if there is enough space in player inventory
        if(player.GetComponentInChildren<Inventory>().inv.Count < player.GetComponentInChildren<Inventory>().numberOfSlot){
            InteractionEffect();
        }
        return base.InteractionCondition();
    }

    public override void InteractionEffect()
    {
        // Get player and add Item to Inventory
        GameObject player = GameObject.Find("Player");
        Inventory inventory = player.GetComponentInChildren<Inventory>();
        inventory.AddItem(item);

        // Play Chest Openning Effect
        base.InteractionEffect();
        ChestOpenningAnimation();
    }

    public void ChestOpenningAnimation()
    {
        audioSource.Play(0);
        ChestOpenAnimation.Play("Chest Openning Animation");
        particules.Play();
    }
}
