using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMove : MonoBehaviour {

	public float moveSpeed;
	public bool facingRight;

	public Transform wallCheck;
	public float hitingWallRadius;
	public LayerMask wallObjects;
	private bool hitingWall;

	private bool edge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		hitingWall = Physics2D.OverlapCircle (wallCheck.position, hitingWallRadius, wallObjects);
		edge = Physics2D.OverlapCircle (edgeCheck.position, hitingWallRadius, wallObjects);


		if (hitingWall || !edge)
			facingRight = !facingRight;

		if (facingRight) {
			GetComponent<Transform>().localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Transform>().localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		
	}
}
