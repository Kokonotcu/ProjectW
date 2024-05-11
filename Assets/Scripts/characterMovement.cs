using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float horizontal;
    public float speed = 12.0f;
    public float jumpForce = 20.0f;
    public bool isFacingRight = true;
    public float gravityScale = 5f;
    public Animator animator;

    private bool isClimbing = false;
    private bool isDead = false;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask climableLayer;


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("speed",  Mathf.Abs( horizontal ) * Mathf.Abs(rb.velocity.x) * speed );
        animator.SetBool("isDead", isDead);

        horizontal = Input.GetAxisRaw("Horizontal");

        if(isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if(!isDead)
        {
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if (Input.GetButtonDown("Jump") && !isGrounded() && isClimbing)
            {
                rb.gravityScale = gravityScale;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isClimbing = false;
            }
            Flip();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isClimbing = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
        else if (collision.gameObject.layer == 11)
        {
            isDead = true;
        }
    }


    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if(!isClimbing && !isDead)
            rb.AddForce(new Vector2(horizontal * speed*5, 0));
        //rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    public void setDead()
    {
        isDead = true;
    }

    public bool getDead()
    {
        return isDead;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
