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

    [Header("#### Color Settings ####")]
    private Material baseMaterial;
    private Color baseColor;
    
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
        SetBaseColorEffect();
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

    void SetBaseColorEffect(){
        baseColor = bodyRenderer.material.color;
    }
    
    IEnumerator ColorEffect()
    {
        // To White
        bodyRenderer.material.color = Color.white;
        // Wait
        yield return new WaitForSeconds(0.2f);
        // To Base Color
        bodyRenderer.material.color = baseColor;
        // Debug.Log("return color");
    }
}
