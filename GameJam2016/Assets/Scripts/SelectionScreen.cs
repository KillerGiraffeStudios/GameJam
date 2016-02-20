using UnityEngine;
using System.Collections;

public class SelectionScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	string thing = "";
	// Update is called once per frame
	void Update () {
		if(Input.anyKey) {
		thing = Input.inputString;
			Debug.Log (gameObject.name);
		}
		if (thing == "e") {
			Debug.Log ("test");
		}
		if(Timer.isDone == true) {
			Debug.Log ("Finished");
		}
	}

	void updateObject() {

	}
}
