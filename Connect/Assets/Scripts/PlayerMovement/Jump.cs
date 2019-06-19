﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates jump so that jumping up is slower than falling down.
/// Source: Board To Bits Games
/// https://www.youtube.com/watch?v=7KiK0Aqtmzc
/// </summary>

public class Jump : MonoBehaviour
{
    [SerializeField] private bool betterJumpOn;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    [Header("Animator parameters Variables")]
    [SerializeField] private bool useAnimator;
    [SerializeField] private string jumpTrigger;

    [Header("Ground Detector")]
    public Transform groundLoc;
    public float collisionRadius;
    public LayerMask groundLayerMask;

    [Header("Debug - Ground Detection")]
    [SerializeField] private bool showDetector;
    [SerializeField] private Color debugCollisionColor;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private InputControllerData playerControlKeys;

    [Header("Condition/State (Debug purpose)")]
    [SerializeField] private bool canJump;
    [SerializeField] private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        onGround = Physics2D.OverlapCircle(groundLoc.position, collisionRadius, groundLayerMask);   // 8 is the ground layer
        UpdateCanJump(onGround);

        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------
        if (Input.GetKeyDown(playerControlKeys.jump))
        {
            if (canJump)
            {
                // Animation
                if(animator != null && useAnimator)
                {
                    
                    animator.SetTrigger(jumpTrigger);
                }

                DoJump();
            }
        }


        if (betterJumpOn)
        {
            if (rb.velocity.y < 0)
            {
                // Increase gravity when falling
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(playerControlKeys.jump))
            {
                // When jumping up while not pressing the jump button:
                // Increase gravity
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showDetector)
        {
            Gizmos.color = debugCollisionColor;

            Gizmos.DrawWireSphere(groundLoc.position, collisionRadius);
        }
    }
    public void UpdateCanJump(bool input)
    {
        canJump = input;
    }
    private void DoJump()
    {
        rb.velocity += Vector2.up * jumpVelocity;
    }
}
