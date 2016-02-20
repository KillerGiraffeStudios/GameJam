using UnityEngine;
using System.Collections;

public class canvasTag : MonoBehaviour {

	public Texture buttonTexture;
	public Texture2D icon;

	bool show = false;

	int numRounds = 4;
	bool p1 = false;
	bool p2 = false;
	bool p3 = false;
	bool p4 = false;

	public int count = 1;
	bool complete = false;

	//the windows
	public Rect windowRect = new Rect(500, 500, Screen.width, Screen.height);
	public Rect windowRect2 = new Rect(300,400, 300, 400);
	public Rect windowRect3 = new Rect(100,100, 300, 400);
	public Rect windowRect4 = new Rect(100,100, 300, 400);
	public Rect windowRect5 = new Rect(100,100, 300, 400);

	GUI.WindowFunction windowFunction;
	GUI.WindowFunction windowFunction2;
	GUI.WindowFunction windowFunction3;
	GUI.WindowFunction windowFunction4;
	GUI.WindowFunction windowFunction5;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(GameSettings.Instance.one == false) {
			p1 = true;
		}
		if(GameSettings.Instance.two == false) {
			p2 = true;
		}
		if(GameSettings.Instance.three == false) {
			p3 = true;
		}
		if(GameSettings.Instance.four == false) {
			p4 = true;
		}

		windowFunction = DoMyWindow;
		windowFunction2 = DoMyWindow2;
		windowFunction3 = DoMyWindow3;
		windowFunction4 = DoMyWindow4;
		windowFunction5 = DoMyWindow5;
		if(p1 == true && p2 == true && p3 == true && p4 == true) {
			complete = true;
		}
		if (show) {
			restard ();
		}

	}

	void OnGUI()
	{	
		GUI.skin.button.fontSize = 10;
		if (GameSettings.Instance.one == true && show == true) {
			windowRect = GUI.Window (0, windowRect, windowFunction, "P1 Evolve");
		}
		if(GameSettings.Instance.two == true && show == true) {
			windowRect2 = GUI.Window(1, windowRect2, windowFunction2, "P2 Evolve");
		}
		if(GameSettings.Instance.three == true && show == true) {
			windowRect3 = GUI.Window(2, windowRect3, windowFunction3, "P3 Evolve");
		}
		if(GameSettings.Instance.four == true && show == true) {
			windowRect4 = GUI.Window(3, windowRect4, windowFunction4, "P4 Evolve");
		}

		if(count>numRounds) {
			windowRect5 = (GUI.Window (4, windowRect5, windowFunction5, "")); 
		}
	}


	void DoMyWindow(int windowID)
	{
        if (GUI.Button(new Rect(225, 75, 100, 20), "Size " + 1000))
        {
            

            GameObject play = GameObject.Find("P1");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().sizeUpgrade();
            }
        }

            if (GUI.Button(new Rect(75, 75, 100, 20), "Speed " + 1000))
            {
            GameObject play = GameObject.Find("P1");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().speedUpgrade();
            }
        }

            if (GUI.Button(new Rect(150, 200, 100, 20), "Complete"))
            {
                p1 = true;
            }
        }

	

	void DoMyWindow2(int windowID2)
	{
		if (GUI.Button (new Rect(225, 75, 100, 20), "Size " + 1000)) {
            GameObject play = GameObject.Find("P2");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().sizeUpgrade();
            }

        }
        

		if (GUI.Button (new Rect (75, 75, 100, 20), "Speed "+1000)) {
            GameObject play = GameObject.Find("P2");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().speedUpgrade();
            }
        }

		if (GUI.Button (new Rect(150, 200, 100, 20), "Complete")) {
			p2 = true;
		}

	}

	void DoMyWindow3(int windowID3)
	{
		if (GUI.Button (new Rect(225, 75, 100, 20), "Size " + 1000)) {
            GameObject play = GameObject.Find("P3");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().sizeUpgrade();
            }
        }
		
		if (GUI.Button (new Rect (75, 75, 100, 20), "Speed " + 1000)) {
            GameObject play = GameObject.Find("P3");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().speedUpgrade();
            }
        }

		if (GUI.Button (new Rect(150, 200, 100, 20), "Complete")) {
			p3 = true;
		}

	}

	void DoMyWindow4(int windowID4)
	{
		if (GUI.Button (new Rect(225, 75, 100, 20), "Size " + 1000)) {
            GameObject play = GameObject.Find("P4");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().sizeUpgrade();
            }
        }
		
		if (GUI.Button (new Rect (75, 75, 100, 20), "Speed " + 1000)) {
            GameObject play = GameObject.Find("P4");
            if (play.GetComponent<moveScript>().Score >= 1000)
            {
                play.GetComponent<moveScript>().Score -= 1000;
                play.GetComponent<moveScript>().speedUpgrade();
            }
        }

		if (GUI.Button (new Rect(150, 200, 100, 20), "Complete")) {
			p4 = true;
		}

	}

	void DoMyWindow5(int windowID5)
	{
		if (GUI.Button (new Rect (0, 0, 100, 50), "Reset")) {
			Application.LoadLevel(0);
		}
		
	}

	public void restard() {
		if (count > numRounds) {
			GetComponent<timer>().enabled = false;

			return;
		}
		show = true;
		if (p1 == true && p2 == true && p3 == true && p4 == true) {
			p1 = false;
			p2 = false;
			p3 = false;
			p4 = false;
			show = false;
			gameObject.SendMessage ("resetTimer");
		}

	}


	

}