using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {
	CircleCollider2D circ;
	// Use this for initialization
	void Start () {
		circ = GetComponent<CircleCollider2D> ();
		circ.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll){
		coll.SendMessage ("damage", 30);
	}
	public void activate(){
		circ.enabled = false;
		Invoke ("deactivate", 0.3f);
	}

	public void deactivate(){
		circ.enabled = false;
	}

}
