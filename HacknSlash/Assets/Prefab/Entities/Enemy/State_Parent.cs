using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class State_Parent : MonoBehaviour
{
    private enum EnemyState
    {
        Disable,
        Alert,
        Search,
        Attack
    };
    private GameObject player;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    // private void ManageStates()
    // {
    //     switch(state)
    //     {
    //         case EnemyState.Disable:
    //             break;
    //         case EnemyState.Alert:
    //             transform.Rotate(new Vector3(0,45,0)*Time.deltaTime);
    //             break;
    //         case EnemyState.Search:
    //             break;
    //         case EnemyState.Attack:
    //             // .destination = player.transform.position;
    //             break;
    //     }
    // }
}
