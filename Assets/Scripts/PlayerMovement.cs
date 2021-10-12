using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashDuration;

    float dashLeft;
    Vector2 dashDir;

    Rigidbody2D rb;

    float xDir;
    float lastFacing = 1;

    bool isGrounded = false, canJump = false, isDashing = false, hasDashed = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        if (xDir != 0)
        {
            lastFacing = xDir;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                canJump = true;
            else if (!hasDashed)
            {
                hasDashed = true;
                isDashing = true;
                dashDir = new Vector2(xDir, 0);
                if (dashDir.x == 0)
                {
                    dashDir = new Vector2(lastFacing, 0);
                }
                rb.gravityScale = 0;
            }
        }

        if (isDashing && dashLeft > 0)
        {
            dashLeft -= Time.deltaTime;
        }
        else if (dashLeft <= 0)
        {
            isDashing = false;
            dashLeft = dashDuration;
            rb.gravityScale = 1;
        }
    }

    void FixedUpdate()
    {
        if (canJump)
        {
            Jump();
        }
        rb.velocity = new Vector2(xDir * moveSpeed, rb.velocity.y);
        if (isDashing)
        {
            rb.velocity = dashDir * dashSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            hasDashed = false;
            isGrounded = true;
        }
    }

    void Jump ()
    {
        if (!isGrounded)
            return;
        canJump = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}