using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    enum Classes { Empty, Knight, Ranger, Berserker, Assassin, Wizard, Random }

    private bool matchStart = false;
    GameObject[] Players;
    
    // Use this for initialization
    void Start () {
        GameObject[] Players=GameObject.FindGameObjectsWithTag ("Player");
        print(Players[0]);
        print(Players[1]);
        print(Players[2]);
        print(Players[3]);

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
            //Players[i].
        }
    }

}
