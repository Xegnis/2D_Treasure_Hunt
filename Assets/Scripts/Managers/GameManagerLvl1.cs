using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerLvl1 : MonoBehaviour
{
    public enum Marker {key1, key2, key3};

    static bool[] progress = new bool[3];

    [SerializeField]
    TMP_Text text;

    static AudioSource audiosource;

    static int keyCollected;

    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Start()
    {
        for (int i = 0; i < progress.Length; i++)
        {
            progress[i] = false;
        }
        keyCollected = 0;
    }

    void Update()
    {
        text.text = "Keys to Collect: " + (3 - keyCollected);
    }

    public static void Progress (Marker marker)
    {
        progress[(int)marker] = true;
        keyCollected++;
        audiosource.Play();
    }

    public static bool checkProgress ()
    {
        for (int i = 0; i < progress.Length; i ++)
        {
            if (!progress[i])
                return false;
        }
        return true;
    }
}
