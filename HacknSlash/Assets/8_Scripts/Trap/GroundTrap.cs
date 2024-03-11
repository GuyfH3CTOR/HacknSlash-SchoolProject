using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTrap : MonoBehaviour
{
    [Header("========== GroundTrap ==========")]
    [Header("#### References ####")]
    // public
    public Transform trapPivot;
    public GameObject damageZone;
    // private
    private EntitiesDetector entitiesDetector;

    [Header("#### Settings ####")]
    // public
    public float activationIntervalInSecond = 1f;
    public float trapDamage = 30f;
    // private
    // public float speedOfActivation;
    // public float speedOfDeactivation;
    [Header("---Position---")]
    public Vector3 upPostion;
    public Vector3 middlePostion;
    public Vector3 downPosition;

    void Start(){
        entitiesDetector = damageZone.GetComponent<EntitiesDetector>();
        StartCoroutine(ActivationInterval());
    }

    IEnumerator ActivationInterval(){
        yield return new WaitForSeconds(activationIntervalInSecond*0.7f);
        IndicateTrap();
        yield return new WaitForSeconds(activationIntervalInSecond*0.2f);
        ActivateTrap();
    }

    void IndicateTrap(){
        trapPivot.localPosition = middlePostion;
    }

    void ActivateTrap(){
        trapPivot.localPosition = upPostion;
        for(int i = 0; i < entitiesDetector.EntitiesDetected.Count; i++){
            if(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>() != null){
                entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>().UpdateLife(-trapDamage);
                // if(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>().UpdateLife(-trapDamage)){
                //     entitiesDetector.EntitiesDetected.RemoveAt(i);
                // }
            }else if(entitiesDetector.EntitiesDetected[i].GetComponent<Player_Values>() != null){
                entitiesDetector.EntitiesDetected[i].GetComponent<Player_Values>().UpdateLifeValue(-trapDamage);
            }
        }
        StartCoroutine(DeactivationInterval());
    }

    IEnumerator DeactivationInterval(){
        yield return new WaitForSeconds(activationIntervalInSecond*0.1f);
        Deactivate();
    }

    void Deactivate(){
        trapPivot.localPosition = downPosition;
        StartCoroutine(ActivationInterval());
    }
}