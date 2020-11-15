using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour
{
    public KeyCode key;
    public UnityEvent ev;
    public string buttonName;
    public bool isActive = true;
    public bool oneUseOnly;

    public void press()
    {
        if(isActive)ev.Invoke();
        if (oneUseOnly) isActive = false;
        
    }
    
}
