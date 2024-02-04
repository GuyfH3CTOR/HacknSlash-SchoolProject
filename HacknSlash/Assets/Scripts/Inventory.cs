using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv;

    public void AddItem(Item item)
    {
        inv.Add(item);
    }

    public void TakeItem()
    {
        
    }
}
