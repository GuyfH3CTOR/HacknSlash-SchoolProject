using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadData
{
    [MenuItem("Tools/Load_Data/Spells")]
        
    static public string[] ReadString()
    {
        string path = "Assets/Data/Skills - Feuille 1.tsv";
        
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

    static public Spell_Manager CreateSpellData(string data)
    {
        string[] datas = data.Split('\t');
        Spell_Manager spell = new Spell_Manager(datas);

        return (spell);   
    }
}
