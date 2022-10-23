using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed;
    private float Move;
    protected Rigidbody2D rb;
    public float jump;
    public bool isOnFloor;
    public Animator animator;
    private bool facingRight = true;
    private bool isJumping = false;

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        

        Move = Input.GetAxis("Horizontal")*speed;

        rb.velocity = new Vector2(Move, rb.velocity.y);

        if(Move < 0 && facingRight)
        {
            Flip();
        }else if(Move > 0 && !facingRight)
        {
            Flip();
        }

        animator.SetFloat("PlayerSpeed", Mathf.Abs(Move));
        jumpFunction();
    }


    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnFloor  = true;
            if (isJumping)
            {
                animator.SetBool("isJumping", false);
                isJumping = false;
            }
        }

    }

    protected void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnFloor = false;
        }

    }

    protected virtual void jumpFunction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnFloor)
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping  = true;
            Debug.Log(isJumping);

        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}
