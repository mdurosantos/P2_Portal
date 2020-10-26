using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private Canvas end;
    private bool ended = false;
    public void OnTriggerEnter()
    {
        end.enabled = true;
        Time.timeScale = 0.0f;
        ended = true;
    }

    void Update()
    {
        if(ended)
        {
            if(Input.GetKey(KeyCode.Space))
                Application.Quit();
        }
    }
}
