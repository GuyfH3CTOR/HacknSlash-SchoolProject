using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Prefab : MonoBehaviour
{
    [Header("Settings")]
    // public
    public Spell spellData;
    public float destroyAfterUsingPrefabDelay = 2;

    [Header("References")]
    // public
    public SpellAffordances spellAffordances;

    // =======================================================================================

    void Start(){
        Intitialization();
    }

    void Update(){
    }

    public virtual void Intitialization(){
    }

    // =======================================================================================

    public virtual void AtUse(){
    }

    public virtual void InUse(){
    }

    public virtual void EndUse(){
    }

    public virtual void OnHit(Entity_Damagable _entity_Damagable){
        // Debug.Log("hit : "+_entity_Damagable.gameObject);
        if(_entity_Damagable != null)_entity_Damagable.UpdateLife(-spellData.spellDamage);
    }

    // =======================================================================================

    public virtual IEnumerator DestroyPrefabDelay(){
        yield return new WaitForSeconds(destroyAfterUsingPrefabDelay);
        Destroy(gameObject);
    }
}
