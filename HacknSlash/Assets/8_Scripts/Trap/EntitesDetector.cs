using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitesDetector : MonoBehaviour
{
    public List<GameObject> EntitesDetected = new List<GameObject>();

    void OnTriggerEnter(Collider i){
        if(i.GetComponent<Entity_Damagable>() != null||i.GetComponent<Player_Values>() != null) EntitesDetected.Add(i.gameObject);
    }
    void OnTriggerExit(Collider o){
        if(o.GetComponent<Entity_Damagable>() != null||o.GetComponent<Player_Values>() != null){
            for(int i = 0; i < EntitesDetected.Count; i++){
                if(EntitesDetected[i] == o.gameObject) EntitesDetected.RemoveAt(i);
            }
        }
    }
}
