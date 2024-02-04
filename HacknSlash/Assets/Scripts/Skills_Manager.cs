using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Skills_Manager
{
    private string s_skill_name;
    private int i_skill_level;
    private int i_skill_max_level = 100;

    [SerializeReference] protected int ID;
    [SerializeReference] protected Texture2D Icon;
    [SerializeReference] protected string Name;
    [SerializeReference] protected string Type;
    [SerializeReference] protected int NivMax;
    [SerializeReference] protected float Damage;
    [SerializeReference] protected float ManaCost;
    [SerializeReference] protected float CastTime;

    public bool LoadIcon(string path)
    {
        Icon = Resources.Load(path) as Texture2D;
        if(Icon == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public virtual bool Increase_Skill_Level()
    {
        i_skill_level = Mathf.Max(i_skill_level++, i_skill_max_level);

        return true;
    }

    public virtual bool Decrease_Skill_Level()
    {
        i_skill_level = Mathf.Min(i_skill_level--, 0);

        return true;
    }
}
