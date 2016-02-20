using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger !=true && col.CompareTag("Player")) {
            col.SendMessage("damage", dmg);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
