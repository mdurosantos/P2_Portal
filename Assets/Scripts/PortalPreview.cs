using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPreview : MonoBehaviour
{
    [SerializeField]
    List<Transform> validPoints;
    [SerializeField] string portalEnableTag;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float maxValidDistance = 1f;
    [SerializeField] float maxValidAngle = 20f;

    private Vector3 initialScale;
    private float maxScale;
    private float minScale;

    public void Awake()
    {
        initialScale = transform.localScale;
        maxScale = initialScale.x * 2.0f;
        minScale = initialScale.x * 0.5f;
    }

    public bool isValidPosition(Transform cameraPlayer)
    {
        foreach(Transform valid in validPoints)
        {
            Ray ray = new Ray(cameraPlayer.position, valid.position - cameraPlayer.position);
            if(Physics.Raycast(ray,out RaycastHit hit, float.MaxValue, layerMask))
            {
                if (!hit.transform.CompareTag(portalEnableTag)) return false;
                if ((hit.point - valid.position).magnitude > maxValidDistance) return false;
                if(Vector3.Angle(hit.normal,valid.forward) > maxValidAngle) return false;
                
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public void ResizePortal(float scaleFactor, bool augment)
    {
        Vector3 scale = transform.localScale;
        if(augment)
        {
            scale.x *= scaleFactor;
            scale.y *= scaleFactor;
        }
        else 
        {
            scale.x /= scaleFactor;
            scale.y /= scaleFactor;
        }
        
        if(scale.x >= minScale && scale.x <= maxScale)
            transform.localScale = scale;
    }

    public void InitialScale()
    {
        transform.localScale = initialScale;
    }
}
