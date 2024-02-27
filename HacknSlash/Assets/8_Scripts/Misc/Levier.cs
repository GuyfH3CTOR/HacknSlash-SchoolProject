using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Levier : Interactable_Obj
{
    [Serializable]
    public class TriggerClickedEvent : UnityEvent {}
    
    [FormerlySerializedAs("onUse")]
    [SerializeField]
    private TriggerClickedEvent m_OnUse = new TriggerClickedEvent();

    public override void Interaction()
    {
        // Use Lever
        m_OnUse.Invoke();
    }
}
