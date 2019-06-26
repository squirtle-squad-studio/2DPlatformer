using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canRun;
    public FLoatRef walkVelocity;
    public FLoatRef runVelocity;

    [Header("AI")]
    [Tooltip("Please have AIController component attached")]
    public bool useAI;

    [Header("Ground detector")]
    [SerializeField] private float collisionRadius;
    [SerializeField] private Transform groundLoc;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Debug - Ground Detector")]
    [SerializeField] private Color debugCollisionColor;
    [SerializeField] private bool showDetection;

    [Header("Condition/State (Debug purpose)")]
    [SerializeField] private bool onGround;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool canMove;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControlKeys;
    [SerializeField] private PlayerData dataToStore;
    private Rigidbody2D rb;
    private AIControls aiControls;

    private void Start()
    {
        onGround = false;
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        if(useAI)
        {
            aiControls = GetComponent<AIInput>().aiControls;
            if(aiControls == null)
            {
                throw new UnityException("Please attach AIInput component to this gameobject");
            }
        }

        if (dataToStore != null)
        {
            dataToStore.moveable = true;
            dataToStore.walkVelocity = walkVelocity;
            dataToStore.runVelocity = runVelocity;
        }
    }

    private void Update()
    {
        Vector2 direction = new Vector2();

        if(useAI)
        {
            if(aiControls.right)
            {
                direction.x = 1;
            }
            else if(aiControls.left)
            {
                direction.x = -1;
            }
        }
        else
        {
            if(Input.GetKey(playerControlKeys.right))
            {
                direction.x = 1;
            }
            else if(Input.GetKey(playerControlKeys.left))
            {
                direction.x = -1;
            }
        }

        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        onGround = Physics2D.OverlapCircle(groundLoc.position, collisionRadius, groundLayerMask);   // 8 is the ground layer

        UpdateCanMove(onGround);
        
        if(useAI)
        {
            if (aiControls.run && canRun)
            {
                UpdateRunning(true);
            }
            else
            {
                UpdateRunning(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(playerControlKeys.run) && canRun)
            {
                UpdateRunning(true);
            }
            else if (Input.GetKeyUp(playerControlKeys.run))
            {
                UpdateRunning(false);
            }
        }


        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------

        if (canMove)
        {
            if(isRunning)
            {
                Run(direction);
            }
            else
            {
                Walk(direction);
            }
        }

    }

    private void OnDrawGizmos()
    {
        if(showDetection)
        {
            Gizmos.color = debugCollisionColor;

            Gizmos.DrawWireSphere(groundLoc.position, collisionRadius);
        }
    }

    ///--------------------------------------------------------------
    /// Methods below are for updating player conditions
    ///--------------------------------------------------------------
    public void UpdateRunning(bool input)
    {
        isRunning = input;
    }
    public void UpdateCanMove(bool input)
    {
        canMove = input;
    }

    ///--------------------------------------------------------------
    /// Methods below are commands for the character
    ///--------------------------------------------------------------
    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * walkVelocity.data, rb.velocity.y);
    }
    private void Run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * runVelocity.data, rb.velocity.y);
    }
}

