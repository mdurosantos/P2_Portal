using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportableObject : MonoBehaviour
{
    [SerializeField] float teleportOffset;

    private Portal otherPortal;
    Vector3 teleportPosition;
    Vector3 teleportForward;
    bool teleporting = false;

    private Transform attached;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Portal portal))
        {
            otherPortal = portal.otherPortal;
            Debug.Log(otherPortal);
            otherPortal.GetComponent<Collider>().enabled = false;
            attached = portal.AttachedTo();
            if(attached != null)attached.GetComponent<Collider>().enabled = false;
            /*Vector3 l_Position = portal.virtualPortal.transform.InverseTransformPoint(transform.position);
            Vector3 l_Direction = portal.virtualPortal.transform.InverseTransformDirection(transform.forward);
            teleportPosition = portal.otherPortal.transform.TransformPoint(l_Position);
            teleportForward = portal.otherPortal.transform.TransformDirection(l_Direction);

            teleportPosition += teleportForward * teleportOffset;
            //GetComponent<CharacterController>().enabled = false;
            teleporting = true;*/
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Portal portal))
        {
            Vector3 objectFromPortal = portal.transform.InverseTransformPoint(transform.position);

            if(objectFromPortal.z <= 0.02)
            {
                if(!teleporting) Teleport(portal, objectFromPortal);
            }
        }
    }

    private void OnTriggerExit()
    {
        teleporting = false;
        if(attached != null)attached.GetComponent<Collider>().enabled = true;
        if(otherPortal != null) otherPortal.GetComponent<BoxCollider>().enabled = true;
    }

    private void Teleport(Portal portal, Vector3 offset)
    {
        teleporting = true;
        transform.position = otherPortal.transform.position + new Vector3(offset.x, + offset.y, offset.z);
        transform.eulerAngles = Vector3.up * (otherPortal.transform.eulerAngles.y - (portal.transform.eulerAngles.y - transform.eulerAngles.y) + 180);
        //Vector3 camLEA = Camera.main.transform.localEulerAngles;
        //camLEA = Vector3.right * (otherPortal.transform.eulerAngles.x + camLEA.x);
        
        if (TryGetComponent(out FPSController controller)) controller.setYawAndPitch();
    }
    
    /*private void LateUpdate()
    {
        if (teleporting)
        {
            transform.position = teleportPosition;
            transform.forward = teleportForward;
            teleporting = false;
            if (TryGetComponent(out FPSController controller)) controller.setYawAndPitch();
            //GetComponent<CharacterController>().enabled = true;
        }
    }*/
}
