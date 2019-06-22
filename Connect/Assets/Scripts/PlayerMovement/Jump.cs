using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates jump so that jumping up is slower than falling down.
/// Source: Board To Bits Games
/// https://www.youtube.com/watch?v=7KiK0Aqtmzc
/// </summary>

public class Jump : MonoBehaviour
{
    [SerializeField] private bool betterJumpOn; // Feels floaty
    public FLoatRef jumpVelocity;
    public FLoatRef fallMultiplier;
    public FLoatRef lowJumpMultiplier;

    [Header("Animator parameters Variables")]
    [SerializeField] private bool useAnimator;
    [SerializeField] private string jumpTrigger;

    [Header("Ground Detector")]
    [SerializeField] private Transform groundLoc;
    [SerializeField] private float collisionRadius;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Debug - Ground Detection")]
    [SerializeField] private bool showDetector;
    [SerializeField] private Color debugCollisionColor;

    [Header("Condition/State (Debug purpose)")]
    [SerializeField] private bool canJump;
    [SerializeField] private bool onGround;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControlKeys;
    [SerializeField] private PlayerData dataToStore;
    private Rigidbody2D rb;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if(dataToStore != null)
        {
            dataToStore.jumpAble = true;
            dataToStore.jumpVelocity = jumpVelocity;
            dataToStore.fallMultiplier = fallMultiplier;
            dataToStore.lowJumpMultiplier = lowJumpMultiplier;
        }
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
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier.data - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(playerControlKeys.jump))
            {
                // When jumping up while not pressing the jump button:
                // Increase gravity
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier.data - 1) * Time.deltaTime;
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
        rb.velocity += Vector2.up * jumpVelocity.data;
    }
}
