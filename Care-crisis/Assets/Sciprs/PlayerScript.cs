using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    
        private Rigidbody2D rb; // Reference to Rigidbody2D
        private Vector2 movement; // Movement vector
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            // Capture input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized; // Normalize to prevent faster diagonal movement
        }
    
        void FixedUpdate()
        {
            // Apply movement
            rb.velocity = movement * moveSpeed;
        }
}
