using UnityEngine;
using System.Collections;

public class meta_script : MonoBehaviour {
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
