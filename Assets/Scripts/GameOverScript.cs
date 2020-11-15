using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] Transform player;
    private CheckPointController checkPoint;
    private static GameOverScript instance;
    private bool gameOver = false;



    public void Awake()
    {
        instance = this;
    }

    public static GameOverScript GetInstance()
    {
        return instance;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        this.GetComponent<Canvas>().enabled = true; 
        gameOver = true;  
        player.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        if(gameOver)
        {
            if(Input.GetKey(KeyCode.R))
            {
                if(checkPoint == null)
                {
                    checkPoint = CheckPointController.GetInstance();
                }

                Time.timeScale = 1.0f;
                this.GetComponent<Canvas>().enabled = false;
                player.position = checkPoint.ActualCheckPoint().transform.position;
                gameOver = false;
                player.GetComponent<Collider>().enabled = true;

                GameObject [] lasers = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject [] refractionCubes = GameObject.FindGameObjectsWithTag("RefractionCube");

                foreach (GameObject laser in lasers)
                {
                    if(laser.TryGetComponent(out Laser l))
                        l.alreadyShot = false;
                }
                
                foreach (GameObject refractionCube in refractionCubes)
                {
                    if(refractionCube.TryGetComponent(out RefractionCube l))
                        l.alreadyShot = false;
                }
                //player.GetComponent<HealthSystem>().Revive();

            }
            if(Input.GetKey(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }
}
