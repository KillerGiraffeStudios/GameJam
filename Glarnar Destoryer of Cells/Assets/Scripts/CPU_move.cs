using UnityEngine;
using System.Collections;

public class CPU_move : MonoBehaviour {
	float difficulty =3f; //goes from 1 to 5
	//if used in fixed update bounds are 1 to 2

	bool cpu = false;
	//public bool one = false; 
	//public bool two = false;
	//public bool three = false;
	//public bool four = false;
	Vector3 oldpos;
	Vector2 rand;

	int counter = 0;
	Vector3 target;

	// Use this for initialization
	void Start () {
		//Switch for enabling/disabling AI
		// are you PX, AND is PX supposed to be an AI? 
//		if (true) {
//			gameObject.GetComponent<CPU_move> ().enabled = false;
//		}

	}

	// Update is called once per frame
	void Update () {
		//test functions
		//go to point (1,1)
		//goTo (new Vector3 (1f, 1f));
//		if (name.CompareTo ("P1") == 0 && gameObject.GetComponent<NewBehaviourScript> ().one) {
//			cpu = true;
//		} else if (name.CompareTo ("P2") == 0 && gameObject.GetComponent<NewBehaviourScript> ().two) {
//			cpu = true;
//		} else if (name.CompareTo ("P3") == 0 && gameObject.GetComponent<NewBehaviourScript> ().three) {
//			cpu = true;
//		} else if (name.CompareTo ("P4") == 0 && gameObject.GetComponent<NewBehaviourScript> ().four) {
//			//difficulty = 15f;
//			cpu = true;
//		} else {
//			cpu = false;
//		}
		if(name.ToString().CompareTo("P1") == 0 && GameSettings.Instance.one == false){
			difficulty = 2f;
			cpu = true;
		}
		if(name.ToString().CompareTo("P2") == 0 && GameSettings.Instance.two == false){
			difficulty = 4f;
			cpu = true;
		}
		if(name.ToString().CompareTo("P3") == 0 && GameSettings.Instance.three == false){
			cpu = true;
		}
		if(name.ToString().CompareTo("P4") == 0 && GameSettings.Instance.four == false){
			difficulty = 2f;
			cpu = true;
		}

		if(cpu){
			counter++;


			if(counter % 20 == 0){
				target = findClosest(getPos () + getVel () );
			}

			if(counter % 25 != 0 && counter % 20 == 0){
				rand.x = Random.Range(-100,100);
				rand.y = Random.Range(-100,100);

			}


			if(name.CompareTo("P1") == 0){
				if(getDist ("P1","P4") < 5){
					runFrom ("P4");
				}
				else{
					goTo (target);
				}
			}
			if(name.CompareTo("P2") == 0){
				if(getDist ("P2","P4") < 3){
					runFrom ("P4");
				}
				else{
					goTo (target);
				} 
			}
			if(name.CompareTo("P3") == 0){
				if(getDist ("P3","P4") < 3){
					runFrom ("P4");
				}
				else{
					goTo (target);
				} 
			}
			if(name.CompareTo("P4") == 0){
				if(closer ("P1", "P2")){
					if(closer ("P1", "P3")){
						chase("P1");
					}else{
						chase("P3");
					}
				}else if(closer ("P2", "P3")){
					chase("P2");
				}else{
					chase("P3");
				}
			}

		}
	}

	void chase(string prey){
		goTo (getPos (prey) + getVel(prey));
	}

	void runFrom(string from){
		goTo (getPos () + (getPos () - getPos (from)) + 2*rand.normalized);
	}

	/**
	 *@param point	takes vector 3 and heads to that direction 
	 * */
	void goTo(Vector2 point){  

		Vector2 cur = getPos();//save current position
		Vector2 uVec = point - cur;//get centered direction
		uVec.Normalize ();// turn into unit vector
		uVec = uVec * GetComponent<moveScript> ().move_force*difficulty;//multiply unit vector by move force
		GetComponent<moveScript> ().r_body.AddForce (uVec);//apply force to move to location
	}
	

	Vector2 findClosest(Vector2 here){
		GameObject[] poop = GameObject.FindGameObjectsWithTag("cell"); 
		Vector2 closest = poop[1].GetComponent<Rigidbody2D>().position; 
		float diff; 
		for(int i = 2; i < poop.Length; i++){
			if(closer (poop[i], closest)){
				closest = getPos (poop[i]); 
			}
		}
		return closest;
	}

	Vector2 getPos(GameObject g){
		return g.GetComponent<Rigidbody2D> ().position;
	}

	Vector2 getPos(){
		return getPos(name.ToString());
	}
	Vector2 getPos(string x){
		return GameObject.Find (x).GetComponent<Rigidbody2D>().position;
	}


	Vector2 getVel(GameObject g){
		return g.GetComponent<Rigidbody2D> ().velocity;
	}
	Vector2 getVel(){
		return getVel (name.ToString());
	}
	Vector2 getVel(string x){
		return GameObject.Find (x).GetComponent<Rigidbody2D> ().velocity;
	}

	float getDist(string a, string b){
		return getDist (getPos (a), getPos (b));
	}
	float getDist(Vector2 a, Vector2 b){
		return Mathf.Sqrt (Mathf.Pow(a.x - b.x,2) + Mathf.Pow(a.y - b.y,2));
	}
	

	bool closer(string a, string b){
		return closer (getPos (a), getPos (b));
	}

	bool closer(GameObject a, Vector2 b){
		return closer (getPos (a), b);
	}

	bool closer(Vector2 a, GameObject b){
		return closer (a, getPos (b));
	}

	bool closer(GameObject a, GameObject b){
		return closer (getPos (a), getPos (b));
	}

	bool closer(Vector2 left, Vector2 right){
		return getDist (left, getPos ()) < getDist (right, getPos ());
	}

	//void FixedUpdate(){
	//	goTo (GameObject.Find("P1").GetComponent <moveScript>().transform.position);
	//}
}
