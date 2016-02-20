
﻿using UnityEngine;
using System.Collections;

public class create_cells : MonoBehaviour {
	
	private int cell_cap = 200;


	public GameObject Cell;
	// Use this for initialization
	void Start () { 
		for (int i =0; i < 50; i++) {
			Vector3 pos = new Vector3 (Random.Range (-13f, 13f), Random.Range (-6.4f, 6.4f), 0);
			Instantiate (Cell, pos, Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
		float x = Random.Range (1f, 1.55f);
		Vector3 pos = new Vector3 (Random.Range(-13f,13f),Random.Range(-6.4f,6.4f),0 );
		
		if (x > 1.5 && GameObject.FindGameObjectsWithTag("cell").Length<cell_cap) {
			Instantiate(Cell,pos,Quaternion.identity);
			
		}
		
	}
}