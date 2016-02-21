using UnityEngine;
using System.Collections;

public class Kick : MonoBehaviour {
	BoxCollider2D box;
	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider2D> ();
		box.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		coll.SendMessage ("Damage", 30);
	}

	public void activate(){
		box.enabled = true;
		Invoke ("deactivate", .3f);
	}

	void deactivate(){
		box.enabled = false;
	}
}
