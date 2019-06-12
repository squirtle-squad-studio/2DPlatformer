using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        public float walkVelocity;
        public float runVelocity;

        [Header("Condition/State (Debug purpose)")]
        [SerializeField] private bool isRunning;
        [SerializeField] private bool canMove;

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

        ///--------------------------------------------------------------
        /// Methods below are commands for the character
        ///--------------------------------------------------------------
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
