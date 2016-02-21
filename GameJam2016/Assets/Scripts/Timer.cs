using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//the float to hold our timer with how long the timer is
	public static double timer = 1.0;

	//equates to true when the timer has completed
	//static to be accessed throughout all fields
	public static bool isDone = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//countdown the timer
		timer -= Time.deltaTime;

		if(timer <= 0) {
			isDone = true;
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
		style.fontSize = 40;
		GUI.backgroundColor = Color.clear;
		GUI.color = Color.yellow; 
		GUI.Box(new Rect(Screen.width/2 - 25, 50, 100, 100), "" + timer.ToString("0"), style);
	}
}
