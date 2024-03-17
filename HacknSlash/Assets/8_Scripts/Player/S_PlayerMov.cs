using UnityEngine;
using System.Collections;
using UnityEditor;

public class S_PlayerMov : MonoBehaviour
{
    [Header("========== PlayerMov ==========")]
    [Header("#### Settings ####")]
    // public
    public float MovSpeed = 5;

    [Header("#### Variables ####")]
    // private
    private Rigidbody rb;
    // private bool isWalking;

    [Header("#### References ####")]
    public AudioSource audioSourceFootstep;

    void Start(){
        Camera.main.transform.LookAt(transform);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        rb.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * MovSpeed);
        // if(Input.GetAxis("Horizontal") != 0 && !isWalking || Input.GetAxis("Vertical") != 0 && !isWalking){
        //     isWalking = true;
        //     StartCoroutine(Footstep());
        // }else{
        //     isWalking = false;
        //     StopCoroutine(Footstep());
        // }
    }

    // IEnumerator Footstep(){
    //     float delay = audioSourceFootstep.clip.length;
    //     audioSourceFootstep.Play(0);
    //     yield return new WaitForSeconds(delay);
    //     isWalking = false;
    // }
}