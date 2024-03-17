using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("#### References ####")]
    [Header("==== In ====")]
    public Player_Values player_Values;

    [Header("==== Stats ====")]
    [Header("Currency")]
    public TextMeshProUGUI Gold;

    [Header("Core Stats")]
    public TextMeshProUGUI level;
    public TextMeshProUGUI life;
    public TextMeshProUGUI Armor;
    public TextMeshProUGUI mana;
    public TextMeshProUGUI attackPower;

    public void UpdateStats(){
        // Currency
        Gold.text = player_Values.gold.ToString();
        // Core Stats
        level.text = player_Values.currentLevel.ToString();
        life.text = player_Values.maxLife.ToString();
        // Armor.text = player_Values.currentLevel.ToString();
        mana.text = player_Values.maxMana.ToString();
        // attackPower.text = player_Values.currentLevel.ToString();
    }
}
