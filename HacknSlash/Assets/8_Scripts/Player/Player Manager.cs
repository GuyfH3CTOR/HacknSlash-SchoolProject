using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Collider currentCollider;
    private Collider nearestCollider;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentCollider.gameObject.GetComponent<Interactable_Obj>().Interact();
        }
    }

    void OnTriggerEnter(Collider Collider)
    {
        if(Collider.gameObject.GetComponent<Interactable_Obj>())
        {
            // Debug.Log("Enter");
            currentCollider = Collider;
            Collider.gameObject.GetComponent<Interactable_Obj>().SwitchIsUsable();
        }
    }

    void OnTriggerExit(Collider Collider)
    {
        if(Collider.gameObject.GetComponent<Interactable_Obj>())
        {
            // Debug.Log("Exit");
            Collider.gameObject.GetComponent<Interactable_Obj>().SwitchIsUsable();
        }
    }
}
