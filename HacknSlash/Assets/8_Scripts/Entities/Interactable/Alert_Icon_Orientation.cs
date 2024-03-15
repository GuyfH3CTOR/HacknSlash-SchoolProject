using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert_Icon_Orientation : MonoBehaviour
{
    [Header("#### Settings ####")]
    // public
    public Vector3 worldRotation = new Vector3(60,-45,0);

    void Start()
    {
        transform.rotation = Quaternion.Euler(worldRotation);
    }
}
