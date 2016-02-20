﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture buttonTexture;
	public Texture2D icon;

	//boolean to remove button once clicked
	bool ShowButton = true;

	//boolean set true if the game settings have been confirmed
	bool start = true;

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
			if (GUI.Button(new Rect(Screen.width/2 - 50 , Screen.height /2 + 50, 100, 100), "START")) {
				ShowButton = false;
			}
		}

		//once the start game button has been selected - do this
		if (!ShowButton) {
			if (start) {
				GUI.contentColor = Color.red;
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 125, 100, 50), "GO!")) {
					//Application.LoadLevel(1);	//comment this - will load the level once the settings are good
				}
			}
		}

		/*
		 * example of the game settings rules that will be used for the scope of the project 
		if (GameSettings.Instance.two == true) {
			GUI.contentColor = Color.blue;
			if (GUI.Button(new Rect(Screen.width / 4 + 150, Screen.height / 2+50, 100, 50), "Player")) {
				GameSettings.Instance.two = false;
			}
		}
		*/
	}
}