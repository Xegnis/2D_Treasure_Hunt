using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{
    Image im;
    void Awake()
    {
        im = GetComponent<Image>();
    }
    void Update()
    {
        im.color = new Color(0, 0, 0, Mathf.Max(0, im.color.a - Time.deltaTime));
        if (im.color.a <= 0)
            im.enabled = false;
    }
}
