using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoisonSpray : Spell_Prefab
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

    [Header("PoisonSpray : References")]
    // private
    private GameObject playerArm;

    // =======================================================================================

    void Start(){
        Intitialization();
    }

    void Update(){
        InUse();
    }

    public override void Intitialization(){
        playerArm = GameObject.Find("Arm");
        spellAffordances.CallAffordances(AffordancesCall.inUse, Action.start);
        base.Intitialization();
    }

    // =======================================================================================

    public override void AtUse(){
        base.AtUse();
    }

    public override void InUse(){
        transform.rotation = playerArm.transform.rotation;
        transform.position = playerArm.transform.position;
        base.InUse();
    }

    public override void EndUse(){
        spellAffordances.CallAffordances(AffordancesCall.inUse, Action.end);
        StartCoroutine(DestroyPrefabDelay());
        base.EndUse();
    }

    public override void OnHit(Entity_Damagable _entity_Damagable){
        base.OnHit(_entity_Damagable);
    }
}
