using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMov : MonoBehaviour
{
    [Header("========== PlayerMov ==========")]
    [Header("#### Settings ####")]
    // public
    public float MovSpeed = 5;
    public LayerMask layerToHideWhenBehind;

    [Header("#### Variables ####")]
    private Rigidbody rb_Rigidbody;
    private RaycastHit hitData;
    public GameObject currentWallToHide;

    [Header("#### References ####")]
    // public
    public Material transparentWall;
    public Material Wall;
    public GameObject ZoneOfWallInfluence;

    void Start(){
        Camera.main.transform.LookAt(transform);
        rb_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        rb_Rigidbody.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * MovSpeed);
    }

    // void Update(){
    //     // Create raycast between camera and player
    //     if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitData, 1000, layerToHideWhenBehind)){
    //         if(hitData.collider.gameObject != currentWallToHide || currentWallToHide == null){
    //             if(currentWallToHide != null){
    //                 // Stop Hiding Old currentWallToHide
    //                 currentWallToHide.GetComponent<Renderer>().material = Wall;
    //             }
    //             // Set New currentWallToHide
    //             currentWallToHide = hitData.collider.gameObject;
    //             // Hide Wall
    //             currentWallToHide.GetComponent<Renderer>().material = transparentWall;
    //         }
    //     }else if(currentWallToHide != null){
    //         currentWallToHide.GetComponent<Renderer>().material = Wall;
    //     }
    // }
}