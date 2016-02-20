using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
	public bool one = true;
	public bool two = true;
	public bool three = true;
	public bool four = true;

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
