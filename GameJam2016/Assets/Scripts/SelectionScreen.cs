using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Timer.reset();
	}

	string thing = "";
	// Update is called once per frame
	void Update () {
		checkButtons (GameSettings.Instance.playerAmount);
		if(Timer.isDone == true) {
			Debug.Log ("Finished");
			Timer.isDone = false;
            SceneManager.LoadScene(2);
		}
	}

	//check the P1 to P4 last button chosen
	void checkButtons(string [] arr) {			
		for(int i = 0; i < arr.Length; i++) {
			if(Input.GetButtonDown(arr[i] + "_Fire1")) {
				GameSettings.Instance.playerClasses [i] = 1;
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire2")) {
				GameSettings.Instance.playerClasses [i] = 2;
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire3")) {
				GameSettings.Instance.playerClasses [i] = 3;
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire4")) {
				GameSettings.Instance.playerClasses [i] = 4;
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire5")) {
				GameSettings.Instance.playerClasses [i] = 5;
				break;
			}
			if(Input.GetButtonDown(arr[i] + "_Fire6")) {
				GameSettings.Instance.playerClasses [i] = 6;
				break;
			}
		}
	}
}
