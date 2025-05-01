using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 5f;
    public float jumpForce = 2f;

    private float moveInput;
    private Rigidbody2D rb2d;
    private bool isGrounded = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // เคลื่อนที่ซ้าย-ขวา
        rb2d.linearVelocity = new Vector2(moveInput * speed, rb2d.linearVelocity.y);

        // กระโดดได้เมื่ออยู่บนพื้น
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // ป้องกันกระโดดซ้ำกลางอากาศ
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("Monster"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("Monster"))
        {
            isGrounded = true;
        }
    } 

    
}
