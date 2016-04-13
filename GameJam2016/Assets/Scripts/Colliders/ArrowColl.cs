using UnityEngine;
using System.Collections;

public class ArrowColl : MonoBehaviour {
    float launch_force = 50;
    public int arrow_damage = 10;
    Rigidbody2D r_body;

	// Use this for initialization
	void Start () {
        r_body = GetComponent<Rigidbody2D>();
        r_body.AddRelativeForce(new Vector2(launch_force, 0));
	}
	
	// Update is called once per frame
	void Update () {
        //rotates arrow according to its velocity
        if(r_body!= null) {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Cos(r_body.velocity.y / r_body.velocity.x) * 90 / Mathf.PI);
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Floor")) {//Sticks to floor and destroys itself later
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<Rigidbody2D>());
            Invoke("DestroySelf", 10f);
        } else if (coll.tag.Equals("Ranged")) {//Hits another arrow
            //do nothing
        } else {//send damage message to hit thing and destroy instantly
            coll.SendMessage("damage", arrow_damage);
            DestroySelf();
        }
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
