using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[Serializable]
public class Spell : Spell_Instance
{
    public Spell(string[] spell)
    {
        ID = int.Parse(spell[0]);
        name = spell[1];
        LoadIcon(spell[2]);
        LoadGameObject(spell[3]);
        castType = spell[4];
        manaCost = int.Parse(spell[5]);
        spellDamage = float.Parse(spell[6]);
        loadTime = float.Parse(spell[7]);
        ReloadTime = float.Parse(spell[8]);
        speed = float.Parse(spell[9]);
        zoneSize = float.Parse(spell[10]);
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.Keypad0))
        {
            CastSpell();
        }
    }

    public virtual void CastSpell()
    {

    }
}
