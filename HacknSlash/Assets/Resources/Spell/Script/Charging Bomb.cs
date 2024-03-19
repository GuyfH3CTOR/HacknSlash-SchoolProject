using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBomb : MonoBehaviour
{
    [Header("========== Charging Bomb ==========")]
    
    [Header("#### Settings ####")]
    public float ExplosionDamage = 5;
    [Space]
    [Header("#### Countdowns ####")]
    // public
    public float CountUntilHit = 5;
    public float HitEffectDelayToHit = 0;
    public float destroyGameObjectDelay;
    // private
    private float InUseEffectCountdown;
    [Space]
    [Header("#### References ####")]
    public GameObject zoneEffect;
    public Slider slider;
    public EntitiesDetector entitiesDetector;
    public PlayEffect playEffectCharge;
    public PlayEffect playEffectExplosion;

    void Start(){
        // Set In Use Effect
        slider.maxValue = CountUntilHit;
        InUseEffectCountdown = CountUntilHit;
        CountUntilHit = CountUntilHit - HitEffectDelayToHit;
        // Wait for explosion
        StartCoroutine(InUseDelay());
    }

    void Update(){
        InUseUpdate();
    }

    void InUseUpdate(){
        // Update In Use Effect
        InUseEffectCountdown -= Time.deltaTime;
        slider.value = InUseEffectCountdown;
    }

    IEnumerator InUseDelay(){
        // Debug.Log("CountUntilHit : "+CountUntilHit);
        // Debug.Log("HitEffectDelay : "+HitEffectDelayToHit);
        yield return new WaitForSeconds(CountUntilHit);
        // play Hit Effect
        playEffectExplosion.Play();
        StartCoroutine(HitDelay());
    }

    IEnumerator HitDelay(){
        // zoneEffect.SetActive(false);
        yield return new WaitForSeconds(HitEffectDelayToHit);
        // Hide In Use Effect
        zoneEffect.SetActive(false);
        // Damage Entity_Damagable
        for(int i = 0; i < entitiesDetector.EntitiesDetected.Count; i++){
            if(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>() != null){
                entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>().UpdateLife(-ExplosionDamage);
            }
        }
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay(){
        yield return new WaitForSeconds(destroyGameObjectDelay);
        Destroy(gameObject);
    }
}
