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
}
