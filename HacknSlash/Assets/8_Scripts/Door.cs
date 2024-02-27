using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("========== Door ==========")]
    [Header("#### References ####")]
    public Transform Pivot;

    [Header("#### Variables ####")]
    // public
    public bool isOpenAtStart;
    public Vector3 closeRotation, openRotation;
    // private
    private bool isInPosition;
    private Quaternion CurrentRotation;
    private Quaternion newRotation;
    private float slerpTimeCount;

    [Header("#### Debug ####")]
    public bool Open;
    public bool Close;

    void Start()
    {
        if(isOpenAtStart) Pivot.localEulerAngles = openRotation;
        if(!isOpenAtStart) Pivot.localEulerAngles = closeRotation;
    }
    void Update()
    {
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
    public void DoorMovement()
    {
        transform.rotation = Quaternion.Slerp(CurrentRotation, newRotation, slerpTimeCount);
        slerpTimeCount = slerpTimeCount + Time.deltaTime;
        if(Pivot.rotation == newRotation) isInPosition = true;
    }

    public void OpenDoor()
    {
        // Reset Slerp Timer
        slerpTimeCount = 0;
        // Get Pivot current rotation
        CurrentRotation = Pivot.rotation;
        // Get Pivot new rotation
        newRotation = Quaternion.Euler(openRotation);
        // Start Slerp
        isInPosition = false;
    }
    public void CloseDoor()
    {
        // Reset Slerp Timer
        slerpTimeCount = 0;
        // Get Pivot current rotation
        CurrentRotation = Pivot.rotation;
        // Get Pivot new rotation
        newRotation = Quaternion.Euler(closeRotation);
        // Start Slerp
        isInPosition = false;     
    }
}
