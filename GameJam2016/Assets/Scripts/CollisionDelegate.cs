using UnityEngine;
using System.Collections;

/// <summary>
/// Delegate for Player based collisions
/// </summary>
public class CollisionDelegate : MonoBehaviour {
    PlayerClass pClass;
	// Use this for initialization
	void Start () {
        pClass = GetComponent<PlayerClass>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnterCollision2D(Collider2D coll) {
		if (coll.tag.Equals("Melee")) {
            coll.gameObject.SendMessage("damage", coll.gameObject);
        }
    }
}
