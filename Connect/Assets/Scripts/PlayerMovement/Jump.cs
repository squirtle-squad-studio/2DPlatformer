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
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    [Header("GroundDetection")]
    public float groundLoc;
    public float collisionRadius;
    public LayerMask groundLayerMask;
    [SerializeField] private bool onGround;
    [SerializeField] private Color debugCollisionColor = Color.red;

    private Rigidbody2D rb;
    [SerializeField] private InputControllerData playerControlKeys;

    [Header("Debug")]
    public bool betterJumpOn;
    [SerializeField] private bool showDetector;
    [SerializeField] private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        if(groundLayerMask == 0) groundLayerMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!betterJumpOn) return;

        onGround = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.up * groundLoc, collisionRadius, groundLayerMask);   // 8 is the ground layer

        UpdateCanJump(onGround);

        if (Input.GetKeyDown(playerControlKeys.jump))
        {
            if (canJump)
            {
                DoJump();
            }
        }

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

    private void OnDrawGizmos()
    {
        if (showDetector)
        {
            Gizmos.color = debugCollisionColor;

            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.up * groundLoc, collisionRadius);
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
