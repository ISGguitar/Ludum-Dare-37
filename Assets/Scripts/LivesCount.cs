using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCount : MonoBehaviour {

	public int defaultNumOfLifes;
	private int livesCount;
	private Text text;

	public GameObject gameOverScreen;
	public float waitAfterGameOver;
	public string mainMenu;

	public AudioSource gameOver;


	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
		livesCount = defaultNumOfLifes;

	}

	// Update is called once per frame
	void Update () {

		text.text = "x " + livesCount;

		if (livesCount <= 0){
			gameOverScreen.SetActive(true);
			gameOver.Play ();
		}
		

		if (gameOverScreen.activeSelf)
			waitAfterGameOver -= Time.deltaTime;

		if (waitAfterGameOver <= 0)
			Application.LoadLevel (mainMenu);

	}

	public void addLive(){
		livesCount += 1;
	}

	public void takeLive(){
		livesCount -= 1; 
	}
		
}