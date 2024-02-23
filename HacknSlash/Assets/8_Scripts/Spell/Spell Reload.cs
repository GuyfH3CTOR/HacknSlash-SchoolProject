using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellReload : MonoBehaviour
{
    public bool isLoaded = true;
    public float LoadTime;
    private float Load;
    private float maxLoad;

    void Update()
    {
        if(!isLoaded)
        {
            Load -= Time.deltaTime;
            GetComponent<Slider>().value = Load;
            if(Load <= 0)
            {
                isLoaded = true;
            }
        }
    }

    public void SetSliderValue(float maxValue)
    {
        GetComponent<Slider>().maxValue = maxValue;
        maxLoad = maxValue;
    }

    public void ResetLoading()
    {
        Load = maxLoad;
        isLoaded = false;
    }
}
