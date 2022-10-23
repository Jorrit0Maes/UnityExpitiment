using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoubleJumpScript : Player_movement
{
    public int jumpcount = 1;

    protected override void Update()
    {
        base.Update();
    }


    protected override void jumpFunction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isOnFloor || jumpcount == 2))
        {
            if(isOnFloor)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
            }
            else
            {
                rb.AddRelativeForce(new Vector2(rb.velocity.x, jump+(rb.velocity.y)));
                
            }
            
            Debug.Log("jump pressed");
            jumpcount++;

        }
    }


    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        jumpcount++;
    }
}
