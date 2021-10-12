using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField]
    string dialogue;

    [SerializeField]
    UIManager um;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
            {
                um.ShowDialogue(dialogue + "\n\n[R] to close");
            }
            if (gameObject.CompareTag("Finish") && GameManager.checkProgress())
            {
                SceneManager.LoadScene("End");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            um.ShowPrompt();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            um.HidePrompt();
        }
    }
}
