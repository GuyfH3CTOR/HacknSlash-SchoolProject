using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneOfWallInfluence : MonoBehaviour
{
    [Header("========== ZoneOfWallInfluence ==========")]
    [Header("#### Settings ####")]
    public LayerMask layerToHideWhenBehind;

    [Header("#### Variables ####")]
    public float DetectionRadius;
    public Collider[] hitColliders;

    [Header("#### References ####")]
    public Material transparentWall;
    public Material Wall;
    public GameObject player;

    void FixedUpdate(){
        for(int i = 0; i < hitColliders.Length; i++){
            hitColliders[i].GetComponent<Renderer>().material = Wall;
        }
        // Get all walls inside a capsule collider between the player and the camera
        hitColliders = Physics.OverlapCapsule(player.transform.position, Camera.main.transform.position, DetectionRadius, layerToHideWhenBehind);
        // Check if all walls detected are inside the list
        for(int i = 0; i < hitColliders.Length; i++){
            hitColliders[i].GetComponent<Renderer>().material = transparentWall;
        }
    }
}
