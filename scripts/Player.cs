using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed = 0.6f, jumpForce = 36;
    private float movement = 5f;
    public bool isGrounded = false;
    Rigidbody2D rb;
    public int Respawn;

    //increase speed after some distance of player
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;


    // holding jmp high
    public float jumpTime;
    private float jumpTimeCounter;

    public bool powerupReset;

    // Start is called before the first frame update
    void Start()
    {

        rb = transform.GetComponent<Rigidbody2D>();



        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;
    }



    //increase speed
    private void Update()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed * speedMultiplier;
        }
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();


    }
    //moving code
    public void Move()
    {

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

    }
    //checking if touchde to ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "killbox")
        {

            if (PlayerPrefs.GetFloat("Highscore") < scoreDis.Distance + CoinScript.coinCount)
                PlayerPrefs.SetFloat("Highscore", scoreDis.Distance + CoinScript.coinCount);

            SceneManager.LoadScene(Respawn);

            powerupReset = true;
            CoinScript.coinCount = 0;
        }

    }
    //for jumping
    private void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                isGrounded = false;
                Vector2 jumpVelocity = new Vector2(2, jumpForce);
                rb.velocity = jumpVelocity;
            }
        }
        //on holding jumps high
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {
                Vector2 jumpVelocity = new Vector2(2, jumpForce);
                rb.velocity = jumpVelocity;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCounter = 0;
        }

        if (isGrounded)
        {
            jumpTimeCounter = jumpTime;
        }

    }



}