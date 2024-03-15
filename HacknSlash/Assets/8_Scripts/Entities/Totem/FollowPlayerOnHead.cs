using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOnHead : MonoBehaviour
{
    [Header("#### Settings ####")]
    public bool followPlayer;
    public float onheadHeight;

    [Header("#### References ####")]
    public Transform player;

    void Update()
    {
        if(followPlayer){
            transform.position = player.position + new Vector3(0,onheadHeight,0);
        }
    }

    public void SwitchFollowState(){
        followPlayer = !followPlayer;
    }
}
