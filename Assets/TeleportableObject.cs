using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportableObject : MonoBehaviour
{
    [SerializeField] float teleportOffset;

    Vector3 teleportPosition;
    Vector3 teleportForward;
    bool teleporting;

    private Portal actuaPortal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Portal portal))
        {
            actuaPortal = portal;

            if (portal.otherPortal.isActiveAndEnabled)
            {
                Vector3 l_Position = portal.virtualPortal.transform.InverseTransformPoint(transform.position);
                Vector3 l_Direction = portal.virtualPortal.transform.InverseTransformDirection(transform.forward);
                teleportPosition = portal.otherPortal.transform.TransformPoint(l_Position);
                teleportForward = portal.otherPortal.transform.TransformDirection(l_Direction);

                if (TryGetComponent(out Scalable scalable))
                {
                    float actualFactorScale = scalable.ActualFactorScale();
                    float factorScale = actuaPortal.otherPortal.GetComponent<Portal>().ScaleFactor();

                    if(actualFactorScale != factorScale)
                    {
                        transform.localScale *= factorScale;
                    }

                    if(actualFactorScale != 1) teleportPosition += teleportForward * (teleportOffset + 2);
                    else teleportPosition += teleportForward * teleportOffset;
                }
                else
                {
                    teleportPosition += teleportForward * teleportOffset;
                }
                //GetComponent<CharacterController>().enabled = false;
                teleporting = true;
            }
   
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
            if (TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.velocity = teleportForward.normalized * rigidbody.velocity.magnitude;
                
            } 
            //GetComponent<CharacterController>().enabled = true;
        }
    }
}
