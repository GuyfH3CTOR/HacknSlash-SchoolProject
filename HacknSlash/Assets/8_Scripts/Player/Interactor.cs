using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("#### Settings ####")]
    // public
    public float interactionRadius;

    [Header("#### References ####")]
    // public
    public Transform player;
    // private
    private Interactable_Obj interactable_Obj;

    [Header("#### Variables ####")]
    // private
    private float lowestDist;
    private int Interactable_Obj_Count;

    [Header("#### Debug ####")]
    public bool drawGizmo;

    void Start(){
        
    }

    void Update(){
        GetInteractable_obj();
        Interaction();
    }

    void GetInteractable_obj(){
        Collider[] collider = Physics.OverlapSphere(player.position, interactionRadius);

        // Reset distance to nearest Interactable_Obj
        float lowestDist = interactionRadius;
        // Get number of Interactable_Obj in range
        int Interactable_Obj_Count = 0;

        // Test all collider
        foreach(var c in collider){
            // Get all collider with the Interactable_Obj script
            if(c.gameObject.TryGetComponent(out Interactable_Obj _interactable_Obj)){
                // Add object to Interactable_Obj_Count
                Interactable_Obj_Count++;
                // Get nearest Interactable_Obj
                float dist = Vector3.Distance(c.transform.position, player.position);
                // if is the nearest    
                if (dist<lowestDist)
                {
                    // new lowestDist
                    lowestDist = dist;
                    if(interactable_Obj == null){
                        interactable_Obj = _interactable_Obj;
                        interactable_Obj.PlayerInRange();
                    }else if(interactable_Obj != _interactable_Obj){
                        interactable_Obj.PlayerOutOfRange();
                        interactable_Obj = _interactable_Obj;
                        interactable_Obj.PlayerInRange();
                    }
                }
            }
        }
        // if there is no interactable_Obj in range
        if(Interactable_Obj_Count == 0 && interactable_Obj != null)interactable_Obj.PlayerOutOfRange();
        if(Interactable_Obj_Count == 0)interactable_Obj = null;
    }

    void Interaction(){
        // if F is pressed and !! if there is a interactable_Obj !! and it is not locked
        if(Input.GetKeyDown(KeyCode.F) && interactable_Obj != null)interactable_Obj.Interaction();
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        if(interactionRadius != 0 && player != null && drawGizmo)Gizmos.DrawWireSphere(player.position, interactionRadius);
    }
}
