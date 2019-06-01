using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk/Run/Wallslide")]
    [SerializeField] private bool canMove;
    public float walkVelocity;
    public float runVelocity;
    public float wallslideVelocity;
    public float dashVelocity;

    [Header("Jump")]
    public float jumpVelocity;

    private PlayerCollisionDetection collisionDetection;
    private Rigidbody2D rb;

    private void Start()
    {
        canMove = true;
        collisionDetection = GetComponent<PlayerCollisionDetection>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        Move(direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collisionDetection.onGround)
            {
                Jump();
            }
        }
        if(collisionDetection.onWall)
        {
            if(direction.x < 0 && collisionDetection.onLeftWall)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else if (direction.x > 0 && collisionDetection.onRightWall)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void Move(Vector2 dir)
    {
        // Walk and run
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                Run(dir);
            }
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                ChangeDirection(dir);
            }
            else if (Mathf.Abs(rb.velocity.x) < walkVelocity)
            {
                Walk(dir);
            }
            else if(Mathf.Abs(rb.velocity.x) > walkVelocity)
            {
                ChangeDirection(dir);
            }
        }

    }

    private void ChangeDirection(Vector2 dir)
    {
        // Vector projection
        rb.velocity = rb.velocity.magnitude * dir;
    }

    private void Jump()
    {
        rb.velocity += Vector2.up * jumpVelocity;
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * walkVelocity, rb.velocity.y);
    }

    private void Run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * runVelocity, rb.velocity.y);
    }
}
