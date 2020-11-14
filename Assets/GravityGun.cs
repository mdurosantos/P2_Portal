using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    Rigidbody attachedBody;
    enum GravityGunState { attaching, attached}
    GravityGunState currentGravityGunState;

    [SerializeField] Transform attachTransform;
    Vector3 initialPosition;
    Quaternion initialRotation;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float throwForce = 200f;


    private void Update()
    {
        if (!attachedBody && Input.GetMouseButtonDown(2))
        {
            attachedBody = gravityShoot();
        }
        else if (attachedBody && Input.GetKeyDown(KeyCode.E))
            detachObject(throwForce);
        else if (attachedBody && Input.GetMouseButtonDown(2))
            detachObject(0);
        else
        {
            if(attachedBody != null)
            {
                switch (currentGravityGunState)
                {
                    case GravityGunState.attaching:

                        updateAttaching();
                        break;
                    case GravityGunState.attached:
                        updateAttached();
                        break;
                }
            }
        }
        
        
    }

    private void updateAttaching()
    {
        attachedBody.MovePosition(attachedBody.position
            + (attachTransform.position - attachedBody.position).normalized * moveSpeed * Time.deltaTime);
        attachedBody.rotation = Quaternion.Lerp(initialRotation, attachTransform.rotation,
            (attachedBody.position - initialPosition).magnitude / (attachTransform.position - initialPosition).magnitude);
        if ((attachedBody.position - attachTransform.position).magnitude < 0.1f)
            currentGravityGunState = GravityGunState.attached;
    }

    private void updateAttached()
    {
        attachedBody.transform.position = attachTransform.position;
        attachedBody.transform.rotation = attachTransform.rotation;
    }

    private void detachObject(float force)
    {
        attachedBody.isKinematic = false;
        attachedBody.AddForce(attachTransform.forward * force);
        attachedBody = null;
    }

    Rigidbody gravityShoot()
    {
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f)), out RaycastHit hit, 200.0f))
        {
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb == null) return null;
            rb.isKinematic = true;
            initialPosition = rb.transform.position;
            initialRotation = rb.transform.rotation;
            currentGravityGunState = GravityGunState.attaching;
            return rb;
        }
        return null;
    }
}
