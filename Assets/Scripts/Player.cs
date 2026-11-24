using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 0.1f;
    public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private bool isGrounded;

    public AudioClip jumpSFX;
    public AudioClip landSFX;
    public AudioClip dieSFX;

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
            AudioManager.instance.PlaySFX(jumpSFX);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            AudioManager.instance.PlaySFX(dieSFX);
            Invoke("WaitForSceneLoad", dieSFX.length);
        }
        else
        {
            AudioManager.instance.PlaySFX(landSFX);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void WaitForSceneLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

}
