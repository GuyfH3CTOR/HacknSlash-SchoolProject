using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPoolBackground : MonoBehaviour
{
    public Image background;

    public IEnumerator NotEnoughMana(){
        // Interface Feedback
        background.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        background.material.color = Color.white;
    }
}
