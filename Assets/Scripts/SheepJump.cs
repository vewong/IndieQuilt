using UnityEngine;
using System.Collections;

public class SheepJump : MonoBehaviour {

    public bool jumping = false;
    public Transform groundCheck;
    float groundCheckRadius = .9f;
    public LayerMask whatIsGround;
    float jumpHeight = 400f;
    float moveSpeed = 3f;

	// Use this for initialization
	void Start () 
    {
        this.rigidbody2D.velocity = new Vector2(moveSpeed, this.rigidbody2D.velocity.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        jumping = !(Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround));
	}

    void Update()
    {
        this.rigidbody2D.velocity = new Vector2(moveSpeed, this.rigidbody2D.velocity.y);
    }

    void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0, jumpHeight));
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !jumping)
        {
            Jump();
            //jumping = true;
        }
    }
}
