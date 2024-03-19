using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemLog : MonoBehaviour
{
    [Header("#### Settings ####")]
    // public
    public float timeBeforeLogIsGone = 5.0f;
    // private
    private float time;

    [Header("#### References ####")]
    // public
    public TextMeshProUGUI LogText;
    public ContentSizeFitter contentSizeFitter;

    public void SetLog(Item item){
        // Debug.Log("Item Log : 1 "+item.itemName);
        LogText.text = new string("+ 1 "+item.itemName);
        StartCoroutine(LogDestroyTimer());
    }

    IEnumerator LogDestroyTimer(){
        yield return new WaitForSeconds(timeBeforeLogIsGone);
        Destroy(gameObject);
    }
}
