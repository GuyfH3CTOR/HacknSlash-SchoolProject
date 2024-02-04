using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
    public List<Spell_Manager> l_spells = new List<Spell_Manager>();

    void Start()
    {
        Getdata();
    }

    void Getdata()
    {
        string[] datas = LoadData.ReadString();

        for(int id=1 ; id<datas.Length; id++)
        {
            // Debug.Log("ID : " + id + ", Value : " + datas[id]);

            Spell_Manager spell = LoadData.CreateSpellData(datas[id]);
            l_spells.Add(spell);
        }
    }
}
