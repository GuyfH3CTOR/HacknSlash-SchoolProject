using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Player Ref
    private Transform g_Player;

    //Monster Settings
    public float f_PV = 10;
    public float f_MP = 10;
    public float f_Shield = 10;

    public float f_MovSpeed = 10;
    public float MinDist = 5;
    public float MaxDist = 10;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
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

    public virtual void GettingHit(float f_damage)
    {
        Debug.Log("hit");
        
        f_PV = f_PV - f_damage;

        if(f_PV <= 0)
        {
            Destroy(gameObject);
        }
    }
}
