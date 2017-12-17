using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string newGame;

	public void NewGame(){
		Application.LoadLevel (newGame);
	}

	public void QuitGame(){
		Application.Quit ();
	}

}
