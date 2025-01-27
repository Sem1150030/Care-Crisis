using UnityEngine;

public class GeoDashPlayer : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 10f; // Force applied to the jump
    public LayerMask groundLayer; // Layer for the ground/platforms

    [Header("Ground Detection")]
    public Transform groundCheck; // Empty GameObject to check if the player is grounded
    public Vector2 boxSize = new Vector2(1f, 0.2f); // Size of the BoxCast, adjust to fit your player width
    public float boxCastDistance = 0.1f; // Distance to check for the ground

    [Header("Jump Buffer Settings")]
    public float jumpBufferTime = 0.2f; // Time window to buffer the jump input

    private Rigidbody2D rb; // Rigidbody2D for physics
    private bool isGrounded; // Tracks if the player is on the ground
    private float jumpBufferCounter; // Tracks time since the jump button was pressed

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Perform a BoxCast from the groundCheck position downward
        RaycastHit2D hit = Physics2D.BoxCast(groundCheck.position, boxSize, 0f, Vector2.down, boxCastDistance, groundLayer);

        // If the BoxCast hits something on the ground layer, the player is grounded
        isGrounded = hit.collider != null;

        // Check for jump input and store it in the buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime; // Reset the buffer counter
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime; // Decrease buffer counter over time
        }

        // Perform the jump if the player is grounded and there's buffered input
        if (isGrounded && jumpBufferCounter > 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Reset vertical velocity
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Apply upward force
        jumpBufferCounter = 0; // Reset the buffer after jumping
    }

    private void OnDrawGizmos()
    {
        // Draw the ground detection box or capsule in the editor
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheck.position + Vector3.down * (boxCastDistance / 2), new Vector3(boxSize.x, boxSize.y, 1f));
        }
    }
}
