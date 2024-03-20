using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBomb : Spell_Prefab
{
    // #######################################################################################

    // [Header("Settings")]
    // // public
    // public Spell spellData;
    // public float destroyAfterPrefabUseDelay = 2;

    // [Header("References")]
    // // public
    // public SpellAffordances spellAffordances;

    // #######################################################################################

    [Header("#### Countdowns ####")]
    // public
    public float CountUntilHit = 5;
    public float HitEffectDelayToHit = 0;
    // private
    private float InUseEffectCountdown;
    [Space]
    [Header("#### References ####")]
    public GameObject zoneEffect;
    public Slider slider;
    public EntitiesDetector entitiesDetector;
    public PlayEffect playEffectCharge;
    public PlayEffect playEffectExplosion;

    // =======================================================================================

    void Start(){
        Intitialization();
        AtUse();
    }

    void Update(){
        InUse();
    }

    public override void Intitialization(){
        // Set In Use Effect
        slider.maxValue = CountUntilHit;
        InUseEffectCountdown = CountUntilHit;
        CountUntilHit = CountUntilHit - HitEffectDelayToHit;
        // Wait for explosion
        StartCoroutine(InUseDelay());
        base.Intitialization();
    }

    // =======================================================================================

    public override void AtUse(){
        spellAffordances.CallAffordances(AffordancesCall.atUse,Action.start);
        base.AtUse();
    }

    public override void InUse(){
        // Update In Use Effect
        InUseEffectCountdown -= Time.deltaTime;
        slider.value = InUseEffectCountdown;
        base.InUse();
    }

    public override void EndUse(){
        base.EndUse();
    }

    public override void OnHit(Entity_Damagable _entity_Damagable){
        base.OnHit(_entity_Damagable);
    }

    // =======================================================================================

    IEnumerator InUseDelay(){
        // Debug.Log("CountUntilHit : "+CountUntilHit);
        // Debug.Log("HitEffectDelay : "+HitEffectDelayToHit);
        yield return new WaitForSeconds(CountUntilHit);
        spellAffordances.CallAffordances(AffordancesCall.onHit,Action.start);
        StartCoroutine(OnHitDelay());
    }

    IEnumerator OnHitDelay(){
        // zoneEffect.SetActive(false);
        yield return new WaitForSeconds(HitEffectDelayToHit);
        // Hide In Use Effect
        zoneEffect.SetActive(false);
        // Damage Entity_Damagable
        for(int i = 0; i < entitiesDetector.EntitiesDetected.Count; i++){
            if(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>() != null){
                OnHit(entitiesDetector.EntitiesDetected[i].GetComponent<Entity_Damagable>());
            }
        }
        StartCoroutine(DestroyPrefabDelay());
    }
}
