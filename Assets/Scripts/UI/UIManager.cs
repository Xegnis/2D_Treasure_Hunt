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
    GameObject prompt;


    static GameObject s_textBox;
    static TMP_Text s_mainText;
    static GameObject s_prompt;
    void Awake()
    {
        s_textBox = textBox;
        s_mainText = mainText;
        s_prompt = prompt;
    }

    public static void ShowDialogue (string text)
    {
        s_mainText.text = text;
        s_textBox.SetActive(true);
        PlayerMovement.canMove = false;
    }

    void HideDialogue ()
    {
        s_textBox.SetActive(false);
        PlayerMovement.canMove = true;
    }

    public static void ShowPrompt ()
    {
        s_prompt.SetActive(true);
    }

    public static void HidePrompt ()
    {
        s_prompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !PlayerMovement.canMove)
        {
            HideDialogue();
        }
    }
}
