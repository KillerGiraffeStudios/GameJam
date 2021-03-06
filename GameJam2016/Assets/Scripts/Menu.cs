﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	//boolean to remove button once clicked
	public bool ShowButton = true;

	//boolean set true if the game settings have been confirmed
	public bool canStart = false;

	//the texture of our buttons
	public Texture2D p1, p2, p3, p4, p1c, p2c, p3c, p4c, start, create, title;

	//initialize all fancy GUI
	void Start() {
		//load the button textures to assign to our buttons
		title = Resources.Load ("Title") as Texture2D;
		p1 = Resources.Load ("OnePlayer") as Texture2D;
		p2 = Resources.Load ("TwoPlayer") as Texture2D;
		p3 = Resources.Load ("ThreePlayer") as Texture2D;
		p4 = Resources.Load ("FourPlayer") as Texture2D;
		p1c = Resources.Load ("p1change") as Texture2D;
		p2c = Resources.Load ("p2change") as Texture2D;
		p3c = Resources.Load ("p3change") as Texture2D;
		p4c = Resources.Load ("p4change") as Texture2D;
		start = Resources.Load ("StartMenu") as Texture2D;
		create = Resources.Load ("CreateMatch") as Texture2D;
	}

	void update() {
		if (Input.GetButtonDown("Submit")) {
			ShowButton = false;
		}
		this.OnGUI();
	}

	//helper function that resets each button texture to its original form
	void resetColors() {
		p1 = Resources.Load ("OnePlayer") as Texture2D;
		p2 = Resources.Load ("TwoPlayer") as Texture2D;
		p3 = Resources.Load ("ThreePlayer") as Texture2D;
		p4 = Resources.Load ("FourPlayer") as Texture2D; 
	}

	//the gui of the the main menu 
	void OnGUI () {
		//set no background to the button
		GUI.backgroundColor = Color.clear;

		GUI.Box (new Rect (Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height), title);

		if (ShowButton) {
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 + Screen.height / 14, Screen.width / 8, Screen.height / 7), start)) {
				ShowButton = false;
			}
		}

		//once the start game button has been selected - do this
		if (!ShowButton) {	
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3 - Screen.width / 16, Screen.height / 2, Screen.width / 8, Screen.height / 7), p1)) {
				GameSettings.Instance.players = 1;
				resetColors ();
				p1 = p1c;
				canStart = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 9 - Screen.width / 16, Screen.height / 2, Screen.width / 8, Screen.height / 7), p2)) {
				GameSettings.Instance.players = 2;
				resetColors ();
				p2 = p2c;
				canStart = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 9 - Screen.width / 16, Screen.height / 2, Screen.width / 8, Screen.height / 7), p3)) {
				GameSettings.Instance.players = 3;
				resetColors ();
				p3 = p3c;
				canStart = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 3 - Screen.width / 16, Screen.height / 2, Screen.width / 8, Screen.height / 7), p4)) {
				GameSettings.Instance.players = 4;
				resetColors ();
				p4 = p4c;
				canStart = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 14, Screen.height / 2 + Screen.height / 4, Screen.width / 7, Screen.height / 6), create) && canStart == true) {
				GameSettings.Instance.matchSet = true;	//set this to true
				resetColors ();							//make sure that everything is reset
				canStart = false;                       //reset the match settings for new game
                SceneManager.LoadScene(1);				//comment this - will load the level once the settings are good		
			}
		}
	}
}