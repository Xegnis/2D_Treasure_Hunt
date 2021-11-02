using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject textBox;

    [SerializeField]
    GameObject prompt;

    [SerializeField]
    GameObject objective;


    static GameObject s_textBox;
    static TMP_Text s_mainText;
    static GameObject s_prompt;
    static TMP_Text s_promptText;

    void Awake()
    {
        s_textBox = textBox;
        s_mainText = s_textBox.GetComponentInChildren<TMP_Text>();
        s_prompt = prompt;
        s_promptText = s_prompt.GetComponentInChildren<TMP_Text>();
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

    public static void ShowPrompt (string prompt)
    {
        s_prompt.SetActive(true);
        s_promptText.text = prompt;
    }

    public static void HidePrompt ()
    {
        s_prompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !PlayerMovement.canMove)
            HideDialogue();

        if (Input.GetKeyDown(KeyCode.O) && objective != null)
            objective.SetActive(!objective.activeSelf);

     
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("Stage_0");
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("Stage_1");
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene("Scene_2");
    }
}
