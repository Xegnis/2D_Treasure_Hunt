using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProgress : MonoBehaviour
{
    [SerializeField]
    GameManager.Marker id;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Progress(id);
            Destroy(gameObject);
        }
    }
}
