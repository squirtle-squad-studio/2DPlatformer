using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpVelocity;

    private PlayerCollisionDetection collisionDetection;
    private Rigidbody2D rb;

    void Start()
    {
        collisionDetection = GetComponent<PlayerCollisionDetection>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && collisionDetection.onGround)
        {
            rb.velocity += Vector2.up * jumpVelocity;
        }
    }
}
