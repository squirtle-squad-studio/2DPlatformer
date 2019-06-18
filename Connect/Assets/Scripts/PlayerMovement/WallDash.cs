using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDash : MonoBehaviour
{
    public float dashVelocity;

    [Header("Animator parameters Variables")]
    [SerializeField] private bool useAnimator;
    [SerializeField] private string wallDashTrigger;

    [Header("Ground/Wall Detectors")]
    public LayerMask groundLayerMask;
    public float collisionRadius;
    public Vector2 bottomOffset;
    public Vector2 leftOffset;
    public Vector2 rightOffset;

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
    [SerializeField] private InputControllerData playerControlKeys;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    { 

        if (groundLayerMask == 0) groundLayerMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayerMask);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayerMask);
        onWall = onLeftWall || onRightWall;

        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayerMask);

        UpdateCanDash(!onGround && onWall);

        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------
        if (Input.GetKey(playerControlKeys.jump))
        {
            if (canWallDash)
            {
                Vector2 dir;
                if (onLeftWall)
                {
                    dir = new Vector2(1, 1);
                }
                else
                {
                    dir = new Vector2(-1, 1);
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

            Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        }
    }

    public void UpdateCanDash(bool input)
    {
        canWallDash = input;
    }
    private void DoWallDash(Vector2 dir)
    {
        Vector2 v = dir.normalized * dashVelocity;
        rb.velocity = v;
    }
}
