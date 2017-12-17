using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickUp : MonoBehaviour {

	public int pointsCount;
	public AudioSource coin;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Controller> () == null) {
			return;
		}
		coin.Play ();

		Score.addPoints (pointsCount);
		Destroy (gameObject);
	}

}
