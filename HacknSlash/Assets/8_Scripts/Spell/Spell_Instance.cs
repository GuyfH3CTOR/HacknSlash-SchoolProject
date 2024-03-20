using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spell_Instance
{
    private int Spelllevel;

    [SerializeReference] protected int ID;
    [SerializeReference] protected string name;
    [SerializeReference] public Sprite icon;
    [SerializeReference] public GameObject gameobject;
    [SerializeReference] public string castType;
    [SerializeReference] public int manaCost;
    [SerializeReference] public float spellDamage;
    [SerializeReference] public float loadTime;
    [SerializeReference] public float reloadTime;
    [SerializeReference] public float useTime;
    [SerializeReference] public float speed;
    [SerializeReference] public float zoneSize;
    [SerializeReference] public int SpellMaxLevel = 100; // not on data

    public bool LoadIcon(string path)
    {
        icon = Resources.Load<Sprite>(path); // Load Path
        // Debug.Log("icon "+path);
        if(icon == null){return false;}else{return true;} // Return statement
    }

    public bool LoadGameObject(string path)
    {
        gameobject = Resources.Load(path) as GameObject; // Load Path
        // Debug.Log("game object "+path);
        if(gameobject == null){return false;}else{return true;} // Return statement
    }

    public virtual bool Increase_Spell_Level()
    {
        Spelllevel = Mathf.Max(Spelllevel++, SpellMaxLevel);

        return true;
    }

    public virtual bool Decrease_Spell_Level()
    {
        Spelllevel = Mathf.Min(Spelllevel--, 0);

        return true;
    }
}
