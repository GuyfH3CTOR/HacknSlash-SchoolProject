using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : Interactable_Obj
{
    [Header("#### Chest Settings ####")]

    public GameObject g_Mesh;
    public List<Item> items = new List<Item>();

    [Header("#### Chest Openning References ####")]
    public AudioSource audioSource;
    public Animation ChestOpenAnimation;
    public ParticleSystem particules;

    public override bool InteractionCondition()
    {
        // Get player
        GameObject player = GameObject.Find("Player");
        // Check if there is enough space in player inventory
        if(items.Count != 0){
            // Debug.Log("Chest : "+items.Count+" items");
            return true;
        }else{
            // Debug.Log("Chest : empty");
            return false;
        }
    }

    public override void InteractionEffect()
    {
        // Get player and add Item to Inventory
        for(int i = 0; i < items.Count; i++){
            GameObject.Find("Player").GetComponentInChildren<Inventory>().AddItem(items[i]);
            // Debug.Log("Chest : add "+i);
        }
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
