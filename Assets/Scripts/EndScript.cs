using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField] Transform player;
    private CheckPointController checkPoint;
    private static EndScript instance;
    private bool gameOver = false;
    public void Awake()
    {
        instance = this;
    }

    public static EndScript GetInstance()
    {
        return instance;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Game over");
        Time.timeScale = 0.0f;
        this.GetComponent<Canvas>().enabled = true; 
        gameOver = true;  
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
                    Debug.Log(checkPoint);
                }
                Debug.Log(checkPoint.ActualCheckPoint());
                Time.timeScale = 1.0f;
                this.GetComponent<Canvas>().enabled = false;
                player.position = checkPoint.ActualCheckPoint().transform.position;
            }
            if(Input.GetKey(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }
}
