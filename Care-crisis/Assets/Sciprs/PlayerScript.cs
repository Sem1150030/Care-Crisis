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
    private Coroutine stopMovementCoroutine; // Reference to the coroutine

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (stopMovementCoroutine != null)
            {
                StopCoroutine(stopMovementCoroutine); // Stop any running coroutine
                stopMovementCoroutine = null;
            }

            animator.SetBool("Ismoving", true);

            // Set moveX and moveY parameters for the blend tree
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);

            // Handle sprite flipping for left direction
            if (movement.x < 0)
            {
                spriteRenderer.flipX = true; // Flip sprite for left movement
            }
            else if (movement.x > 0)
            {
                spriteRenderer.flipX = false; // Reset flipping for right movement
            }
        }
        else
        {
            if (stopMovementCoroutine == null)
            {
                stopMovementCoroutine = StartCoroutine(DisableIsMovingAfterDelay(0.2f)); // Start coroutine with 200ms delay
            }
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = movement * moveSpeed;
    }

    private IEnumerator DisableIsMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        animator.SetBool("Ismoving", false); // Disable IsMoving after the delay
        stopMovementCoroutine = null; // Clear the coroutine reference
    }
}
