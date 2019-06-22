using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public FLoatRef wallSlideVelocity;

    [Header("Wall Detectors")]
    public float collisionRadius;
    public Transform bottomOffset;
    public Transform leftOffset;
    public Transform rightOffset;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Debug - Wall Detection")]
    [SerializeField] private bool showDetection;
    [SerializeField] private Color debugCollisionColor;

    [Header("Condition/State (Debug purpose)")]
    [SerializeField] private bool onWallSlide;
    [SerializeField] private bool onGround;
    [SerializeField] private bool onWall;
    [SerializeField] private bool onLeftWall;
    [SerializeField] private bool onRightWall;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControlKeys;
    [SerializeField] private PlayerData dataToStore;
    private Rigidbody2D rb;

    private void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        debugCollisionColor = Color.red;
        rb = GetComponent<Rigidbody2D>();

        if (dataToStore != null)
        {
            dataToStore.wallSlideAble = true;
            dataToStore.wallSlideVelocity = wallSlideVelocity;
        }
    }
    private void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        onLeftWall = Physics2D.OverlapCircle(leftOffset.position, collisionRadius, groundLayerMask);
        onRightWall = Physics2D.OverlapCircle(rightOffset.position, collisionRadius, groundLayerMask);

        onGround = Physics2D.OverlapCircle(bottomOffset.position, collisionRadius, groundLayerMask);

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

            Gizmos.DrawWireSphere(bottomOffset.position, collisionRadius);
            Gizmos.DrawWireSphere(leftOffset.position, collisionRadius);
            Gizmos.DrawWireSphere(rightOffset.position, collisionRadius);
        }
    }

    public void UpdateOnSlide(bool input)
    {
        onWallSlide = input;
    }

    private void DoWallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, wallSlideVelocity.data);
    }

}
