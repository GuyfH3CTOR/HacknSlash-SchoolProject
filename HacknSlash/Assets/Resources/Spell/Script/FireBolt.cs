using UnityEngine;
using System.Collections;
using UnityEditor;

public class FireBolt : Spell_Prefab
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
    
    [Header("FireBall : Settings")]
    // public
    public float shootVelocity;
    public float inUseDelay;
    // private
    private bool isDestroying;

    [Header("FireBall : References")]
    // private
    private GameObject playerArm;
    public GameObject spellBody;
    private Rigidbody rb;

    // =======================================================================================

    void Start(){
        Intitialization();
    }

    void Update(){
    }

    public override void Intitialization(){
        //addForce to projectile
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootVelocity);
        // Effect
        spellAffordances.CallAffordances(AffordancesCall.atUse,Action.start);
        // Start Destroy Countdown
        StartCoroutine(InUseDelay());

        base.Intitialization();
    }

    // =======================================================================================

    public override void AtUse(){
        base.AtUse();
    }

    public override void InUse(){
        base.InUse();
    }

    public override void EndUse(){
        base.EndUse();
    }

    public override void OnHit(Entity_Damagable _entity_Damagable){

        // stop a second collider to activate 
        isDestroying = true;
        
        // Hide Body + Stop Velocity
        spellBody.SetActive(false);
        rb.velocity = Vector3.zero;
        
        // Effect
        spellAffordances.CallAffordances(AffordancesCall.atUse,Action.end);
        spellAffordances.CallAffordances(AffordancesCall.onHit,Action.start);
            
        base.OnHit(_entity_Damagable);
        
        StopCoroutine(InUseDelay());
        StartCoroutine(base.DestroyPrefabDelay());
    }

    // =======================================================================================

    void OnCollisionEnter(Collision _collider){
        if(_collider.gameObject.GetComponentInChildren<Entity_Damagable>() && !isDestroying){
            OnHit(_collider.gameObject.GetComponentInChildren<Entity_Damagable>());
        }else if(!isDestroying){
            OnHit(null);
        }
    }

    IEnumerator InUseDelay(){
        yield return new WaitForSeconds(inUseDelay);
        
        // Hide Body + Stop Velocity + stop effect
        spellBody.SetActive(false);
        rb.velocity = Vector3.zero;
        spellAffordances.CallAffordances(AffordancesCall.atUse,Action.end);

        StartCoroutine(base.DestroyPrefabDelay());
    }
}
