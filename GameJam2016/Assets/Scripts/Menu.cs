using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture buttonTexture;
	public Texture2D icon;

	//boolean to remove button once clicked
	bool ShowButton = true;

	//boolean set true if the game settings have been confirmed
	bool start = false;

	void Start() {
	}

	void update() {
		if (Input.GetButtonDown("Submit")) {
			ShowButton = false;
		}
	}

	//the gui of the the main menu 
	void OnGUI () {

		//set no background to the button
		GUI.backgroundColor = Color.clear;
		GUI.skin.button.fontSize = 15;
		GUI.contentColor = Color.black;

		if (ShowButton) {
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 100), "START")) {
				ShowButton = false;
			}
		}

		//once the start game button has been selected - do this
		if (!ShowButton) {
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3 - 50, Screen.height / 2 + 50, 100, 50), "1 PLAYER")) {
				GameSettings.Instance.players = 1;
				start = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 6 - 50, Screen.height / 2 + 50, 100, 50), "2 PLAYER")) {
				GameSettings.Instance.players = 2;
				start = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 6 - 50, Screen.height / 2 + 50, 100, 50), "3 PLAYER")) {
				GameSettings.Instance.players = 3;
				start = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 3 - 50, Screen.height / 2 + 50, 100, 50), "4 PLAYER")) {
				GameSettings.Instance.players = 4;
				start = true;
			}

			GUI.contentColor = Color.red;
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 125, 100, 50), "GO!") && start == true) {
				GameSettings.Instance.matchSet = true;	//set this to true
				Application.LoadLevel (1);				//comment this - will load the level once the settings are good		
			}
		}
	}
}
