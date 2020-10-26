using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }


    public void OpenFirstDoor()
    {
        anim.CrossFade("FirstDoorOpen");
        AudioManager.PlaySound("door");
    }


    
}
