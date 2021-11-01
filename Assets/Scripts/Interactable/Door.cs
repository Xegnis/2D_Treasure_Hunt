using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameObject keyPanel;

    [SerializeField]
    Image[] keyHoles;

    [SerializeField]
    Sprite[] keyImages;

    [SerializeField]
    Key[] password;

    [SerializeField]
    GameObject indicator;

    public enum Key {Cross, Triangle, Circle};

    static int[] combination = new int[5];

    int selected = 0;


    void Awake()
    {
        for (int i = 0; i < password.Length; i++)
        {
            keyHoles[i].sprite = keyImages[combination[i]];
        }
            
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !PlayerMovement.canMove && keyPanel.activeSelf)
        {
            keyPanel.SetActive(false);
            PlayerMovement.canMove = true;
        }

        if (!keyPanel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            selected --;
            selected = Mathf.Max(0, selected);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            selected ++;
            selected = Mathf.Min(4, selected);
        }

        indicator.transform.localPosition = new Vector2(-320 + selected * 160, 0);

        if (Input.GetKeyDown(KeyCode.J))
        {
            combination[selected]++;
            if (combination[selected] >= 3)
                combination[selected] -= 3;
            keyHoles[selected].sprite = keyImages[combination[selected]];

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            CheckKey();
        }
    }


    void CheckKey ()
    {
        bool correct = true;
        for (int i = 0; i < combination.Length; i ++)
        {
            if (combination[i] != (int)password[i])
            {
                correct = false;
                Debug.Log("wrong" + i);
                break;
            }
        }
        if (correct)
        {
            SceneManager.LoadScene("End");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.ShowPrompt("J");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.J))
        {
            keyPanel.SetActive(true);
            PlayerMovement.canMove = false;
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
