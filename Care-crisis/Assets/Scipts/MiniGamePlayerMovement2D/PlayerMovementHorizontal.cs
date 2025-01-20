using UnityEngine;

public class PlayerMovementHorizontal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed = 5.0f;

    private Rigidbody2D Rigidbody2D;
    private Collider2D Collider2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 NewMovement = new Vector2(Input.GetAxis("Horizontal"), 0.0f) * Speed;
        Rigidbody2D.linearVelocity = NewMovement;
    }
}
