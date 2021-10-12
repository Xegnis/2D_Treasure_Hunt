using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Marker {key1, key2, key3};

    static bool[] progress = new bool[3];

    void Start()
    {
        for (int i = 0; i < progress.Length; i++)
        {
            progress[i] = false;
        }
    }

    public static void Progress (Marker marker)
    {
        progress[(int)marker] = true;
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
