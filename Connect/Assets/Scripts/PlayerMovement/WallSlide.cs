using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public float wallSlideVelocity;

    [Header("Wall Detectors")]
    public Vector2 bottomOffset;
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    public float collisionRadius;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Debug - Wall Detection")]
    [SerializeField] private bool showDetection;
    [SerializeField] private Color debugCollisionColor;

    [Header("Condition/State (Debug purpose)")]
    [SerializeField] private bool onWallSlide;
    [SerializeField] private bool onGround;

    public bool onWall { get; private set; }
    public bool onLeftWall { get; private set; }
    public bool onRightWall { get; private set; }

    [Header("Components")]
    [SerializeField] private InputControllerData playerControlKeys;
    private Rigidbody2D rb;

    private void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        debugCollisionColor = Color.red;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayerMask);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayerMask);

        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayerMask);

        onWall = onLeftWall || onRightWall;
        UpdateOnSlide(onWall && !onGround && !Input.GetKey(playerControlKeys.jump));

        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------
        if (onWallSlide)
        {
            DoWallSlide();
        }
    }

    private void OnDrawGizmos()
    {
        if(showDetection)
        {
            Gizmos.color = debugCollisionColor;

            Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        }
    }

    public void UpdateOnSlide(bool input)
    {
        onWallSlide = input;
    }

    private void DoWallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, wallSlideVelocity);
    }

}
