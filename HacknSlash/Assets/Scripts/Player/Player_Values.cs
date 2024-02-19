using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player_Values : MonoBehaviour
{
    [Header("Player Values")]
    public float maxLife;
    public float currentLife;
    public float lifeRegeneration = 2f;
    public float maxMana;
    public float currentMana;
    public float manaRegeneration = 2f;

    [Header("Slider Ref")]
    public GameObject g_lifeSlider;
    public GameObject g_manaSlider;
    
    [Header("Slider Components")]
    private Slider lifeSlider;
    private Slider manaSlider;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        // #### Get Slider Components ####
        lifeSlider = g_lifeSlider.GetComponent<Slider>();
        manaSlider = g_manaSlider.GetComponent<Slider>();
        
        // #### Set slider maxValue ####
        lifeSlider.maxValue = maxLife;
        manaSlider.maxValue = maxMana;
        
        // #### Set slider Value ####
        lifeSlider.value = currentLife;
        manaSlider.value = currentMana;
    }

    // #### Update Values ####
    public void UpdateLifeValue(float _UpdateValue)
    {
        currentLife = currentLife + _UpdateValue;
        UpdateLifeSlider();
    }
    public void UpdateManaValue(float _UpdateValue)
    {
        currentMana = currentMana + _UpdateValue;
        UpdateManaSlider();
    }

    // #### Regeneration ####
    void Update()
    {
        if(currentLife < maxLife)
        {
            currentLife = Mathf.Clamp(currentLife + (Time.deltaTime * lifeRegeneration), 0, maxLife);
            UpdateLifeSlider();
        }
        if(currentMana < maxMana)
        {
            currentMana = Mathf.Clamp(currentMana + (Time.deltaTime * manaRegeneration), 0, maxMana);
            UpdateManaSlider();
        }
    }

    // #### Update Slider ####
    void UpdateLifeSlider()
    {
        lifeSlider.value = currentLife;
    }
    void UpdateManaSlider()
    {
        manaSlider.value = currentMana;
    }

    // #### Update Slider Max Values ####
    public void UpdateLifeMaxValue(float _UpdateValue)
    {
        // #### Update Life MaxValue ####        
        maxLife = maxLife + _UpdateValue;
        // #### Set LifeSlider maxValue ####
        lifeSlider.maxValue = maxLife;
    }
    public void UpdateManaMaxValue(float _UpdateValue)
    {
        // #### Update Life MaxValue ####        
        maxMana = maxMana + _UpdateValue;
        // #### Set LifeSlider maxValue ####
        manaSlider.maxValue = maxMana;
    }
}
