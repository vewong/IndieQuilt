using UnityEngine;
using System.Collections;

public class SheepJump : MonoBehaviour {

    public bool jumping = false;
    public Transform groundCheck;
    float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    float jumpHeight = 400f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        jumping = !(Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround));
	}

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !jumping)
        //{
        //    Jump();
        //    jumping = true;
        //}

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
