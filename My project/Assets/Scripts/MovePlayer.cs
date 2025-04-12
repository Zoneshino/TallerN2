using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rigiBodyPlayer;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.3f;

    private bool isGrounded;

    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();
        rigiBodyPlayer.freezeRotation = true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Girar al moverse
        if (horizontal != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(horizontal);
            transform.localScale = scale;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        rigiBodyPlayer.velocity = new Vector2(horizontal * moveSpeed, rigiBodyPlayer.velocity.y);
    }

    private void Jump()
    {
        rigiBodyPlayer.velocity = new Vector2(rigiBodyPlayer.velocity.x, jumpForce);
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void ResetSpeed()
    {
        moveSpeed = 5f;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
