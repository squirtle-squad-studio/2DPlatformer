using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Outdated", true)]
public class WallDash : MonoBehaviour
{
    public FLoatRef dashVelocity;
    [SerializeField] private Transform dashDirectionOnLeftWall;
    [SerializeField] private Transform dashDirectionOnRightWall;

    [Header("Animator parameters Variables")]
    [SerializeField] private bool useAnimator;
    [SerializeField] private string wallDashTrigger;

    [Header("Ground/Wall Detectors")]
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float collisionRadius;
    [SerializeField] private Transform bottomOffset;
    [SerializeField] private Transform leftOffset;
    [SerializeField] private Transform rightOffset;

    [Header("Debug - Ground/Wall Detectors")]
    [SerializeField] private bool showDetector;
    [SerializeField] private Color debugCollisionColor = Color.red;

    [Header("Debug Purpose")]
    [SerializeField] private bool canWallDash;
    [SerializeField] private bool onGround;
    [SerializeField] private bool onWall;
    [SerializeField] private bool onLeftWall;
    [SerializeField] private bool onRightWall;

    [Header("Components")]
    [SerializeField] private PlayerData dataToStore;
    private EntityInput entityKeys;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    { 

        if (groundLayerMask == 0) groundLayerMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityKeys = GetComponent<EntityInput>();

        if(dataToStore != null)
        {
            dataToStore.wallDashable = true;
            dataToStore.wallDashVelocity = dashVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        onLeftWall = Physics2D.OverlapCircle(leftOffset.position, collisionRadius, groundLayerMask);
        onRightWall = Physics2D.OverlapCircle(rightOffset.position, collisionRadius, groundLayerMask);
        onWall = onLeftWall || onRightWall;

        onGround = Physics2D.OverlapCircle(bottomOffset.position, collisionRadius, groundLayerMask);

        UpdateCanDash(!onGround && onWall);

        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------
        if (entityKeys.jump)
        {
            if (canWallDash)
            {
                Vector2 dir;
                if (onLeftWall)
                {
                    //dir = new Vector2(1, 1);
                    dir = dashDirectionOnLeftWall.position - transform.position;
                }
                else
                {
                    //dir = new Vector2(-1, 1);
                    dir = dashDirectionOnRightWall.position - transform.position;
                }

                if(animator != null && useAnimator)
                {
                    animator.SetTrigger(wallDashTrigger);
                }
                DoWallDash(dir);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(showDetector)
        {
            Gizmos.color = debugCollisionColor;

            Gizmos.DrawWireSphere(bottomOffset.position, collisionRadius);
            Gizmos.DrawWireSphere(leftOffset.position, collisionRadius);
            Gizmos.DrawWireSphere(rightOffset.position, collisionRadius);
        }
    }

    public void UpdateCanDash(bool input)
    {
        canWallDash = input;
    }
    private void DoWallDash(Vector2 dir)
    {
        // Debug.DrawLine(transform.position, dir + (Vector2)transform.position); // Debug
        Vector2 v = dir.normalized * dashVelocity.data;
        rb.velocity = v;
    }
}
