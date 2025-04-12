using UnityEngine;

public class EnemyGroundPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    private int direction = 1;
    private Rigidbody2D rb;

    private Vector3 groundCheckOffsetRight;
    private Vector3 groundCheckOffsetLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        groundCheckOffsetRight = groundCheck.localPosition;
        groundCheckOffsetLeft = new Vector3(-groundCheckOffsetRight.x, groundCheckOffsetRight.y, groundCheckOffsetRight.z);
    }

    void Update()
    {

        bool isGroundAhead = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("Hay suelo adelante: " + isGroundAhead);

        if (!isGroundAhead)
        {
            Flip();
        }

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;

        groundCheck.localPosition = direction == 1 ? groundCheckOffsetRight : groundCheckOffsetLeft;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
