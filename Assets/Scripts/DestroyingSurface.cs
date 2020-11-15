using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingSurface : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy" || other.tag == "Cube" || other.tag == "RefractionCube")
        {
            Destroy(other.gameObject);
            AudioManager.PlaySound("fired");
        }
    }
}
