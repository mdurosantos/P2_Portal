﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    public Transform virtualPortal;
    [SerializeField]
    public Portal otherPortal;
    public Camera cameraPortal;
    [SerializeField]
    Camera playerCamera;
    [SerializeField]
    float clipPlaneOffset = 1.0f;

    private Vector3 initialScale;

    public void Awake()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        Vector3 local_position = virtualPortal.InverseTransformPoint(playerCamera.transform.position);
        otherPortal.cameraPortal.transform.position = otherPortal.transform.TransformPoint(local_position);

        Vector3 local_direction = virtualPortal.InverseTransformDirection(playerCamera.transform.forward);
        otherPortal.cameraPortal.transform.forward = otherPortal.transform.TransformDirection(local_direction);

        otherPortal.cameraPortal.nearClipPlane = (transform.position - playerCamera.transform.position).magnitude + clipPlaneOffset;

    }

    /*public float resizing()
    {
        return transform.localScale / initialScale;
    }

    /*private void ResizePortal()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f ) // forward
        {
            transform.localScale *= scaleFactor;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            transform.localScale /= scaleFactor;
        }
    }*/
}
