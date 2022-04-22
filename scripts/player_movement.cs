using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 7f; // show movespeed in forward direction
    [SerializeField]
    float yChange = 5f; // value used to make object jump
    [SerializeField]
    float fallMultiplier = 2.5f;
    public bool isGrounded;
    private Rigidbody2D rb;
  



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
        BetterJump();
    }

    public void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }


    // check wheather the character is in gound or not
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, yChange), ForceMode2D.Impulse);

        }
    }


   

    public void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}