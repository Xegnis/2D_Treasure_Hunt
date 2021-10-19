using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField]
    string[] dialogue;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
            {
                string toShow = "";
                for (int i = 0; i < dialogue.Length; i ++)
                {
                    toShow += dialogue[i] + "\n";
                }
                UIManager.ShowDialogue(toShow + "\n[R] to close");
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
            UIManager.ShowPrompt();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.HidePrompt();
        }
    }
}
