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

    private float scaleFactor = 1.2f;

    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            isValid = putPreview();

            portalPreview.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                portalPreview.GetComponentInChildren<PortalPreview>().ResizePortal(scaleFactor, Input.GetAxis("Mouse ScrollWheel") > 0.0f );
            }
        }
        else
        {
            portalPreview.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        portalPreview.gameObject.SetActive(isValid);

        createPortal(Input.GetMouseButtonUp(0), portalA);
        createPortal(Input.GetMouseButtonUp(1), portalB);
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

    private void createPortal(bool buttonUp, Transform portal)
    {
        if(buttonUp &&  isValid)
        {
            portal.gameObject.SetActive(true);
            portal.position = portalPreview.position;
            portal.forward = portalPreview.forward;
            portal.localScale = portalPreview.localScale;
            portalPreview.GetComponent<PortalPreview>().InitialScale();
            AudioManager.PlaySound("portalgun");
        }
    }
}
