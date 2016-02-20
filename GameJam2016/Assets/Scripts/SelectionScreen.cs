using UnityEngine;
using System.Collections;

public class SelectionScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	string thing = "";
	// Update is called once per frame
	void Update () {
		//TODO: remove all these tests
		if(Input.anyKey) {
		thing = Input.inputString;
			Debug.Log (gameObject.name);
		}
		if (thing == "e") {
			Debug.Log ("test");
		}
		if(Timer.isDone == true) {
			Debug.Log ("Finished");
			Timer.isDone = false;
			Timer.reset();	//TODO: remove this test
		}
	}

	void updateObject() {
		for (int i = 0; i < GameSettings.Instance.playerAmount.Length; i++) {
			//TODO: set game object of the player as the type selected when the timer ran out
		}
	}
		
}
