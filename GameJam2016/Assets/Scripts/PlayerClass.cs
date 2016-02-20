using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    string class_name;
    delegate void class_delegate();
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
}
