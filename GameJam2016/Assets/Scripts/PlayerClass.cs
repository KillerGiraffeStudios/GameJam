using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    string class_name;
    delegate void buttonDelegate();
	//Based on xbox controller
	buttonDelegate xMap;//mapping for x button
	buttonDelegate yMap;//mapping for y button
	buttonDelegate bMap;//mapping for b button
	// Use this for initialization
	void Start () {
        class_name = gameObject.tag+" ";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getName() {
        return class_name;
    }

	void setMapping(){
		string player = gameObject.name;
		xMap = attack;
		if (class_name.Equals ("Knight")) {
			yMap = knight_ground;
			bMap = knight_block;
		} else if (class_name.Equals ("Ranger")) {
			yMap = ranger_short;
			bMap = ranger_long;
		} else if (class_name.Equals ("Berserker")) {

		} else if (class_name.Equals ("Wizard")) {

		} else if (class_name.Equals ("Rogue")) {

		} else {
			print ("no valid class selected");
		}

	}

	void attack(){

	}


	void knight_block(){

	}
	void knight_ground(){

	}


	void ranger_short(){

	}
	void ranger_long(){

	}



	void berserk_y(){

	}
	void berserk_b(){

	}




	void wizard_y(){

	}
	void wizard_b(){

	}




	void rogue_y(){

	}
	void rogue_vanish(){

	}
}
