using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Header("Enemy Type")]
    [SerializeField]
    public EnemyScriptableObject data;

    protected float health;
    protected float moveSpeed;

    protected Rigidbody2D rb;

    void Awake()
    {
        
    }

    void Start()
    {
        health = data.health;
        moveSpeed = data.moveSpeed;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Flashlight"))
        {
            health -= Time.deltaTime;
        }
    }
}
