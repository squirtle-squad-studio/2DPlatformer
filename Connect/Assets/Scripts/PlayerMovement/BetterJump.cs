using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates jump so that jumping up is slower than falling down.
/// Source: Board To Bits Games
/// https://www.youtube.com/watch?v=7KiK0Aqtmzc
/// </summary>
public class BetterJump : MonoBehaviour
{
    public float fallMultiplier;
    public float lowJumpMultiplier;

    private Rigidbody2D rb;
    private InputControllerData playerControlKeys;

    [Header("Debug")]
    public bool betterJumpOn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControlKeys = GetComponent<PlayerStats>().playerControlKeys;
    }

    // Update is called once per frame
    void Update()
    {
        if (!betterJumpOn) return;
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
