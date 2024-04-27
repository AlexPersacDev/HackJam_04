using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    [SerializeField] private TurnsEventSO turnEvent;
    
    
    public event Action OnChangeturn;
    
    private void OnEnable ()
    {
        //turnEvent.OnChangeTurn += 
    }
    
    
}
