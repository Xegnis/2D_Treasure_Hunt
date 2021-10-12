using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField]
    string[] dialogue;

    [SerializeField]
    UIManager um;

    int walk = 0;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
            {
                um.ShowDialogue(dialogue[walk] + "\n\n[R] to exit");
                if (walk < (dialogue.Length - 1))
                    walk++;
            }
        }
    }
}
