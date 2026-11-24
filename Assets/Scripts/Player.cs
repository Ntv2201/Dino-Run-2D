using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 0.1f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleJump();
        HandleAnimation();
    }

    private void HandleJump()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void HandleAnimation()
    {
        if (isGrounded)
        {
            animator.Play("player_run");
        }
        else
        {
            animator.Play("player_jump");
        }
    }

}
