using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBomb : MonoBehaviour
{
    [Header("========== Charging Bomb ==========")]
    
    [Header("#### Variables ####")]
    public float CountUntilExplosion = 30;

    [Space]
    
    [Header("#### References ####")]
    public Slider slider;

    void Start()
    {
        slider.maxValue = CountUntilExplosion;
    }

    void Update()
    {
        CountDownClock();
    }
    void CountDownClock()
    {
        CountUntilExplosion -= Time.deltaTime;
        slider.value = CountUntilExplosion;
        if(CountUntilExplosion <= 0)
        {
            Destroy(gameObject);
        }
    }
}
