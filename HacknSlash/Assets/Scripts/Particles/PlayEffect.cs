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
    public GameObject[] g_Particles;
    public List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    [Header("Debuging")]
    public bool play;

    void Start(){
        // Get particules of parents and Children components
        for(int i = 0; i < g_Particles.Length; i++){
            particleSystems.Add(g_Particles[i].GetComponent<ParticleSystem>());
        }
    }
    void Update(){
        // Debuging
        if(play){
            Play();
            play = !play;
        }
    }

    public void Play(){
        // Play all particules in particleSystems with additional Effects
        foreach(ParticleSystem particuls in particleSystems){
            particuls.Play();
            effectSound.Play();
        }
    }
}
