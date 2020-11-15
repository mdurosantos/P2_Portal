using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresser : MonoBehaviour
{
    List <ButtonEvent> buttonEvents = new List<ButtonEvent>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ButtonEvent bEvent))
            buttonEvents.Add(bEvent);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ButtonEvent bEvent))
            buttonEvents.Remove(bEvent);
    }
    private void Update()
    {
        foreach (ButtonEvent buttonEvent in buttonEvents)
        {
            if (Input.GetKeyDown(buttonEvent.key) && buttonEvent.isActive)
            {
                buttonEvent.press();
            }
            if (buttonEvent.isActive)
                Debug.Log("Press key " + buttonEvent.key + " to activate " + buttonEvent.buttonName);
            else
                Debug.Log(buttonEvent.key + " is not active");
        }
    }
}
