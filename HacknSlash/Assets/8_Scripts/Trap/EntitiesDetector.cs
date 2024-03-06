using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesDetector : MonoBehaviour
{
    [Header("========== EntitiesDetector ==========")]
    [Header("#### Settings ####")]
    public bool sphereZone;
    public float sphereRadius;
    public bool BoxZone;
    public float boxRadius;

    [Header("#### Variables ####")]
    public List<GameObject> EntitiesDetected = new List<GameObject>();
    public Collider[] EntitiesInZone;

    [Header("#### Debug ####")]
    private bool m_Started;

    void Start(){
        m_Started = true;
    }

    void FixedUpdate(){
        if(sphereZone){
            EntitiesInZone = Physics.OverlapSphere(transform.position, sphereRadius);
            EntitiesDetected.Clear();
            for(int i = 0; i < EntitiesInZone.Length; i++){
                if(EntitiesInZone[i].GetComponent<Entity_Damagable>() != null||EntitiesInZone[i].GetComponent<Player_Values>() != null){
                    EntitiesDetected.Add(EntitiesInZone[i].gameObject);
                }
            }
        }
        if(BoxZone){
            EntitiesInZone = Physics.OverlapBox(transform.position, transform.localScale * boxRadius, Quaternion.identity);
            EntitiesDetected.Clear();
            for(int i = 0; i < EntitiesInZone.Length; i++){
                if(EntitiesInZone[i].GetComponent<Entity_Damagable>() != null||EntitiesInZone[i].GetComponent<Player_Values>() != null){
                    EntitiesDetected.Add(EntitiesInZone[i].gameObject);
                }
            }
        }
    }
    
    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale * boxRadius);
    }

    // void OnTriggerEnter(Collider i){
    //     if(i.GetComponent<Entity_Damagable>() != null||i.GetComponent<Player_Values>() != null) EntitiesDetected.Add(i.gameObject);
    // }
    // void OnTriggerExit(Collider o){
    //     if(o.GetComponent<Entity_Damagable>() != null||o.GetComponent<Player_Values>() != null){
    //         for(int i = 0; i < EntitiesDetected.Count; i++){
    //             if(EntitiesDetected[i] == o.gameObject) EntitiesDetected.RemoveAt(i);
    //         }
    //     }
    // }
}
