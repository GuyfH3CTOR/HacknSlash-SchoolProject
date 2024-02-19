using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Entity_Damagable : MonoBehaviour
{    
    [Header("========== Damagable ==========")]

    [Header("#### Settings ####")]
    // public
    public float baseLife = 100;
    // private
    private float currentLife;
    private float maxLife;

    [Space]
    
    [Header("#### References ####")]
    // Public
    public GameObject Slider;
    // private
    private Slider lifeSlider;

    void Start()
    {
        Initialization();
    }

    public virtual void Initialization()
    {
        // #### Life Slider ####
        // Get slider Component
        lifeSlider = Slider.GetComponent<Slider>();
        // Set Base Values
        currentLife = baseLife;
        maxLife = baseLife;
        // Set Slider Values
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = currentLife;
    }

    public void UpdateLife(float value)
    {
        currentLife = currentLife + value;
        lifeSlider.value = currentLife;
        Slider.SetActive(true);

        StartCoroutine(ColorEffect());

        // Debug.Log(currentLife);
        if(currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator ColorEffect()
    {
        Material _mat = GetComponent<Renderer>().material;
        Color _color = GetComponent<Renderer>().material.color;

        _color = _mat.color;
        _mat.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _mat.color = _color;
    }
}
