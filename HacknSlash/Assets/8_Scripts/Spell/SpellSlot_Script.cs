using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot_Script : MonoBehaviour
{
    public bool isLoaded = true;
    public bool isUsing;
    public Image background;

    private float Load;
    private float use;

    public Slider reloadSlider;
    public Slider useSlider;
    
    public Spell_Manager spell_Manager;

    private Spell selected_Spell;
    private SpellSlot_Script selected_SpellSlot_Sript;
    private GameObject casted_Spell;

    void Update()
    {
        if(!isLoaded)
        {
            Load -= Time.deltaTime;
            reloadSlider.value = Load;
            if(Load <= 0)
            {
                isLoaded = true;
            }
        }
        if(isUsing){
            use += Time.deltaTime;
            useSlider.value = use;
            if(use >= useSlider.maxValue)
            {
                spell_Manager.EndCast(selected_Spell, selected_SpellSlot_Sript, casted_Spell);
            }
        }
    }

    public void SetSliderValue(float _reloadTime, float _useTime, Spell_Manager _spell_Manager)
    {
        reloadSlider.maxValue = _reloadTime;
        useSlider.maxValue = _useTime;
        spell_Manager = _spell_Manager;
    }

    public void StartUsing(Spell _selected_Spell, SpellSlot_Script _selected_SpellSlot_Sript, GameObject _casted_Spell){
        isUsing = true;
        
        selected_Spell = _selected_Spell;
        selected_SpellSlot_Sript = _selected_SpellSlot_Sript;
        casted_Spell = _casted_Spell;
    }
    public void StopUsing(){
        isUsing = false;
        use = 0;
        useSlider.value = use;
    }

    public void ResetLoading()
    {
        Load = reloadSlider.maxValue;
        isLoaded = false;
    }

    public IEnumerator NotLoaded(){
        // Interface Feedback
        background.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        background.material.color = Color.white;
    }
}
