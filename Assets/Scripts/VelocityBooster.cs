using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBooster : MonoBehaviour {

	public int boostPoints;

	private int boostPointsTaken;
	public int boostMaxPoints;

	public int boostForse;
	public int maxBoostForse;
	private int vectorForce;

	public AudioSource vectorActivated;

	// Use this for initialization
	void Start () {
		vectorForce = boostForse;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void addPoints(){
		if (boostPointsTaken > boostMaxPoints)
			return;
		Score.addPoints (boostPoints);		
		boostPointsTaken += boostPoints;
	}


	void OnTriggerEnter2D(Collider2D other) {	
		vectorActivated.Play ();	

		if (other.name == "Player") {
			addPoints ();

			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (other.GetComponent<Rigidbody2D> ().velocity.x, boostForse);
		}

		if (vectorForce < maxBoostForse) {
			vectorForce += boostForse;
		}


	}

	private void activated(){
		boosterIsActive ();
	}
		
	// TODO: leave power after seconds
	private IEnumerator boosterIsActive(){
		yield return new WaitForSeconds(3);
		vectorForce = boostForse;
	}

}
