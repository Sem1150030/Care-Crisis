using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Attach Animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Attach SpriteRenderer component
    }

    void Update()
    {
        // Capture input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Normalize to prevent faster diagonal movement

        // Update Animator parameters
        if (movement != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);

            // Set directional booleans
            animator.SetBool("IsGoingLeft", movement.x < 0);
            animator.SetBool("IsGoingRight", movement.x > 0);
            animator.SetBool("IsGoingForward", movement.y > 0);  // Forward is when moving downwards on the Y-axis
            animator.SetBool("IsGoingBackward", movement.y < 0); // Backward is when moving upwards on the Y-axis

            // Handle sprite flipping for left direction
            if (movement.x < 0)
                spriteRenderer.flipX = true; // Flip the sprite horizontally
            else if (movement.x > 0)
                spriteRenderer.flipX = false; // Reset flipping for right
        }
        else
        {
            animator.SetBool("IsMoving", false);

            // Reset directional booleans when not moving
            animator.SetBool("IsGoingLeft", false);
            animator.SetBool("IsGoingRight", false);
            animator.SetBool("IsGoingForward", false);
            animator.SetBool("IsGoingBackward", false);
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = movement * moveSpeed;
    }
}