using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture buttonTexture;
	public Texture2D icon;
	//boolean to remove button once clicked
	bool ShowButton = true;

	//boolean set true if the game settings have been confirmed
	bool start = false;

	//the texture of our buttons
	Texture2D p1, p2, p3, p4;

	//initialize all fancy GUI
	void Start() {
		//load the button textures to assign to our buttons
		p1 = Resources.Load ("OnePlayer") as Texture2D;
		p2 = Resources.Load ("TwoPlayer") as Texture2D;
		p3 = Resources.Load ("ThreePlayer") as Texture2D;
		p4 = Resources.Load ("FourPlayer") as Texture2D;
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

		if (ShowButton) {
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 100), "START")) {
				ShowButton = false;
			}
		}

		//once the start game button has been selected - do this
		if (!ShowButton) {	
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3 - 100, Screen.height / 2, 200, 100), p1)) {
				GameSettings.Instance.players = 1;
				start = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 9 - 100, Screen.height / 2, 200, 100), p2)) {
				GameSettings.Instance.players = 2;
				start = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 9 - 100, Screen.height / 2, 200, 100), p3)) {
				GameSettings.Instance.players = 3;
				start = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 3 - 100, Screen.height / 2, 200, 100), p4)) {
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
