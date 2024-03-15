using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("========== Door ==========")]
    [Header("#### References ####")]
    public Transform pivot;
    [Header("---Sound---")]
    public AudioSource audioSource;
    public AudioClip openSoundEffect;
    public AudioClip closeSoundEffect;

    [Header("#### Variables ####")]
    // public
    public bool isOpenAtStart;
    [Header("---Rotation---")]
    public Vector3 closeRotation;
    public Vector3 openRotation;
    [Header("---Position---")]
    public Vector3 closePosition;
    public Vector3 openPostion;
    // private
    private bool isOpen;
    private bool isInPosition = true;
    private Quaternion CurrentRotation, newRotation;
    private Vector3 CurrentPosition, newPosition;
    private float slerpTimeCount;

    [Header("#### Debug ####")]
    public bool Open;
    public bool Close;

    void Start(){
        // Inititalization();
    }
    void Inititalization(){
        isOpen = isOpenAtStart;

        if(isOpenAtStart){
            // Debug.Log("is OpenAtStart");
            pivot.localEulerAngles = openRotation;
            pivot.transform.localPosition = openPostion;
        }
        if(!isOpenAtStart){
            // Debug.Log("is not OpenAtStart");
            pivot.localEulerAngles = closeRotation;
            pivot.transform.localPosition = closePosition;
        }
    }

    void Update(){
        // Update Rotation Slerp
        if(!isInPosition)DoorMovement();

        // Debug
        if(Open){
            OpenDoor();
            Open = !Open;
        }
        if(Close){
            CloseDoor();
            Close = !Close;
        }
    }

    public void DoorMovement(){
        //update rotation and position
        pivot.transform.localRotation = Quaternion.Slerp(CurrentRotation, newRotation, slerpTimeCount);
        pivot.transform.localPosition = Vector3.Slerp(CurrentPosition, newPosition, slerpTimeCount);
        // update slerp timer
        slerpTimeCount = slerpTimeCount + Time.deltaTime;
        if(pivot.localRotation == newRotation && pivot.localPosition == newPosition) isInPosition = true;
    }

    public void OpenDoor(){
        if(!isOpen){
            Debug.Log("Open door");
            // Reset Slerp Timer
            slerpTimeCount = 0;
            // Get Pivot current rotation and position
            CurrentRotation = pivot.localRotation;
            CurrentPosition = pivot.localPosition;
            // Get Pivot new rotation and position
            newRotation = Quaternion.Euler(openRotation);
            newPosition = openPostion;
            // Start Slerp
            isInPosition = false;
            // Play sound effect
            audioSource.clip = openSoundEffect;
            audioSource.Play();

            isOpen = !isOpen;
        }
    }

    public void CloseDoor(){
        if(isOpen){
            Debug.Log("Close door");
            // Reset Slerp Timer
            slerpTimeCount = 0;
            // Get Pivot current rotation and position
            CurrentRotation = pivot.localRotation;
            CurrentPosition = pivot.localPosition;
            // Get Pivot new rotation and position
            newRotation = Quaternion.Euler(closeRotation);
            newPosition = closePosition;
            // Start Slerp
            isInPosition = false;
            // Play sound effect
            audioSource.clip = closeSoundEffect;
            audioSource.Play();
            
            isOpen = !isOpen;
        }
    }

    public void SwitchDoorState(){
        if(isOpen){
            CloseDoor();
        }else{
            OpenDoor();
        }
    }
}
