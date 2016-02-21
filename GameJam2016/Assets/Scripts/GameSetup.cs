using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    enum Classes { Empty, Knight, Ranger, Berserker, Assassin, Wizard, Random }

    private bool matchStart = false;
    GameObject[] Players;
    
    // Use this for initialization
    void Start () {
        GameObject[] Players = { GameObject.Find("P1"), GameObject.Find("P2"), GameObject.Find("P3"), GameObject.Find("P4") };
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
            Classes y = (Classes)x[i];
            print(y);
            Players[i].GetComponent<PlayerClass>().SendMessage("setName", (Classes)x[i]);
        }
    }

}
