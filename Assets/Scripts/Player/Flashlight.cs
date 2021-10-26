using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    GameObject flashlight;

    [SerializeField]
    float initialTime;

    [SerializeField]
    float maxTime;

    [SerializeField]
    Image chargeLeft;

    float timeLeft;

    void Start()
    {
        timeLeft = initialTime;
    }

    void Update()
    {
        timeLeft = Mathf.Min(timeLeft, maxTime);
        chargeLeft.fillAmount = timeLeft / maxTime;
        
        if (!PlayerMovement.canMove)
            return;
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

        if (flashlight.activeSelf)
            timeLeft -= Time.deltaTime;
    }

    public void addTime (float time)
    {
        timeLeft += time;
    }
}
