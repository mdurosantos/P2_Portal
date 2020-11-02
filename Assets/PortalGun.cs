using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{

    [SerializeField]
    float maxShootDistance = 200.0f;
    [SerializeField] LayerMask portalRaycastMask;

    [SerializeField]
    Transform portalPreview;
    [SerializeField] Transform portalA;
    [SerializeField] Transform portalB;

    [SerializeField] Camera cameraPlayer;
    bool isValid;

    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            isValid = putPreview();
        }
        portalPreview.gameObject.SetActive(isValid);

        //Extraer función do seguinte
        if (Input.GetMouseButtonUp(0) && isValid)
        {
            portalA.gameObject.SetActive(true);
            portalA.position = portalPreview.position;
            portalA.forward = portalPreview.forward;
        }
        if (Input.GetMouseButtonUp(1) && isValid)
        {
            portalB.gameObject.SetActive(true);
            portalB.position = portalPreview.position;
            portalB.forward = portalPreview.forward;
        }
    }

    bool putPreview()
    {
        Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        if (Physics.Raycast(r, out RaycastHit hit, maxShootDistance, portalRaycastMask))
        {
            portalPreview.position = hit.point;
            portalPreview.forward = hit.normal;
            return portalPreview.GetComponent<PortalPreview>().isValidPosition(cameraPlayer.transform);
        }
        
        return false;
    }
}
