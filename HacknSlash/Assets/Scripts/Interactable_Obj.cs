using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interactable_Obj : MonoBehaviour
{
    protected bool unlocked = true;
    protected bool isUsable = false;

    public void Interact()
    {
        if(isUsable && unlocked)
        {
            // Debug.Log("use");
            Interaction();
            SwitchLocked();
            InteractEffect();
        }
    }

    public virtual void InteractEffect()
    {

    }

    public void SwitchLocked()
    {
        unlocked = !unlocked;
    }

    public void SwitchIsUsable()
    {
        isUsable = !isUsable;
        // Debug.Log("switch is usable" + isUsable);
    }

    public virtual void Interaction()
    {

    }
}
