using UnityEngine;
using System.Collections;

public class AnimationSelect : MonoBehaviour {
    public RuntimeAnimatorController Knight;
    public RuntimeAnimatorController Ranger;
    public RuntimeAnimatorController Berserker;
    public RuntimeAnimatorController Assassin;
    public RuntimeAnimatorController Wizard;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public RuntimeAnimatorController get(string str) {
        switch (str) {
            case "Knight": return Knight;
            case "Ranger": return Ranger;
            case "Berserker": return Berserker;
            case "Assassin": return Assassin;
            case "Wizard":return Wizard;
            default: print("FAIL"); return null;
        }
    }
}
