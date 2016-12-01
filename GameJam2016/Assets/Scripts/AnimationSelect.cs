using UnityEngine;
using System.Collections;

public class AnimationSelect : MonoBehaviour {
    public RuntimeAnimatorController Knight;
    public RuntimeAnimatorController Ranger;
    public RuntimeAnimatorController Berserker;
    public RuntimeAnimatorController Rogue;
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
            case "Rogue": return Rogue;
            case "Wizard":return Wizard;
            default: print("FAIL"); return null;
        }
    }
}
