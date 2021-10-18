using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    [SerializeField]
    GameObject flashlight;

    [SerializeField]
    float initialTime;

    float timeLeft;

    void Start()
    {
        timeLeft = initialTime;
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            flashlight.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }

        timeLeft -= Time.deltaTime;
    }
}
