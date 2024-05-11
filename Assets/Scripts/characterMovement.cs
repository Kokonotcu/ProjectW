using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 12.0f;
    private float jumpForce = 40.0f;
    private bool isFacingRight = true;
    private int jumpCount = 0;
    private int extraJumps = 10;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask climableLayer;


    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if ( Input.GetButtonDown("Jump")  && jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
        if( isGrounded() )
        {
            jumpCount = 0;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if( isWalled())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }


        Debug.Log(rb.velocity.y);
        Flip();
        
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        rb.AddForce(new Vector2(horizontal * speed*5, 0));
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, climableLayer);
    }
    private void Flip()
    {
        if( horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
