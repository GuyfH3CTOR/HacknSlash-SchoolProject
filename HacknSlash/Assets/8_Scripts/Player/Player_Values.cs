using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player_Values : MonoBehaviour
{        
    [Header("========== Life ==========")]
    [Header("Values")]
    public float maxLife;
    public float currentLife;
    public float lifeRegeneration = 2f;
        
    [Header("========== Mana ==========")]
    [Header("Values")]
    public float maxMana;
    public float currentMana;
    public float manaRegeneration = 2f;

    [Header("========== Level ==========")]
    [Header("Values")]
    public int currentLevel = 1;
    public float currentXP = 0;
    public float nextLevelxp = 100;

    [Header("========== Divers ==========")]
    [Header("Slider Ref")]
    public GameObject g_lifeSlider;
    public GameObject g_manaSlider;
    public GameObject g_levelSlider;

    [Header("TextMeshPro Ref")]
    public GameObject g_levelText;
    
    [Header("Slider Components")]
    private Slider lifeSlider;
    private Slider manaSlider;
    private Slider levelSlider;

    [Header("TextMeshPro Components")]
    private TMP_Text levelText;
    
    [Header("========== Debug ==========")]
    public bool miseAJour;
    public bool AddXP;
    public float XPtoAdd;

    void Start()
    {
        Initialization();
    }
    void Update()
    {
        Debuging();
        Regeneration();
    }
    void Debuging()
    {
        if(miseAJour)
        {
            Initialization();
            miseAJour = !miseAJour;
        }
        if(AddXP)
        {
            UpdateXP(XPtoAdd);
            AddXP = !AddXP;
        }
    }

    void Initialization()
    {
        // #### Get Slider Components ####
        lifeSlider = g_lifeSlider.GetComponent<Slider>();
        manaSlider = g_manaSlider.GetComponent<Slider>();
        levelSlider = g_levelSlider.GetComponent<Slider>();

        // #### Get TextMeshPro Components ####
        levelText = g_levelText.GetComponent<TMP_Text>();
        
        // #### Set slider maxValue ####
        lifeSlider.maxValue = maxLife;
        manaSlider.maxValue = maxMana;
        levelSlider.maxValue = nextLevelxp;
        
        // #### Set slider Value ####
        lifeSlider.value = currentLife;
        manaSlider.value = currentMana;
        levelSlider.value = currentXP;

        // #### Set TextMeshPro Value ####
        levelText.text = currentLevel.ToString();
    }

    // #### Update Values ####
    public void UpdateLifeValue(float _UpdateLifeValue) {
        currentLife = currentLife + _UpdateLifeValue;
        UpdateLifeSlider();
    }
    public void UpdateManaValue(float _UpdateManaValue) {
        currentMana = currentMana + _UpdateManaValue;
        UpdateManaSlider();
    }
    public void UpdateXP(float _UpdateXPValue) {
        currentXP = currentXP + _UpdateXPValue;
        levelSlider.value = currentXP;

        if(currentXP >= nextLevelxp) {
            float _AdditionalXP = currentXP - nextLevelxp;
            UpdateLevel(_AdditionalXP);
        }
    }
    public void UpdateLevel(float _AdditionalXP) {
         // Add Level
        currentLevel++;
        // Set Next Level Xp requirement
        nextLevelxp = nextLevelxp + (5 * (nextLevelxp / 100));
        currentXP = 0;
        // Update Visual + TODO : add particules on player and SLider Animation
        levelSlider.maxValue = nextLevelxp;
        levelText.text = currentLevel.ToString();
        GameObject.Find("Player").GetComponentInChildren<PlayEffect>().Play();
        // Resend AdditionalXP
        UpdateXP(_AdditionalXP);
    }

    // #### Regeneration ####
    void Regeneration()
    {
        if(currentLife < maxLife) {
            currentLife = Mathf.Clamp(currentLife + (Time.deltaTime * lifeRegeneration), 0, maxLife);
            UpdateLifeSlider();
        }
        if(currentMana < maxMana){
            currentMana = Mathf.Clamp(currentMana + (Time.deltaTime * manaRegeneration), 0, maxMana);
            UpdateManaSlider();
        }
    }

    // #### Update Slider ####
    void UpdateLifeSlider() {
        lifeSlider.value = currentLife;
    }
    void UpdateManaSlider() {
        manaSlider.value = currentMana;
    }

    // #### Update Slider Max Values ####
    public void UpdateLifeMaxValue(float _UpdateValue) {
        // #### Update Life MaxValue ####        
        maxLife = maxLife + _UpdateValue;
        // #### Set LifeSlider maxValue ####
        lifeSlider.maxValue = maxLife;
    }
    public void UpdateManaMaxValue(float _UpdateValue) {
        // #### Update Life MaxValue ####        
        maxMana = maxMana + _UpdateValue;
        // #### Set LifeSlider maxValue ####
        manaSlider.maxValue = maxMana;
    }
}
