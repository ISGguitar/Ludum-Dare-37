using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	public float speedPower;
	public float jumpPower;
	private float moveVectorVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJump;

	private Animator animator;
	public GameObject doubleJumpParticle;

	public AudioSource onJump;
	public AudioSource onDoubleJump;





	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		

	}

	// Update is called once per frame
	void Update ()
	{	

		if (grounded) {
			doubleJump = false;
		}

		animator.SetBool ("OnTheGround", grounded);

		if (Input.GetKeyDown(KeyCode.Space) && grounded){			
			onJump.Play ();
			jump();
		}

		if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded){			
			jump();
			doubleJump = true;
			onDoubleJump.Play ();
			Instantiate (doubleJumpParticle, this.transform.position, this.transform.rotation);
		}

		moveVectorVelocity = 0f;
		// TODO: Moving Left
		if (Input.GetKey(KeyCode.A)){			
			moveVectorVelocity = -speedPower;
		}

		// TODO: Moving Right
		if (Input.GetKey(KeyCode.D)){
			moveVectorVelocity = speedPower;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVectorVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		animator.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		

	}

	public void jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpPower);
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}
}

