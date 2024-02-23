using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
    public List<Spell> l_spells = new List<Spell>();

    void Start()
    {
        Getdata();
    }

    void Getdata()
    {
        string[] datas = LoadSpellData.ReadString();

        for(int id=1 ; id<datas.Length; id++)
        {
            // Debug.Log("ID : " + id + ", Value : " + datas[id]);

            Spell spell = LoadSpellData.CreateSpellData(datas[id]);
            l_spells.Add(spell);
        }
    }
}
