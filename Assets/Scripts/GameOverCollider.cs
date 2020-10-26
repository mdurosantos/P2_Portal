﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
    private GameOverScript gameOver;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<FPSController>() != null)
        {
            gameOver = GameOverScript.GetInstance();
            gameOver.GameOver();
        }
    }
}
