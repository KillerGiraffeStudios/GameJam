using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	//the number of players in the game - may not be needed
	public int players;

	//the variable that will become the array of GameObjects
	public GameObject []playerAmount;

	//keeps track if a match has been started from the Menu
	public bool matchSet = false;

	//if timer runs out, end the match and prompt restart
	public bool matchEnd = false;



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
	}

	// Update is called once per frame
	void Update () {
		if (matchSet == true) {
			//TODO: possible change this logic
			//players = GameObject.FindGameObjectsWithTag("Player");
			playerAmount = new GameObject[players];	//create the amount of players in the game
			Debug.Log(playerAmount.Length);			//TODO: remove test
			matchSet = false;							//set false so we do not loop anymore
		}
	}
}


