using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This Class is used to update the Animation parameters
 * for x and y velocities
 * The string must match the variable name in the animator parameters.
 * This is used to determine if a player is walking/jumping.
 */
public class Animator_Update_XY_Velocity : MonoBehaviour
{
    [Header("Animator parameters Variables")]
    [SerializeField] private string xVelocity;
    [SerializeField] private string yVelocity;

    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            animator.SetFloat(xVelocity, Mathf.Abs(rb.velocity.x));
            animator.SetFloat(yVelocity, Mathf.Abs(rb.velocity.y));
        }
    }
}
