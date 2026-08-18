using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Health")]
    public PlayerHealth health;


    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float moveInput;
    private bool isGrounded;

    private float lineralValue;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        // Get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Check if player is touching the ground
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Animation


        // Flip player depending on direction
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
          
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
          
        }
      
    }

    void FixedUpdate()
    {
        // Move player
        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );
        if(rb.linearVelocityX >= 0.1f || rb.linearVelocityX <= -0.1)
        {
            animator.SetBool("IsRunning", true);
        }

        else 
        {
            animator.SetBool("IsRunning", false);
        }



    }

    public void KillPlayer()
    {
        Destroy(gameObject);
    }
}