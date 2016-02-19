using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
    int max_speed = 5;
    int move_force = 5;
    Rigidbody2D r_body;
	// Use this for initialization
	void Start () {
        r_body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0.1 && Mathf.Abs(r_body.velocity.x)<max_speed) {
            r_body.AddForce(new Vector2(Input.GetAxis("Horizontal") * move_force, 0));
        }
	}
}
