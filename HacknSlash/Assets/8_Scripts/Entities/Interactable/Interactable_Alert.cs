using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Alert : MonoBehaviour
{
    [Header("#### References ####")]
    public GameObject alertIcon;
    public AudioSource alertSound;

    public void Use(){
        if(alertSound != null)alertSound.Play(0);
    }
    public void AlertOn(){
        if(alertIcon != null)alertIcon.SetActive(true);
    }

    public void AlertOff(){
        if(alertIcon != null)alertIcon.SetActive(false);
    }
}
