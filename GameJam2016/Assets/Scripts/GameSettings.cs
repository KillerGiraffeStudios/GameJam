using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	//the number of players in the game - may not be needed
	public int players;

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
		
	}
}


