using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CastType{
    instantly,
    continuously
}

public class Spell_Manager : MonoBehaviour
{
    [Header("Settings")]
    // SpellSlot
    public List<GameObject> spellSlots = new List<GameObject>();
    private int selected_SpellSlot;
    // SpellSlot Script
    private List<SpellSlot_Script> spellSlot_Scripts = new List<SpellSlot_Script>();
    private SpellSlot_Script selected_SpellSlot_Sript;

    [Header("References")]
    // Spell
    public Spell_Scroller spell_Scroller;
    public List<Spell> spells = new List<Spell>();
    // selected Spell
    private Spell selected_Spell;
    // Casted Spell
    private GameObject casted_Spell;
    // Other
    private GameObject player;
    private GameObject playerArm;
    private Player_Values player_Values;
    private Stats stats;
    // Audio
    public AudioSource audioSource;
    public AudioClip audioNotEnoughMana;
    public AudioClip audioNotLoaded;

    // =======================================================================================

    void Start(){
        Initialization();

        // SpellSlot
        spell_Scroller.SpellSlotsInitialization(spellSlots, spells);       
    }

    void Initialization(){
        // Get Private References
        player = GameObject.Find("Player");
        playerArm = GameObject.Find("Arm");
        player_Values = player.GetComponent<Player_Values>();
        stats = player.GetComponent<Stats>();

        // Get Spells !!!! To redo
        string[] datas = LoadSpellData.ReadString();
        for(int id = 1; id < datas.Length; id++)
        {
            // Debug.Log("spell ID : " + id + ", Value : " + datas[id]);
            Spell spell = LoadSpellData.CreateSpellData(datas[id]);
            spells.Add(spell);}
            
        // Get spellSlots Scripts
        foreach(var spellSlot in spellSlots) spellSlot_Scripts.Add(spellSlot.GetComponent<SpellSlot_Script>());
        for(int i = 0; i < spellSlot_Scripts.Count; i++) spellSlot_Scripts[i].SetSliderValue(spells[i].reloadTime, spells[i].useTime, this);
    }

    void Update(){
        MouseInput();
    }

    void MouseInput(){
        // Left mouse button Inputs
        if(Input.GetKeyDown(KeyCode.Mouse0) && SpellUseCondition()) StartCast();
        if(Input.GetKeyUp(KeyCode.Mouse0) && selected_SpellSlot_Sript.isLoaded) EndCast(selected_Spell, selected_SpellSlot_Sript, casted_Spell);
    }

    // =======================================================================================

    public void SetSelectedSpell(int _SelectedSpell){
        // Debug.Log("SetSelectedSpell : "+ _SelectedSpell);

        selected_SpellSlot = _SelectedSpell;
        // selected_SpellSlot_Sript = spellSlot_Scripts[_SelectedSpell];

        // selected_SpellSlot = spellSlots[_SelectedSpell-1];
    }

    bool SpellUseCondition(){
        // What spell are we talking about 
        selected_SpellSlot_Sript = spellSlot_Scripts[selected_SpellSlot];
        selected_Spell = spells[selected_SpellSlot];

        // is spellSlot loaded
        if(selected_SpellSlot_Sript.isLoaded == true){
            // does player have enough mana
            if(selected_Spell.manaCost <= player_Values.currentMana){
                return true;
            }else{
                audioSource.clip = audioNotEnoughMana;
                audioSource.Play(0);

                return false;
            }
        }else{
            audioSource.clip = audioNotLoaded;
            audioSource.Play(0);

            return false;
        }
    }

    // =======================================================================================

    void StartCast(){

        casted_Spell = Instantiate(selected_Spell.gameobject, playerArm.transform.position, playerArm.transform.rotation, GameObject.Find("ProjectileInGame").transform);
        casted_Spell.GetComponent<Spell_Prefab>().spellData = selected_Spell;
        
        CastType castType = (CastType)System.Enum.Parse(typeof(CastType), selected_Spell.castType);
        
        switch(castType){
            case CastType.instantly:
                selected_SpellSlot_Sript.ResetLoading();
                // Debug.Log("CastType : instantly");
                break;
            case CastType.continuously:
                selected_SpellSlot_Sript.StartUsing(selected_Spell, selected_SpellSlot_Sript, casted_Spell);
                // Debug.Log("CastType : continuously");
                break;
            default:
                // Debug.Log("GetCastType : Nothing");
                break;
        }
    }

    public void EndCast(Spell _selected_Spell, SpellSlot_Script _selected_SpellSlot_Sript, GameObject _casted_Spell){
        CastType castType = (CastType)System.Enum.Parse(typeof(CastType), _selected_Spell.castType);
        
        switch(castType){
            case CastType.instantly:
                // Debug.Log("CastType : instantly");
                break;
            case CastType.continuously:
                _selected_SpellSlot_Sript.ResetLoading();
                _selected_SpellSlot_Sript.StopUsing();
                _casted_Spell.GetComponent<Spell_Prefab>().EndUse();
                // Debug.Log("CastType : continuously");
                break;
            default:
                // Debug.Log("GetCastType : Nothing");
                break;
        }
    }
}
