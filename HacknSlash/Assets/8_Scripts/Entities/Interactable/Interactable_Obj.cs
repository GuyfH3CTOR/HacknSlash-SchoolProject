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
    // public
    public bool locked = false;
    public bool isOneUse;

    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onActivated")]
    [SerializeField]
    private Unlock_Event onActivated = new Unlock_Event();

    [Header("#### Variables ####")]

    [Header("#### References ####")]
    public Interactable_Alert playerInRangeAlert;

    

    public void Interact()
    {
        if(!locked)
        {
            // Debug.Log("use");
            Interaction();
            SwitchLock();
            // playerInRangeAlert.SetActive(false);
        }
    }

    public void SwitchLock()
    {
        locked = !locked;
    }

    public virtual void Interaction()
    {
        if(!locked){
            // Stop Alert and lock Interactor
            if(isOneUse)playerInRangeAlert.AlertOff();
            if(isOneUse)SwitchLock();

            // debug
            Debug.Log("interaction");
            // Effect of activation
            playerInRangeAlert.Use();
            onActivated.Invoke();
        }
    }

    public void PlayerInRange(){
        // Debug.Log("player in range");
        if(playerInRangeAlert != null && !locked){
            playerInRangeAlert.AlertOn();
        }
    }

    public void PlayerOutOfRange(){
        // Debug.Log("player out of range");
        if(playerInRangeAlert != null){
            playerInRangeAlert.AlertOff();
        }
    }
}
