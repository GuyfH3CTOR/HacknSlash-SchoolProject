using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Player Ref
    private Transform g_Player;

    public float f_MovSpeed = 10;
    public float MinDist = 5;
    public float MaxDist = 10;

    void Start()
    {
        Initialization();
    }

    void Update()
    {
        FollowPlayer();
    }

    public virtual void Initialization()
    {
        g_Player = GameObject.Find("Player").transform;
    }

    public void FollowPlayer()
    {
        transform.LookAt(g_Player);

        if(Vector3.Distance(transform.position,g_Player.position) >= MinDist)
        {
            transform.position += transform.forward * f_MovSpeed * Time.deltaTime;
        }
    }
}
