using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    enum PlayerClasses { Empty, Knight, Ranger, Berserker, Assassin, Wizard, Random }

    private bool matchStart = false;
    GameObject[] Players;
    
    // Use this for initialization
    void Start () {
        Players = new GameObject[] { GameObject.Find("P1"), GameObject.Find("P2"), GameObject.Find("P3"), GameObject.Find("P4") };
        matchReady();

    }
	
	// Update is called once per frame
	void Update () {
    }

    void matchReady()
    {
        matchStart = true;
        int[] x = GameSettings.Instance.playerClasses;
        for(int i=0;i< x.Length; i++)
        {
            PlayerClasses y = (PlayerClasses)x[i];
            print(y.ToString());
            Players[i].GetComponent<PlayerClass>().setName(y.ToString());
        
        }
    }

}
