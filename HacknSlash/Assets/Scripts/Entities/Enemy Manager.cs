using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Entity_Damagable
{
    [Header("========== Enemy ==========")]
    
    [Header("#### Settings ####")]
    public float f_MovSpeed = 10;
    public float MinDist = 5;
    public float MaxDist = 10;

    [Space]

    [Header("#### References ####")]
    private Transform g_Player;


    void Start()
    {
        Initialization();
    }

    public override void Initialization()
    {
        base.Initialization();
        EnemyInitialization();
    }

    void Update()
    {
        EnemyUpdate();
    }

    public virtual void EnemyUpdate()
    {
        // SliderUpdate();
        // FollowPlayer();
    }

    public virtual void EnemyInitialization()
    {
        g_Player = GameObject.Find("Player").transform;
    }

    // public void FollowPlayer()
    // {
    //     transform.LookAt(g_Player);

    //     if(Vector3.Distance(transform.position,g_Player.position) >= MinDist)
    //     {
    //         transform.position += transform.forward * f_MovSpeed * Time.deltaTime;
    //     }
    // }
}
