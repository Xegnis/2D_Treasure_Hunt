using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] 
    UnityEvent lightSwitch;

    [SerializeField]
    AudioSource soundEffect;

    [SerializeField]
    AudioClip sound;

    bool pressed, colliding;
 
     void Awake() 
    {
        if (lightSwitch == null)
        {
            lightSwitch = new UnityEvent();
        }
     }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colliding = true;
            UIManager.ShowPrompt("J");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (pressed)
            {
                soundEffect.clip = sound;
                soundEffect.Play();
                lightSwitch.Invoke();
                pressed = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colliding = false;
            UIManager.HidePrompt();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && colliding)
        {
            pressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            pressed = false;
        }
    }
}
