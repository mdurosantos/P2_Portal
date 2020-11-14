using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void openDoor ()
    {
        anim.CrossFade("AutomaticDoorOpen");
        //AudioManager.PlaySound("door");        
    }

    public void closeDoor()
    {
        anim.CrossFade("AutomaticDoorClose");
        //AudioManager.PlaySound("door");
    }

    
}
