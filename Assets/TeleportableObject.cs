using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportableObject : MonoBehaviour
{
    [SerializeField] float teleportOffset;

    Vector3 teleportPosition;
    Vector3 teleportForward;
    bool teleporting;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Portal portal))
        {
            Vector3 l_Position = portal.virtualPortal.transform.InverseTransformPoint(transform.position);
            Vector3 l_Direction = portal.virtualPortal.transform.InverseTransformDirection(transform.forward);
            teleportPosition = portal.otherPortal.transform.TransformPoint(l_Position);
            teleportForward = portal.otherPortal.transform.TransformDirection(l_Direction);

            teleportPosition += teleportForward * teleportOffset;
            //GetComponent<CharacterController>().enabled = false;
            teleporting = true;
            
        }
    }

    private void LateUpdate()
    {
        if (teleporting)
        {
            transform.position = teleportPosition;
            transform.forward = teleportForward;
            teleporting = false;
            if (TryGetComponent(out FPSController controller)) controller.setYawAndPitch();
            if (TryGetComponent(out Rigidbody rigidbody)) rigidbody.velocity = Vector3.zero;
            //GetComponent<CharacterController>().enabled = true;
        }
    }
}
