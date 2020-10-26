using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "Escena2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>() != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
