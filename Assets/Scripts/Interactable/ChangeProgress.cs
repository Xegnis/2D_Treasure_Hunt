using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProgress : MonoBehaviour
{
    [SerializeField]
    GameManagerLvl1.Marker id;

    bool add = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!add)
            {
                GameManagerLvl1.Progress(id);
            }
            add = true;
            Destroy(gameObject);
        }
    }
}
