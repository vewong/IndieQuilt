using UnityEngine;
using System.Collections;

public class SheepJump : MonoBehaviour {

    Animator anim;
    
    public bool jumping = false;
    public Transform groundCheck;
    float groundCheckRadius = .9f;
    public LayerMask whatIsGround;
    float jumpHeight = 550f;
    float jumpBoost = 400f;


    //change the move speed based on difficulty setting
    float moveSpeedEasy = 4f;
    float moveSpeedHard = 6f;
    float movespeed;

    IndieQuiltCommunicator communicator;

    bool dead;

	// Use this for initialization
	void Awake () 
    {
        communicator = (IndieQuiltCommunicator)FindObjectOfType<IndieQuiltCommunicator>();

        if (communicator == null)
        {
            Debug.LogError("AAAAAAAAAA why doesn't this communicator work");
        }

        //determine move speed based on the difficulty setting
        if (communicator.difficulty < 6)
        {
            movespeed = moveSpeedEasy;
        }
        else
        {
            movespeed = moveSpeedHard;
        }

        this.rigidbody2D.velocity = new Vector2(movespeed, this.rigidbody2D.velocity.y);

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        jumping = !(Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround));

        anim.SetBool("jumping", jumping);
	}

    void Update()
    {
        this.rigidbody2D.velocity = new Vector2(movespeed, this.rigidbody2D.velocity.y);
    }

    void Jump()
    {
        rigidbody2D.AddForce(new Vector2(jumpBoost, jumpHeight));
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !jumping)
        {
            Jump();
            //jumping = true;
        }
    }

    void Die()
    {
        dead = true;

        anim.SetBool("dead", dead);
        this.enabled = false;
    }
}
