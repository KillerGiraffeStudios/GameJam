using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    string class_name;
    delegate void buttonDelegate();
	buttonDelegate bMap;
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
		if (class_name.Equals ("Knight")) {
			
		}







		if(class_name.Equals("Ranger")){

		}







		if (class_name.Equals ("Berserker")) {

		}

	}
}
