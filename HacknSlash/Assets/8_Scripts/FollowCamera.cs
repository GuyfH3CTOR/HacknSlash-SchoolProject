using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("========== Follow Camera ==========")]

    [Header("#### References ####")]
    // private
    private Transform playerCamera;
    
    void Start()
    {
        // Get Camera Reference
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        transform.LookAt(playerCamera);
    }
}
