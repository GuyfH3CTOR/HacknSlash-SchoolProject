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
        item = new Item(Random.Range(1,10));
        if(GameObject.Find("Player").GetComponentInChildren<Inventory>().AddItem(item)){
            InteractionEffect();
        }
        return base.InteractionCondition();
    }

    public override void InteractionEffect()
    {
        // Get player and add Item to Inventory
        GameObject player = GameObject.Find("Player");
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
