using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelayTime;

	public GameObject spawn;
	public GameObject score;


	public int deathPoints;
	public int winPoints;


	private float gravityForce;
	public LivesCount livesCount;
	public AudioSource onDeath;
	public AudioSource onRespawn;


	private Controller player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controller> ();
		gravityForce = player.GetComponent<Rigidbody2D> ().gravityScale;
		livesCount = FindObjectOfType<LivesCount> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	private IEnumerator respawnPlayerInit(){


		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;



		onDeath.Play ();
		yield return new WaitForSeconds(respawnDelayTime);


		player.transform.position = currentCheckpoint.transform.position;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		player.GetComponent<Rigidbody2D> ().gravityScale = gravityForce;

		onRespawn.Play ();
		Score.addPoints (-deathPoints);
		livesCount.takeLive ();


	}

	public void respawnPlayer(){
		StartCoroutine ("respawnPlayerInit");
	}
}
