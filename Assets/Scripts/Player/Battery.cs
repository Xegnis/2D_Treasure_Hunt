using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    [SerializeField]
    Flashlight flashlight;

    [SerializeField]
    float charge;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flashlight.addTime(charge);
            Destroy(gameObject);
        }
    }
}
