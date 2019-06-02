using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk/Run/Wallslide")]
    public float walkVelocity;
    public float runVelocity;
    public float wallslideVelocity;
    public float dashVelocity;

    [Header("Jump")]
    public float jumpVelocity;

    [Header("Player State")]
    [SerializeField] private bool isRunning;
    [SerializeField] private bool canMove;
    [SerializeField] private bool canJump;
    [SerializeField] private bool canWallDash;

    private PlayerCollisionDetection collisionDetection;
    private Rigidbody2D rb;

    private void Start()
    {
        canMove = true;
        collisionDetection = GetComponent<PlayerCollisionDetection>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------

        UpdateCanMove(collisionDetection.onGround);
        UpdateCanJump(collisionDetection.onGround);
        UpdateCanDash(!collisionDetection.onGround && collisionDetection.onWall);

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            UpdateRunning(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            UpdateRunning(false);
        }

        //--------------------------------------------------------------
        // Execute action
        //--------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                Jump();
            }
            else if(canWallDash)
            {
                Vector2 dir;
                if (collisionDetection.onLeftWall)
                {
                    dir = new Vector2(1, 1); 
                }
                else
                {
                    dir = new Vector2(-1, 1);
                }
                WallDash(dir);
            }
        }

        if (canMove)
        {
            if(isRunning)
            {
                Run(input);
            }
            else
            {
                Walk(input);
            }
        }

    }
    ///--------------------------------------------------------------
    /// Methods below are for updating player conditions
    ///--------------------------------------------------------------
    public void UpdateRunning(bool input)
    {
        isRunning = input;
    }

    public void UpdateCanMove(bool input)
    {
        canMove = input;
    }
    public void UpdateCanJump(bool input)
    {
        canJump = input;
    }
    public void UpdateCanDash(bool input)
    {
        canWallDash = input;
    }

    ///--------------------------------------------------------------
    /// Methods below are commands for the character
    ///--------------------------------------------------------------
    //private void ChangeDirection(Vector2 dir)
    //{
    //    // Vector projection
    //    rb.velocity = rb.velocity.magnitude * dir;
    //}

    private void Jump()
    {
        rb.velocity += Vector2.up * jumpVelocity;
    }

    private void WallDash(Vector2 dir)
    {
        Vector2 v = dir.normalized * dashVelocity;
        //rb.velocity = new Vector2(v.x, v.y + rb.velocity.y);
        rb.velocity = new Vector2(v.x, v.y);
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
