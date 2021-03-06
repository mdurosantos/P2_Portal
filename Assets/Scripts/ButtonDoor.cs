﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    int elementsInButton = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Player")
        {
            elementsInButton++;
            if (elementsInButton==1)
                door.GetComponent<AutomaticDoor>().openDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Player")
        {
            elementsInButton--;
            if (elementsInButton == 0)
                door.GetComponent<AutomaticDoor>().closeDoor();
        }
    }




}
