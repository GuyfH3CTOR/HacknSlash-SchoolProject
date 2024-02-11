using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadSpellData
{        
    static public string[] ReadString()
    {
        string path = "Assets/Scripts/Spell/Skills - Spells.tsv";
        
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();        
        reader.Close();

        string[] datas = text.Split("\n");

        for(int id=1 ; id<datas.Length; id++)
        {
            // Debug.Log("ID : " + id + ", Value : " + datas[id]);
            CreateSpellData(datas[id]);
        }
        return datas;
    }

    static public Spell CreateSpellData(string data)
    {
        string[] datas = data.Split('\t');
        Spell spell = new Spell(datas);

        return (spell);   
    }
}
