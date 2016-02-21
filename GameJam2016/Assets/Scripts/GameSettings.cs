using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	//the number of players in the game - may not be needed
	public int players;

	//the variable that will become the array of GameObjects
	public string []playerAmount;

	//keeps track if a match has been started from the Menu
	public bool matchSet = false;

	//if timer runs out, end the match and prompt restart
	public bool matchEnd = false;

	//Global settings for which class a character chooses
	//0 is default for none chosen
	//1 - Knight
	//2 - Ranger
	//3 - Berserker
	//4 - Assassin
	//5 - Wizard
	//6 - Random 
	public int [] playerClasses = new int[4];

	private static GameSettings _instance;
	public static GameSettings Instance
	{
		get
		{
			if (GameSettings._instance == null){
				GameSettings._instance = new GameObject("GameSettings").AddComponent<GameSettings>();
				DontDestroyOnLoad(GameSettings._instance);
			}
			return GameSettings._instance;
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		for(int i = 0; i < 4; i++) {
			playerClasses [i] = 0;	//init all 0 for non classes
		}
	}

	// Update is called once per frame
	void Update () {
		if (matchSet == true) {
			//TODO: possible change this logic
			//players = GameObject.FindGameObjectsWithTag("Player");
			playerAmount = new string[players];	//create the amount of players in the game
			for (int i = 0; i < players; i++) {
				playerAmount [i] = "P" + (i+1).ToString();
				playerClasses[i] = 6;
				Debug.Log (playerClasses[i]);
				Debug.Log (playerAmount[i]);		//TODO: remove test
			}
			Debug.Log(playerAmount.Length);			//TODO: remove test
			matchSet = false;						//set false so we do not loop anymore
		}
	}
}


