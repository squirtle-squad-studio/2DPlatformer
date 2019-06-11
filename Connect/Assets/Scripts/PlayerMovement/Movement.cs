using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [Header("Walk/Run/Wallslide")]
        public float walkVelocity;
        public float runVelocity;
        public float wallSlideVelocity;

        [Header("Jump")]
        public float jumpVelocity;
        public float dashVelocity;

        [Header("Condition/State (Debug purpose)")]
        [SerializeField] private bool isRunning;
        [SerializeField] private bool canMove;
        [SerializeField] private bool canJump;
        [SerializeField] private bool canWallDash;
        [SerializeField] private bool onWallSlide;

        private CollisionDetection collisionDetection;
        private Rigidbody2D rb;
        [SerializeField] private InputControllerData playerControlKeys;

        private void Start()
        {
            canMove = true;
            collisionDetection = GetComponent<CollisionDetection>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 direction = new Vector2();

            if (Input.GetKey(playerControlKeys.up))
            {
                direction.y = 1;
            }
            else if(Input.GetKey(playerControlKeys.down))
            {
                direction.y = -1;
            }

            if(Input.GetKey(playerControlKeys.right))
            {
                direction.x = 1;
            }
            else if(Input.GetKey(playerControlKeys.left))
            {
                direction.x = -1;
            }

            //--------------------------------------------------------------
            // Updates player condition
            //--------------------------------------------------------------

            UpdateCanMove(collisionDetection.onGround);
            UpdateCanJump(collisionDetection.onGround);
            UpdateCanDash(!collisionDetection.onGround && collisionDetection.onWall);
            UpdateOnSlide(collisionDetection.onWall);

            if (Input.GetKeyDown(playerControlKeys.run))
            {
                UpdateRunning(true);
            }
            else if (Input.GetKeyUp(playerControlKeys.run))
            {
                UpdateRunning(false);
            }

            //--------------------------------------------------------------
            // Execute action based on conditions
            //--------------------------------------------------------------

            if (onWallSlide)
            {
                WallSlide();
            }

            if (Input.GetKeyDown(playerControlKeys.jump))
            {
                if (canJump)
                {
                    Jump();
                }
            }
            // Holds down key
            if (Input.GetKey(playerControlKeys.jump))
            {
                if (canWallDash)
                {
                    Vector2 dir;
                    if (collisionDetection.onLeftWall)
                    {
                        dir = new Vector2(1, 1);
                    }
                    else
                    {
                        dir = new Vector2(-1, 1);
                    }
                    WallDash(dir);
                }
            }

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
        public void UpdateCanJump(bool input)
        {
            canJump = input;
        }
        public void UpdateOnSlide(bool input)
        {
            onWallSlide = input;
        }
        public void UpdateCanDash(bool input)
        {
            canWallDash = input;
        }

        ///--------------------------------------------------------------
        /// Methods below are commands for the character
        ///--------------------------------------------------------------
        private void Jump()
        {
            rb.velocity += Vector2.up * jumpVelocity;
        }
        private void WallDash(Vector2 dir)
        {
            Vector2 v = dir.normalized * dashVelocity;
            rb.velocity = new Vector2(v.x, v.y);
        }
        private void WallSlide()
        {
            rb.velocity = new Vector2(rb.velocity.x , wallSlideVelocity);
        }
        private void Walk(Vector2 dir)
        {
            rb.velocity = new Vector2(dir.x * walkVelocity, rb.velocity.y);
        }
        private void Run(Vector2 dir)
        {
            rb.velocity = new Vector2(dir.x * runVelocity, rb.velocity.y);
        }
    }

}
