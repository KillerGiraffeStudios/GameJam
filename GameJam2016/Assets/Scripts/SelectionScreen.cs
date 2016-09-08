using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour {

	public Texture info;
	public bool time = false;

	// Use this for initialization
	void Start () {
		info = Resources.Load ("select") as Texture2D;
	}

	
	// Update is called once per frame
	void Update () {
		if (time == false) {
			Timer.reset ();
			time = true;
		}
		checkButtons (GameSettings.Instance.playerAmount);
		if(Timer.isDone == true) {
			Debug.Log ("Finished");
			Timer.isDone = false;
            System.Random rand = new System.Random();
            SceneManager.LoadScene(2);
		}
	}

	//the selection screen
	void OnGUI() {
		GUI.DrawTexture(new Rect(Screen.width/4 - Screen.width/5, Screen.height / 10, Screen.width - Screen.width / 7, Screen.height - Screen.height / 7), info);
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
