using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public float wallSlideVelocity;

    [Header("Wall Detectors")]
    public float leftOffset;
    public float rightOffset;
    public float collisionRadius;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Debug - Wall Detection")]
    [SerializeField] private bool showDetection;
    [SerializeField] private Color debugCollisionColor;

    [Header("Condition/State (Debug purpose)")]
    [SerializeField] private bool onWallSlide;

    public bool onWall { get; private set; }
    public bool onLeftWall { get; private set; }
    public bool onRightWall { get; private set; }

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
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.right * leftOffset, collisionRadius, groundLayerMask);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.right * rightOffset, collisionRadius, groundLayerMask);
        onWall = onLeftWall || onRightWall;
        UpdateOnSlide(onWall);

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

            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.right * leftOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.right * rightOffset, collisionRadius);
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
