using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnProjectile : MonoBehaviour
{
    [SerializeField] GameObject g_PlayerArm;
    [SerializeField] GameObject g_ProjectToSpawn;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Instantiate(g_ProjectToSpawn, g_PlayerArm.transform.position, g_PlayerArm.transform.rotation, transform);
        }    
    }
}
