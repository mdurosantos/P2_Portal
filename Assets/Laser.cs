using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    LineRenderer m_LineRenderer;
    [SerializeField]
    float m_MaxDistance;
    [SerializeField]
    LayerMask m_CollisionLayerMask;
    private bool isActive = true;

    private GameOverScript gameOver;

    public bool alreadyShot = false;

    // Update is called once per frame
    void Update()
    {
        m_LineRenderer.enabled = isActive;
        if (!isActive)
        {
            return;
        }
        Vector3 lastPoint = Vector3.forward * m_MaxDistance;
        if (Physics.Raycast(new Ray(m_LineRenderer.transform.position, m_LineRenderer.transform.forward),
            out RaycastHit l_RaycastHit, m_MaxDistance, m_CollisionLayerMask.value))
        {
            lastPoint = Vector3.forward * l_RaycastHit.distance;
            if(l_RaycastHit.collider.tag == "Player")
            {
                if(gameOver == null)
                {
                    gameOver = GameOverScript.GetInstance();
                }

                if(!alreadyShot)
                {
                    gameOver.GameOver();
                    alreadyShot = true;
                } 
            }
            else if (l_RaycastHit.collider.tag == "RefractionCube")
            {
                //Reflect ray     
                l_RaycastHit.collider.GetComponent<RefractionCube>().CreateRefraction();
            }
            //Other collisions 
            else if (l_RaycastHit.collider.tag == "LaserSwitch")
            {
                l_RaycastHit.collider.GetComponent<LaserSwitch>().laserSwitchActivate();
            }
            else if (l_RaycastHit.collider.tag == "Enemy")
            {
                Destroy(l_RaycastHit.collider.gameObject);
                AudioManager.PlaySound("fired");
            }
        }
        m_LineRenderer.SetPosition(1, lastPoint);
    }

    public void activateLaser()
    {
        isActive = true;
    }

    public void deactivateLaser()
    {
        isActive = false;
    }

    public void ReactivateLaser()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.5f);
        alreadyShot = false;
    }
}
