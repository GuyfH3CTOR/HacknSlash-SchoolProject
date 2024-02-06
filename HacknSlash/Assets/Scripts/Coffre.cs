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
        base.Interaction();
        GameObject player = GameObject.Find("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.AddItem(new Item(1 ,"chest item"));
    }

    public override void InteractEffect()
    {
        base.InteractEffect();
        as_ChestOpen.Play(0);
        a_ChestAnimation.Play("New Animation");
        ps_ChestParticule.Play();
    }
}
