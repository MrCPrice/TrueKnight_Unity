using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement
{
    public float speedTurn = 2f;
    public float jumpHight = 5f;
    private bool touchingGround = true;
    float velJump;

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.collider.tag == "Ground")
        {
            if(touchingGround == false)
            {
                touchingGround = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity += transform.forward * movementSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity += -transform.forward * movementSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
           transform.Rotate(new Vector3(0,1,0) * speedTurn);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,-1,0) * speedTurn);
        }

        if(Input.GetKey(KeyCode.Space) && touchingGround)
        {
            rb.velocity += transform.up * jumpHight;
            touchingGround = false;
        }
    }
}
