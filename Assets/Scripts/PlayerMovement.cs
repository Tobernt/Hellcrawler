using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 2f;
    public float jumpingPower = 6f;
    private bool isFacingRight = true;
    private int doubleJump = 0;
    private bool Paused = true;

    public GameObject GameOver;

    [Header("Movement variables")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Horizontal"))
        {
            anim.Play("RunningAnim");
        }

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Horizontal") && Paused == true)
        {
            Time.timeScale = 1;
            Paused = false;
        }

        if (Input.GetButtonDown("Jump") && doubleJump < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump++;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (IsGrounded())
        {
            doubleJump = 0;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }
}