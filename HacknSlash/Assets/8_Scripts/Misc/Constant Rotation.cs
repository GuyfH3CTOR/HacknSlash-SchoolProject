using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [Header("========== Constant Rotation ==========")]
    [Header("#### Settings ####")]
    public float speed;

    void Update()
    {
        Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y + speed,transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
