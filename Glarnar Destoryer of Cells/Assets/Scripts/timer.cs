using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
	public float masterTime;
	Rect textArea = new Rect(Screen.width/2,Screen.height/2,Screen.width,Screen.height);
	// Use this for initialization
	void Start () {
		masterTime = 30f;
		checkIt ();

	}

	// Update is called once per frame
	void Update () {

	}

	void checkIt(){
		if (masterTime > 0) {
			Invoke ("countDown", 1f);
		}
		if (masterTime == 0) {
			reset ();
		}
	}

	
	void OnGUI(){
		GUI.Label(textArea,masterTime.ToString ());
		
	}

	public void countDown(){
		masterTime -= 1f;
		checkIt ();
	}

	public void reset(){
		GetComponent<canvasTag> ().count++;
		//gameActive (false);

		SendMessage ("restard");
	}

	public void resetTimer(){
		//gameActive (true);
		GameObject.Find ("P1").AddComponent<button_map> ().hasPressed = false;
		GameObject.Find ("P2").AddComponent<button_map> ().hasPressed = false;
		GameObject.Find ("P3").AddComponent<button_map> ().hasPressed = false;
		GameObject.Find ("P4").AddComponent<button_map> ().hasPressed = false;
		Start ();
	}

	public void gameActive(bool val){
		GameObject.Find ("P1").SetActive (val);
		GameObject.Find ("P2").SetActive (val);
		GameObject.Find ("P3").SetActive (val);
		GameObject.Find ("P4").SetActive (val);
	}
}
