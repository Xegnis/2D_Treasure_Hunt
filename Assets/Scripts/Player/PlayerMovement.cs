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
    float maxFallSpeed;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashDuration;

    float dashLeft;
    Vector2 dashDir;

    Rigidbody2D rb;
    Animator animator;

    float xDir;
    float lastFacing = 1;
    float graivityScale = 0;

    bool isGrounded = false, canJump = false, isDashing = false, hasDashed = false, jumpReleased = false;

    public static bool canMove = true;

    AudioSource audiosource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        graivityScale = rb.gravityScale;
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        animator.SetBool("isJumping", !isGrounded);
        animator.SetFloat("Speed", rb.velocity.magnitude);
        if (rb.velocity.magnitude > 0 && isGrounded)
        {
            if (!audiosource.isPlaying)
                audiosource.Play();
        }
        else
        {
            audiosource.Pause();
        }
        if (!canMove)
            return;
        xDir = Input.GetAxisRaw("Horizontal");
        if (xDir != 0)
        {
            lastFacing = xDir;
        }
        transform.eulerAngles = new Vector3(0, 90 + lastFacing * 90, 0);
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

        if (canJump)
            if (Input.GetKeyUp(KeyCode.Space))
                jumpReleased = true;

        if (isDashing && dashLeft > 0)
        {
            dashLeft -= Time.deltaTime;
        }
        else if (dashLeft <= 0)
        {
            isDashing = false;
            dashLeft = dashDuration;
            rb.gravityScale = graivityScale;
        }

        if (rb.velocity.magnitude > 0 && isGrounded)
        {
            if (!audiosource.isPlaying)
                audiosource.Play();
        }
        else
        {
            audiosource.Pause();
        }

    }

    void FixedUpdate()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (canJump)
        {
            Jump();
        }
        rb.velocity = new Vector2(xDir * moveSpeed, Mathf.Max(rb.velocity.y, -maxFallSpeed));
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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            hasDashed = false;
            isGrounded = true;
            jumpReleased = false;
        }
    }


    void Jump ()
    {
        if (!isGrounded || jumpReleased)
            return;
        canJump = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
