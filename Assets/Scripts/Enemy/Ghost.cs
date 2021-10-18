using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    float facing = 1;

    [Header("Damage")]
    [SerializeField]
    int damage;

    [Header("Raycast")]
    [SerializeField]
    float raycastOffset;
    [SerializeField]
    float raycastDistance;

    // Update is called once per frame
    void Update()
    {
        facing = CheckFacing();
        facing = facing * CheckRaycast();

        transform.eulerAngles = new Vector3(0, 90 + facing * 90, 0);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * facing, 0);
    }

    int CheckFacing ()
    {
        if (rb.velocity.x > 0)
            return 1;
        else if (rb.velocity.x < 0)
            return -1;
        else
            return 0;
    }

    int CheckRaycast ()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.right * facing, raycastDistance);
        if (raycast.collider != null && raycast.collider.CompareTag("Ground"))
        {
            return -1;
        }

        raycast = Physics2D.Raycast(new Vector2(transform.position.x + facing * raycastOffset, transform.position.y), Vector2.down, raycastDistance);
        if (raycast.collider == null)
        {
            return -1;
        }
        return 1;
    }
}
