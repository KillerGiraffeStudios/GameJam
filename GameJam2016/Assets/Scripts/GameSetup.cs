using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    enum PlayerClasses { Empty, Knight, Ranger, Berserker, Rogue, Wizard, Random }
    int determineClass = 0;

	//the variables to check if game has ended 
	public bool isEnd = false;
	public static double timer = 3.0;
	public string winner;

    private bool matchStart = false;

    GameObject[] Players;
    System.Random rand= new System.Random();
    
    // Use this for initialization
    void Start () {
        Players = new GameObject[] { GameObject.Find("P1"), GameObject.Find("P2"), GameObject.Find("P3"), GameObject.Find("P4") };
        matchReady();
        determineClass =rand.Next(0, 100);

    }
	
	// Update is called once per frame
	void Update () {
		if(isEnd == true) {
			timer -= Time.deltaTime;
			if(timer <= 0) {
				Destroy(GameObject.Find("GameSettings"));
				Application.LoadLevel (0);
			}
		}
		hasEnded ();
    }

    void matchReady()
    {
        //0 is default for none chosen
        //1 - Knight
        //2 - Ranger
        //3 - Berserker
        //4 - Assassin
        //5 - Wizard
        //6 - Random 
        matchStart = true;
        int[] x = GameSettings.Instance.playerClasses;
        for(int i=0;i< x.Length; i++)
        {
            PlayerClasses y = (PlayerClasses)x[i];
            
            print(y.ToString());
            if (y.ToString().Equals("Random"))
            {
                determineClass = rand.Next(0, 101);
                if(determineClass>80)   
                {
                    x[i] = 5;
                } else if(determineClass>60)
                {
                    x[i] = 4;
                }
                else if (determineClass > 40)
                {
                    x[i] = 3;
                }
                else if (determineClass > 20)
                {
                    x[i] = 2;
                } else if(determineClass>10)
                {
                    x[i] = 1;
                } else
                {
                    x[i] = 1;
                }
            }
            //If we don't get more than berserker done
            /*if (x[i] == 1 || x[i] == 2 || x[i] == 4 || x[i] == 5)
            {
                x[i] = 3;
            }*/

            y = (PlayerClasses)x[i];
            print(y.ToString());
            Players[i].GetComponent<PlayerClass>().setName(y.ToString());
        
        }
    }

	void OnGUI() {
		if(isEnd == true) {
			var style = new GUIStyle("label");
			style.fontSize = 30;
			GUI.backgroundColor = Color.clear;
			GUI.color = Color.red; 
			GUI.Box(new Rect(Screen.width/2 - Screen.width/20, Screen.height /20, Screen.width/10, Screen.height/10), "THE WINNER IS: " + winner, style);
		}
	}

	//function to check if there is only one winner left in the battlefield
	void hasEnded() {
		int j = 0;
		for(int i = 0; i < Players.Length; i++) {
			if (Players[i] != null) {
				winner = Players [i].name;
			}
			if(Players[i] == null) {
				j++;
			}
		}
		if(j == 1) {
			isEnd = true;
		}
	}

}
