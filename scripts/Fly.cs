using UnityEngine;


public class Fly : MonoBehaviour
{
    private float gravityScale;
    Vector3 prevPosition;
    protected Rigidbody2D rb;
    public float speed = 0.2f;
   

    void Start()
    {

        rb = transform.GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        prevPosition = transform.position;
    }


    void Update()
    {
        PlayerFly();
    }
    void FixedUpdate()
    
    {
        Move();
        transform.localPosition += new Vector3(speed, 0, 0);
        Vector2 direction = (transform.position - prevPosition).normalized;
        float rotaion = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, rotaion);
        prevPosition = transform.position;
    }
    public void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }


    private void PlayerFly()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.gravityScale = -gravityScale;


        }
        else if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = gravityScale;

        }
    }

}