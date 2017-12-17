using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score;

	Text text;

	public GameObject gameWinScreen;
	public float waitAfterGameWin;
	public string mainMenu;


	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (score < 0) {
			score = 0;
		}

		text.text = "" + score;

		if (score >= 15000){
			gameWinScreen.SetActive(true);
		}


		if (gameWinScreen.activeSelf)
			waitAfterGameWin -= Time.deltaTime;

		if (waitAfterGameWin <= 0)
			Application.LoadLevel (mainMenu);
		
	}

	public static void addPoints (int Value){

		score += Value;	

	}
}
