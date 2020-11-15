using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour
{    
    private Vector3 initialScale;

    public void Awake()
    {
        initialScale = transform.localScale;
    }

    public float ActualFactorScale()
    {
        return transform.localScale.x / initialScale.x;
    }

}
