using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveScript : MonoBehaviour {
	public Vector3 size;
	public int Score;
	public Rigidbody2D r_body;
	public float move_force;
	float cutoffRange = 0.5f;	// cut off range
	Rect x;

	bool trigger = true;
	string labelText;
	public GUIStyle labelStyle;
	
	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D> ();
		move_force = GetComponent<float> ();
	}
	
	// Update is called once per frame
	void Update () {
		labelText = GetComponent<moveScript>().Score.ToString();
		float x_mov = Input.GetAxis (name + "_Horizontal");
		float y_mov = Input.GetAxis (name +"_Vertical");
		
		if (x_mov > -cutoffRange && x_mov < cutoffRange) {
			x_mov = 0;
		}
		if (y_mov > -cutoffRange && y_mov < cutoffRange) {
			y_mov = 0;
		}
		r_body.AddForce (new Vector2 (x_mov * move_force, y_mov * move_force));
	}

	void OnGUI () {
		if (trigger) {
			int tX = 1;
			int tY = 1;
				if (gameObject.name == "P1") {
					tX = 25;
					tY = 25;
				} else if (gameObject.name == "P2") {
					tX = Screen.width -50;
					tY = 50;
				} else if (gameObject.name == "P3") {
					tX = 50;
					tY = Screen.height-50;
				} else if (gameObject.name == "P4") {
					tX = Screen.width -50;
					tY = Screen.height-50;
			}
			x = new Rect (tX, tY, 100, 100);
			trigger = false;
		}
		if (!trigger) {
			GUI.Label (x, labelText);
		}
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "cell") {
            Destroy(coll.gameObject);
            Score = Score + 100;
            Vector3 size = new Vector3(0.085f, 0.085f, 0.085f);
            transform.localScale += size;
            if (r_body.mass < 1.5f) {
                r_body.mass += 0.04f;
            } else if (r_body.mass < 3.0f) {
                r_body.mass += 0.02f;
            } else if (r_body.mass > 3.0f) {
                r_body.mass += 0.005f;
            }

        }
        if ((coll.gameObject.tag == "Player") && (transform.localScale.x > (coll.gameObject.transform.localScale.x * 1.1f)))
        {
            Score += coll.gameObject.GetComponent<moveScript>().Score / 10;
            coll.gameObject.GetComponent<moveScript>().Score -= coll.gameObject.GetComponent<moveScript>().Score/10;
            transform.localScale += coll.gameObject.transform.localScale / 10;
            coll.gameObject.transform.localScale -= coll.gameObject.transform.localScale / 10;
            coll.gameObject.SendMessage("pDeath");
        }
	}


	
	//************* POWER UPS *************
	public void speedBoost(){
		move_force *= 1.5f;
		Invoke ("stopBoost", 5f);
	}
	public void stopBoost(){
		move_force /= 1.5f;
	}
	public void sizeBoost() {
		size= transform.localScale*0.2f;
		transform.localScale+=size;
		Invoke ("stopSize",5f);

	}
	public void stopSize() {
		transform.localScale-=size;
	}
    public void pointBoost()
    {
        Score += 1000;
    }


//*********** Permanent ***********
	public void pDeath(){

        gameObject.GetComponent<respawn>().reset();

		//Call respawn script
		//get function
	}


    public void sizeUpgrade()
    {
        Vector3 increase = new Vector3(0.165f, 0.165f, 0);
        transform.localScale +=  increase;
    }

    public void speedUpgrade()
    {
        float increase = 0.55f;
        move_force += increase;


    }
}
