using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed;
    private float Move;
    protected Rigidbody2D rb;
    public float jump;
    public bool isOnFloor;


    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        jumpFunction();
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnFloor  = true;
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
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("jump pressed");

        }
    }
}
