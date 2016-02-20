using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//the float to hold our timer with how long the timer is
	public double timer = 10.0;

	//equates to true when the timer has completed
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

	void OnGUI() {
		GUI.Box(new Rect(Screen.width/2 - 25, 50, 50, 25), "" + timer.ToString("0"));
	}
}
