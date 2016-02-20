using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {

	Vector3 spawn;

	// Use this for initialization
	void Start () {

		spawn = new Vector3 (transform.position.x,transform.position.y,transform.position.z);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void reset()
    {
        gameObject.transform.position = spawn;
    }
}
