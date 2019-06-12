using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CollisionDetection : MonoBehaviour
    {
        [Header("Debug")]
        public bool showCollision;
        public bool onGround { get; private set; }
        public bool onWall { get; private set; }
        public bool onLeftWall { get; private set; }
        public bool onRightWall { get; private set; }

        [Header("Location to check for collision")]
        public float collisionRadius;
        private Color debugCollisionColor = Color.red;

        public float bottomOffset;
        public float rightOffset;
        public float leftOffset;

        private int groundLayerMask;

        // Start is called before the first frame update
        void Start()
        {
            onGround = false;
            onWall = false;
        }

        // Update is called once per frame
        void Update()
        {
            onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.right * leftOffset, collisionRadius, groundLayerMask);
            onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + Vector2.right * rightOffset, collisionRadius, groundLayerMask);
            onWall = onLeftWall || onRightWall;
        }

        void OnDrawGizmos()
        {
            if (!showCollision) return;
            // To draw where the collision detection is
            Gizmos.color = debugCollisionColor;

            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.up * bottomOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.right * leftOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.right * rightOffset, collisionRadius);
        }
    }
}
