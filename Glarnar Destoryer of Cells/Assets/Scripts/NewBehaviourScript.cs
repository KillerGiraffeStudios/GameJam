using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
		
	public Texture buttonTexture;
	public Texture2D icon;

	bool ShowButton = true;
	bool start = true;
	void Start() {
	}

	void update() {
		if (Input.GetButtonDown("Submit")) {
			ShowButton = false;
		}
	}

	void OnGUI () {
		
		GUI.backgroundColor = Color.clear;
		GUI.skin.button.fontSize = 20;
		GUI.contentColor = Color.red;
		if (ShowButton) {
			if (GUI.Button(new Rect(Screen.width/2 -50 , Screen.height /2 + 50, 100, 100), "START")) {
				ShowButton = false;
			}
			if (Input.GetButtonDown("Submit")) {
				ShowButton = false;
			}
		}

		if (!ShowButton) {
			if (GameSettings.Instance.one == true) {
				GUI.contentColor = Color.black;
				if (GUI.Button(new Rect(Screen.width/5 + 125, Screen.height/2+50, 100, 50), "Player")) {
					GUI.contentColor = Color.black;
					GameSettings.Instance.one = false;
				}
			}
			if (GameSettings.Instance.one == false) {
				GUI.contentColor = Color.red;
				if (GUI.Button(new Rect(Screen.width /5 + 125, Screen.height / 2 + 50, 100, 50), "CPU")) {
					GameSettings.Instance.one = true;
				}
			}
			if (GameSettings.Instance.two == true) {
				GUI.contentColor = Color.blue;
				if (GUI.Button(new Rect(Screen.width / 4 + 150, Screen.height / 2+50, 100, 50), "Player")) {
					GameSettings.Instance.two = false;
				}
			}
			if (GameSettings.Instance.two == false) {
				GUI.contentColor = Color.blue;
				if (GUI.Button(new Rect(Screen.width / 4 + 150, Screen.height / 2+50, 100, 50), "CPU")) {
					GameSettings.Instance.two = true;

				}
			}
			if (GameSettings.Instance.three == true) {
				GUI.contentColor = Color.green;
				if (GUI.Button(new Rect(Screen.width / 3 + 175, Screen.height / 2+50, 100, 50), "Player")) {
					GameSettings.Instance.three = false;
				}
			}
			if (GameSettings.Instance.three == false) {
				GUI.contentColor = Color.green;
				if (GUI.Button(new Rect(Screen.width / 3 + 175, Screen.height / 2+50, 100, 50), "CPU")) {
					GameSettings.Instance.three = true;
				}
			}
			if (GameSettings.Instance.four == true) {
				GUI.contentColor = Color.yellow;
				if (GUI.Button(new Rect(Screen.width / 2 + 75, Screen.height / 2+50, 100, 50), "Player")) {
					GameSettings.Instance.four = false;
				}
			}
			if (GameSettings.Instance.four == false) {
				GUI.contentColor = Color.yellow;
				if (GUI.Button(new Rect(Screen.width / 2 + 75, Screen.height / 2+50, 100, 50), "CPU")) {
					GameSettings.Instance.four = true;
				}
			}
			if (start) {
				GUI.contentColor = Color.red;
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 125, 100, 50), "GO!")) {
					Application.LoadLevel(1);
				}
			}
		}
	}
}