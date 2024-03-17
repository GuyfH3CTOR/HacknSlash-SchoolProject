using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Entity_Damagable : MonoBehaviour
{    
    [Header("#### Drop Settings ####")]
    // public
    public int gold = 10;

    [Header("#### Health Settings ####")]
    // public
    public float baseLife = 100;
    public float xpDrop;
    // private
    private float currentLife;
    private float maxLife;

    [Space]
    
    [Header("#### References ####")]
    // Public
    public GameObject Slider;
    public GameObject body;
    // private
    [HideInInspector] public Renderer bodyRenderer;
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

        bodyRenderer = body.GetComponent<Renderer>();
    }

    public bool UpdateLife(float value)
    {
        currentLife = currentLife + value;
        lifeSlider.value = currentLife;
        Slider.SetActive(true);

        StartCoroutine(ColorEffect());

        // Debug.Log(currentLife);
        if(currentLife <= 0)
        {
            if(xpDrop != 0)GameObject.Find("Player").GetComponent<Player_Values>().UpdateXP(xpDrop);
            GameObject.Find("Player").GetComponent<Player_Values>().UpdateGold(gold);
            Destroy(gameObject);
            return true;
        }else{
            return false;
        }
    }
    
    IEnumerator ColorEffect()
    {
        Material _mat = bodyRenderer.material;
        Color _color = bodyRenderer.material.color;

        _color = _mat.color;
        _mat.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _mat.color = _color;
    }
}
