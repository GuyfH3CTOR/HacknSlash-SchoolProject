using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AffordancesCall{
    atUse,
    inUse,
    endUse,
    onHit
}
public enum Action{
    start,
    end
}

public class SpellAffordances : MonoBehaviour
{
    [Serializable]
    public class Affordances{
        public ParticleSystem[] particuleSystems;
        public AudioSource[] audioSources;
    }

    [Header("==== Affordances ====")]
    public Affordances atUseAffordances;
    public Affordances inUseAffordances;
    public Affordances endUseAffordances;
    public Affordances onHitAffordances;

    [Header("==== Debug ====")]
    public AffordancesCall affordancesToCall;
    public Action actionToCall;
    public bool debug;

    public void CallAffordances(AffordancesCall affordancesCall, Action action){
        // CallAffordances the desired Affordance
        switch(affordancesCall)
        {
            case AffordancesCall.atUse:
                // Debug.Log("CallAffordances : atUse");
                UseAffordance(atUseAffordances, action);
                break;
            case AffordancesCall.inUse:
                // Debug.Log("CallAffordances : inUse");
                UseAffordance(inUseAffordances, action);
                break;
            case AffordancesCall.endUse:
                // Debug.Log("CallAffordances : endUse");
                UseAffordance(endUseAffordances, action);
                break;
            case AffordancesCall.onHit:
                // Debug.Log("CallAffordances : onHit");
                UseAffordance(onHitAffordances, action);
                break;
            default:
                // Debug.Log("CallAffordances : Nothing");
                break;
        }
    }

    private void UseAffordance(Affordances affordances, Action action){
        // Use the correct Action on Affordances
        // Start Affordances
        if(action == Action.start){
            // Debug.Log("Action : Start");
            // Action on particleSystems
            foreach(var particleSystem in affordances.particuleSystems){
                particleSystem.Play();
            }
            // Action on audioSources
            foreach(var audioSource in affordances.audioSources){
                audioSource.Play(0);
            }
        }else 
        // Stop Affordances
        if(action == Action.end){
            // Debug.Log("Action : End");
            // Action on particleSystems
            foreach(var particleSystem in affordances.particuleSystems){
                particleSystem.Stop();
            }
            // Action on audioSources
            foreach(var audioSource in affordances.audioSources){
                audioSource.Stop();
            }

        }
    }

    // =======================================================================================
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! DEBUG !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // =======================================================================================

    void Update(){
        if(debug){
            debug = !debug;
            CallAffordances(affordancesToCall, actionToCall);
        }
    }
}
