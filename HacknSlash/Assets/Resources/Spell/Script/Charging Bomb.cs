using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBomb : MonoBehaviour
{
    [Header("========== Charging Bomb ==========")]
    
    [Header("#### Settings ####")]
    public float CountUntilExplosion = 30;
    public float ExplosionDamage = 20;

    [Space]
    
    [Header("#### References ####")]
    public Slider slider;
    public GameObject g_entitiesDetector;
    private EntitiesDetector entitiesDetector;

    void Start(){
        slider.maxValue = CountUntilExplosion;
        entitiesDetector = g_entitiesDetector.GetComponent<EntitiesDetector>();
    }

    void Update(){
        CountDownClock();
    }

    void CountDownClock(){
        CountUntilExplosion -= Time.deltaTime;
        slider.value = CountUntilExplosion;
        if(CountUntilExplosion <= 0)
        {
            for(int i = 0; i < entitiesDetector.EntitiesDetected.Count; i++){
            if(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>() != null){
                entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>().UpdateLife(-ExplosionDamage);
                // if(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>().UpdateLife(-ExplosionDamage)){
                //     entitiesDetector.EntitiesDetected.RemoveAt(i);
                // }
            }
        }
            Destroy(gameObject);
        }
    }
}
