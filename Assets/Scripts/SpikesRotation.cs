using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesRotation : MonoBehaviour {


	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Transform.Rotate (rotationSpeed, 0f, 0f);
		GetComponent<Transform>().Rotate (0f, 0f, rotationSpeed);
		
	}
}
