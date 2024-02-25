using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenDomain : MonoBehaviour
{
    [Header("========== Frozen Domain ==========")]
    
    [Header("#### Variables ####")]
    public float CountUntilExplosion = 30;

    void Update()
    {
        CountDownClock();
    }
    void CountDownClock()
    {
        CountUntilExplosion -= Time.deltaTime;
        if(CountUntilExplosion <= 0)
        {
            Destroy(gameObject);
        }
    }
}
