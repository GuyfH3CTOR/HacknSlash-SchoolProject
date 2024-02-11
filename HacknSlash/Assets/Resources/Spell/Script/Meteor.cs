using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float CountUntilDestroy = 30;
    public float CountDown = 0;

    void Update()
    {
        CountDownClock();
    }
    void CountDownClock()
    {
        CountDown += Time.deltaTime;
        if(CountDown >= CountUntilDestroy)
        {
            Destroy(gameObject);
        }
    }
}
