using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {
	CircleCollider2D circ;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll){
		coll.SendMessage ("damage", 30);
	}

}
