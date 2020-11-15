using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    [SerializeField] GameObject door;
    int elementsInButton = 0;
    bool isOpen = false;
    float maxTime = 0.1f;
    float time;

    private void Start()
    {
        time = maxTime;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            laserSwitchDeactivate();
        }
    }

    public void laserSwitchActivate()
    {
        time = maxTime;
        if (!isOpen)
        {    
            door.GetComponent<AutomaticDoor>().openDoor();
            isOpen = true;
        }
        
    }

    private void laserSwitchDeactivate()
    {
        if (isOpen)
        {
            door.GetComponent<AutomaticDoor>().closeDoor();
            isOpen = false;
        }
        
    }

    

    
}
