using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Interactable_Obj : MonoBehaviour
{
    [Header("#### Settings ####")]
    [Header("#### Variables ####")]
    [Header("#### References ####")]
    public GameObject Alert;
    private GameObject player;

    public bool locked = false;
    protected bool isUsable = false;
    
    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onActivated")]
    [SerializeField]
    private Unlock_Event onActivated = new Unlock_Event();

    public void Interact()
    {
        if(isUsable && !locked)
        {
            // Debug.Log("use");
            Interaction();
            SwitchLocked();
            InteractEffect();
            Alert.SetActive(false);
        }
    }

    public virtual void InteractEffect()
    {
        onActivated.Invoke();
    }

    public void SwitchLocked()
    {
        locked = !locked;
    }

    public void SwitchIsUsable()
    {
        isUsable = !isUsable;
        // Debug.Log("switch is usable" + isUsable);
    }

    public virtual void Interaction()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        player = GameObject.Find("Player"); // Set player Ref

        if(collider.gameObject == player && !locked)
        {
            // Debug.Log("in");
            Alert.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject == player)
        {
            Alert.SetActive(false);
        }
    }
}
