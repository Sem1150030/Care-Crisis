using UnityEngine;

public class FlappieBirdJump : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float jumpForce = 5f;

    private float JumpTimer;
    private Animator animator;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (FlappieSpaceListener.isGameStarted)
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.None;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.None;
            Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, jumpForce);
            animator.SetBool("JumpPressed", true);
            JumpTimer = 0.3f;
        }

        if (JumpTimer > 0)
        {
            JumpTimer -= Time.deltaTime;
        }
        else
        {
            JumpTimer = 0;
            animator.SetBool("JumpPressed", false);
        }


        if (FlappieCollision.hasCrossedFinishLine)
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
