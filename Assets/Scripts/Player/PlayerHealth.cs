using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    int maxHealth;
    [SerializeField]
    float cooldown;

    [Header("UI")]
    [SerializeField]
    Image blackScreen;
    [SerializeField]
    GameObject heart;
    [SerializeField]
    Transform canvas;

    [Header("Position")]
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform startingPoint;

    SpriteRenderer playerSpr;
    static GameObject[] hearts = new GameObject[10];
    static float countdown;
    static bool isCooling = false;
    static int health;

    void Awake()
    {
        playerSpr = GetComponentInParent<SpriteRenderer>();
    }

    void Start()
    {
        health = maxHealth;
        countdown = cooldown;
        for (int i = 0; i < health; i ++)
        {
            hearts[i] = Instantiate(heart);
            hearts[i].transform.SetParent(canvas);
            hearts[i].transform.localPosition = new Vector3(-600 + i * 50f, 300f, 0);
            hearts[i].transform.SetAsFirstSibling();
        }
    }

    void Update()
    {
        if (isCooling)
        {
            playerSpr.color = new Color(playerSpr.color.r, playerSpr.color.g, playerSpr.color.b, 0.6f);
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                isCooling = false;
                countdown = cooldown;
                playerSpr.color = new Color(playerSpr.color.r, playerSpr.color.g, playerSpr.color.b, 1f);
            }
        }

        if (health == 0)
        {
            PlayerMovement.canMove = false;
            blackScreen.color = new Color(0, 0, 0, Mathf.Min(1, blackScreen.color.a + Time.deltaTime * 0.5f));
            if (blackScreen.color.a >= 1)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }

        if (blackScreen != null)
            blackScreen.transform.SetAsLastSibling();
    }

    public static void takeDamage (int damage)
    {
        if (isCooling)
            return;
        CameraShake.Shake();
        if (health > damage)
        {
            health -= damage;
            isCooling = true;
            for (int i = 0; i < damage; i ++)
            {
                Destroy(hearts[health + i]);
            }
        }
        else
        {
            for (int i = 0; i < health; i ++)
            {
                Destroy(hearts[i]);
            }
            health = 0;

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            takeDamage(1);
        }
        else if (collision.CompareTag("Trap"))
        {
            takeDamage(2);
            player.position = startingPoint.position;
        }
    }
}
