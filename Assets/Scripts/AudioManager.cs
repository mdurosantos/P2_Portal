using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip shoot;
    public static AudioClip door;
    public static AudioClip drop;
    public static AudioClip gravity;
    public static AudioClip fired;
    static AudioSource audioSrc;

    void Start()
    {
        shoot = Resources.Load<AudioClip>("shoot");
        door = Resources.Load<AudioClip>("door");
        drop = Resources.Load<AudioClip>("drop");
        gravity = Resources.Load<AudioClip>("gravity");
        fired = Resources.Load<AudioClip>("fired");
        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {   
            case "shoot":
                audioSrc.PlayOneShot(shoot, 0.5f);
                break;
            case "door":
                audioSrc.PlayOneShot(door, 0.3f);
                break;
            case "drop":
                audioSrc.PlayOneShot(drop, 0.4f);
                break;
            case "gravity":
                audioSrc.PlayOneShot(gravity, 0.4f);
                break;
            case "fired":
                audioSrc.PlayOneShot(fired, 0.4f);
                break;
        }
    }
}
