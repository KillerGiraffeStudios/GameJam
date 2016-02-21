using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    enum PlayerClasses { Empty, Knight, Ranger, Berserker, Rogue, Wizard, Random }
    int determineClass = 0;

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
    }

    void matchReady()
    {
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
            y = (PlayerClasses)x[i];
            Players[i].GetComponent<PlayerClass>().setName(y.ToString());
        
        }
    }

}
