using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpray : MonoBehaviour
{
    [Header("Settings")]
    // public
    // private
    private bool isBeingUsed;

    [Header("References")]
    // public
    public GameObject playerArm;
    public AudioSource audioSource;
    public ParticleSystem particules;
    // private
    private List<Entity_Damagable> enemyInCollider = new List<Entity_Damagable>();

    void Start(){
        playerArm = GameObject.Find("Arm");
    }

    // ======== Update Side ========

    void Update(){
        FollowPlayerPosition();
        if(isBeingUsed)Spell();
    }

    void FollowPlayerPosition(){
        transform.rotation = playerArm.transform.rotation;
        transform.position = playerArm.transform.position;
    }

    void Spell(){
        
    }

    void OntriggerStay(Collider[] collider){
        enemyInCollider.Clear();
        foreach(Collider c in collider){
            if(c.gameObject.GetComponent<Entity_Damagable>()){
                enemyInCollider.Add(c.gameObject.GetComponent<Entity_Damagable>());
            }
        }
    }

    // -------- Stop Update Side --------

    public void UseSpell(){
        // Activate Spell
        isBeingUsed = true;
        // Activate FeedBack
        SpellFeedBack();
    }


    public void StopSpell(){
        // Stop Spell
        isBeingUsed = false;
        // Destroy Spell after all Feedbacks stopped
        if(!audioSource.isPlaying && !particules.isPlaying){
            Destroy(gameObject);
        }
    }

    void SpellFeedBack(){
        particules.Play();
        audioSource.Play(0);
    }
}
