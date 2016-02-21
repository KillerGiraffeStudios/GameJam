using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//the float to hold our timer with how long the timer is
	public static double timer = 10.0;

	//equates to true when the timer has completed
	//static to be accessed throughout all fields
	public static bool isDone = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//countdown the timer

		if (timer <= 0) {
			isDone = true;
		} else {
			timer -= Time.deltaTime;
		}
	}

	//reset the timer if needed
	public static void reset() {
		timer = 10.0;
		isDone = false;
	}

	//GUI to display the timer
	void OnGUI() {
		var style = new GUIStyle("label");
		style.fontSize = 30;
		GUI.backgroundColor = Color.clear;
		GUI.color = Color.white; 
		GUI.Box(new Rect(Screen.width/2 - Screen.width/50, Screen.height / 20, Screen.width/25, Screen.height/15), "" + timer.ToString("0"), style);
	}
}
