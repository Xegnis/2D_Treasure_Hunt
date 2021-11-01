using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProgress : MonoBehaviour
{
    [SerializeField]
    GameManagerLvl1.Marker id;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerLvl1.Progress(id);
            Destroy(gameObject);
        }
    }
}
