using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectre : EnemyManager
{
    public float f_TimeSpectre = 2;
    public float f_TimeNormal = 2;
    private float f_TimeCoroutine;

    public Material m_Normal;
    public Material m_Spectre;
    
    private bool b_IsPhasing = false;
    private Collider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        PhaseManager();
    }

    public override void Initialization()
    {
        base.Initialization();
        m_Collider = GetComponent<Collider>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void PhaseManager()
    {
        if(b_IsPhasing)
        {
            // Debug.Log("is not Spectre");
            GetComponent<Renderer>().material = m_Spectre;

            f_TimeCoroutine = f_TimeSpectre;
            StartCoroutine(Phasing());
        }
        else
        {
            // Debug.Log("is Spectre");
            GetComponent<Renderer>().material = m_Normal;

            f_TimeCoroutine = f_TimeNormal;
            StartCoroutine(Phasing());
        }
    }

    IEnumerator Phasing()
    {        
        b_IsPhasing = !b_IsPhasing;
        m_Collider.enabled = b_IsPhasing;

        yield return new WaitForSeconds(f_TimeCoroutine);
        PhaseManager();
    }
}