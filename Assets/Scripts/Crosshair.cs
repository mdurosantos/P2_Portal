using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    Sprite crosshair_start;
    [SerializeField]
    Sprite crosshair_blue;
    [SerializeField]
    Sprite crosshair_orange;
    [SerializeField]
    Sprite crosshair_full;

    [SerializeField]
    GameObject portal_blue;
    [SerializeField]
    GameObject portal_orange;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (portal_blue.activeSelf && portal_orange.activeSelf)
            image.sprite = crosshair_full;
        else if (portal_blue.activeSelf && !portal_orange.activeSelf)
            image.sprite = crosshair_blue;
        else if (!portal_blue.activeSelf && portal_orange.activeSelf)
            image.sprite = crosshair_orange;
        else
            image.sprite = crosshair_start;
    }
}
