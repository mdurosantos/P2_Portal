using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] Transform spawnTransform;
    public void Spawn()
    {
        if(spawnTransform!= null) Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
        else Instantiate(spawnObject, transform.position, transform.rotation);
    }
}
