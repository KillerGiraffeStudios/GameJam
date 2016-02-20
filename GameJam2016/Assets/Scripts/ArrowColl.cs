using UnityEngine;
using System.Collections;

public class ArrowColl : MonoBehaviour {
    float launch_force = 10;
    Rigidbody2D r_body;

	// Use this for initialization
	void Start () {
        r_body = GetComponent<Rigidbody2D>();
        r_body.AddRelativeForce(new Vector2(launch_force, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Floor")) {//Sticks to floor and destroys itself later
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<Rigidbody2D>());
            Invoke("DestroySelf", 10f);
        } else if (coll.tag.Equals("Ranged")) {
            //do nothing
        } else {
            coll.SendMessage("damage", 10);
            DestroySelf();
        }
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
