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
        if (str.Equals("Knight")){
            return Knight;
        }else if(str.Equals("Ranger")){
            return Ranger;
        } else if (str.Equals("Berserker")) {
            return Berserker;
        } else if (str.Equals("Rogue")) {
            return Rogue;
        } else if (str.Equals("Wizard")) {
            return Wizard;
        } else {
            return null;
        }
    }
}
