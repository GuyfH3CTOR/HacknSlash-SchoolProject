using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    [Header("========== Particles ==========")]
    [Header("References")]
    public AudioSource effectSound;
    public List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    [Header("Debuging")]
    public bool play;

    void Update(){
        // Debuging
        if(play){
            Play();
            play = !play;
        }
    }

    public void Play(){
        // Play all particules in particleSystems with additional Effects
        for(int i = 0; i < particleSystems.Count; i++){
            particleSystems[i].Play();
        }
        effectSound.Play();
    }
}
