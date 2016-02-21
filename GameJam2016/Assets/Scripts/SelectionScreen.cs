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
		if(Input.GetButtonDown("P1_Fire1")) {
			Debug.Log ("Hello");
		}
		if(Input.GetButtonDown("P2_Fire1")) {
			Debug.Log ("Hello2");
		}
		checkButtons (GameSettings.Instance.playerAmount);
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

	//check the P1 to P4 last button chosen
	void checkButtons(string [] arr) {			//TODO: remove the test cases
		for(int i = 0; i < arr.Length; i++) {
			if(Input.GetButtonDown(arr[i] + "_Fire1")) {
				Debug.Log (arr[i] + " Picked Knight");
				GameSettings.Instance.playerClasses [i] = 1;
				Debug.Log (GameSettings.Instance.playerClasses [i]);
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire2")) {
				Debug.Log (arr[i] + " Picked Ranger");
				GameSettings.Instance.playerClasses [i] = 2;
				Debug.Log (GameSettings.Instance.playerClasses [i]);
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire3")) {
				Debug.Log (arr[i] + " Picked Berserker");
				GameSettings.Instance.playerClasses [i] = 3;
				Debug.Log (GameSettings.Instance.playerClasses [i]);
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire4")) {
				Debug.Log (arr[i] + " Picked Assassin");
				GameSettings.Instance.playerClasses [i] = 4;
				Debug.Log (GameSettings.Instance.playerClasses [i]);
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire5")) {
				Debug.Log (arr[i] + " Picked Wizard");
				GameSettings.Instance.playerClasses [i] = 5;
				Debug.Log (GameSettings.Instance.playerClasses [i]);
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire6")) {
				Debug.Log (arr[i] + " Picked Random");
				GameSettings.Instance.playerClasses [i] = 6;
				Debug.Log (GameSettings.Instance.playerClasses [i]);
				break;
			}
		}
	}
}
