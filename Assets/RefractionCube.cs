﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractionCube : MonoBehaviour
{
    [SerializeField]
    LineRenderer m_LineRenderer;
    [SerializeField]
    float m_MaxDistance;
    [SerializeField]
    LayerMask m_CollisionLayerMask;
    bool m_CreateRefraction = true;

    void Update() {
        m_LineRenderer.gameObject.SetActive(m_CreateRefraction);
        m_CreateRefraction =false;
    }

    public void CreateRefraction() {
        m_CreateRefraction =true;
        Vector3 l_EndRaycastPosition=Vector3.forward*m_MaxDistance;
        RaycastHit l_RaycastHit;
        if (Physics.Raycast(new Ray(m_LineRenderer.transform.position, m_LineRenderer.transform.forward),
            out l_RaycastHit, m_MaxDistance, m_CollisionLayerMask.value))  {
            l_EndRaycastPosition =Vector3.forward*l_RaycastHit.distance;
            if (l_RaycastHit.collider.tag=="RefractionCube")    {
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
            else if (l_RaycastHit.transform.gameObject.TryGetComponent(out FPSController player))
            {
                //gameOver();
                Debug.Log("GameOver");
            }
        }
        m_LineRenderer.SetPosition(1, l_EndRaycastPosition); }
}
