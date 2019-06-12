using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public float wallSlideVelocity;

    [Header("Wall Detection")]
    public float leftOffset;
    public float rightOffset;
    public float collisionRadius;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Debug")]
    public Color debugCollisionColor;
    [SerializeField] private bool onWallSlide;
    [SerializeField] private bool showDetection;
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
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.right * rightOffset, collisionRadius, groundLayerMask);
        onWall = onLeftWall || onRightWall;

        UpdateOnSlide(onWall);
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
