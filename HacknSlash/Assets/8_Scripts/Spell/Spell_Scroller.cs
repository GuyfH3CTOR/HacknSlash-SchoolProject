using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell_Scroller : MonoBehaviour
{
    [Header("Settings")]
    // public
    public int SlotSelected;
    public Vector2 slotSelectedSize = new Vector2(200,200);
    private Vector2 slotUnselectedSize;

    [Header("References")]
    // public
    public Spell_Manager spell_Manager;
    public List<GameObject> spellSlots = new List<GameObject>();
    public AudioSource audioSource;

    // =======================================================================================

    void Start(){
    }
    
    void Initialization(){
        // Start Game with the first spell selected
        SlotSelected = 1;
        UpdateSelection();
    }

    void Update(){
        Scroll();
    }

    void Scroll(){
        // Get Mouse Scroll Input
        float _scrollvar = Input.mouseScrollDelta.y * 0.1f;

        // Scroll Up Check
        if(_scrollvar > 0.1) 
        {
            SlotSelected++;
            if(SlotSelected > spellSlots.Count) // Check if superior to number of skills length
            {
                SlotSelected = 1; // Loop to first skill
            }
            UpdateSelection();
        }

        // Scroll Down Check
        if(_scrollvar < -0.1) 
        {
            SlotSelected--;
            if(SlotSelected < 1) // Check if inferior than 1
            {
                SlotSelected = spellSlots.Count;  // Loop to last skill
            }
            UpdateSelection();
        }
    }

    // =======================================================================================

    void UpdateSelection()
    {
        // Set Sizes
        foreach(var spellSlot in spellSlots)spellSlot.GetComponent<RectTransform>().sizeDelta = slotUnselectedSize;
        spellSlots[SlotSelected-1].GetComponent<RectTransform>().sizeDelta = slotSelectedSize;
        
        audioSource.Play(0);
        spell_Manager.SetSelectedSpell(SlotSelected-1);
    }

    // =======================================================================================

    public void SpellSlotsInitialization(List<GameObject> _spellSlots,List<Spell> spells){
        spellSlots = _spellSlots;

        // Set spellSlot image
        for(int i = 0; i < _spellSlots.Count; i++){
            // Set image
            if(spells[i].icon != null){
                _spellSlots[i].GetComponent<Image>().sprite = spells[i].icon;
            }else{
                Debug.Log("cannot set image to spellslot : "+ i +", because icon is null");
            }
        }

        // Get Size of Slots
        slotUnselectedSize = spellSlots[2].GetComponent<RectTransform>().sizeDelta;

        // Set First Selected Spell
        UpdateSelection();
    }
}
