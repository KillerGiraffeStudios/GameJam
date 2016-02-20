using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    string class_name;
    bool canPress = true;
    delegate void buttonDelegate();
	//Based on xbox controller
	buttonDelegate xMap;//mapping for x button
	buttonDelegate yMap;//mapping for y button
	buttonDelegate bMap;//mapping for b button
	// Use this for initialization
	void Start () {
        class_name = gameObject.tag+" ";
	}
	
    public void sleep(float time) {
        canPress = false;
        Invoke("wake", time);
    }
    void wake() {
        canPress = true;
    }
	// Update is called once per frame
	void Update () {
        if (canPress) {
            if (Input.GetButtonDown(gameObject.name + "_Fire1")) {
                xMap();
            }else if (Input.GetButtonDown(gameObject.name + "_Fire2")) {
                yMap();
            } else if (Input.GetButtonDown(gameObject.name + "_Fire3")) {
                bMap();
            }
        }
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
            yMap = berserk_y;
            bMap = berserk_b;
		} else if (class_name.Equals ("Wizard")) {
            yMap = wizard_flame;
            bMap = wizard_b;
		} else if (class_name.Equals ("Rogue")) {
            yMap = rogue_y;
            bMap = rogue_vanish;
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




	void wizard_flame(){

	}
	void wizard_b(){

	}




	void rogue_y(){

	}
	void rogue_vanish(){

	}
}
