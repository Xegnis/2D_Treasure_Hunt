using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject textBox;

    [SerializeField]
    TMP_Text mainText;

    [SerializeField]
    GameObject promt;
    
    public void ShowDialogue (string text)
    {
        mainText.text = text;
        textBox.SetActive(true);
        PlayerMovement.canMove = false;
    }

    void HideDialogue ()
    {
        textBox.SetActive(false);
        PlayerMovement.canMove = true;
    }

    public void ShowPrompt ()
    {
        promt.SetActive(true);
    }

    public void HidePrompt ()
    {
        promt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !PlayerMovement.canMove)
        {
            HideDialogue();
        }
    }
}
