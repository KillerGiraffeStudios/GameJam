using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.ToString());
        //TODO: check if isTrigger is needed
        if(/*col.isTrigger !=true &&*/ col.gameObject.CompareTag("Player")) {
            col.SendMessage("damage", dmg);
            print(col.ToString()+"inside");
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
