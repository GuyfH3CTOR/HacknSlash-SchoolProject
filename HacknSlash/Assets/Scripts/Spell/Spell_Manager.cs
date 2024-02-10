using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[Serializable]

public class Spell_Manager : Skills_Manager
{
    public Spell_Manager(string[] spell)
    {
        ID = int.Parse(spell[0]);
        Name = spell[1];
        Type = spell[2];
        NivMax = int.Parse(spell[3]);
        Damage = float.Parse(spell[4]);
        ManaCost = float.Parse(spell[5]);
        CastTime = float.Parse(spell[6]);
        LoadIcon(spell[7]);
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
