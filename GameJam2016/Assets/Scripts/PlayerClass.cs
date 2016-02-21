using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    public string class_name;
    bool canPress = true;
    delegate void buttonDelegate();
	//Based on xbox controller
	buttonDelegate xMap;//mapping for x button
	buttonDelegate yMap;//mapping for y button
	buttonDelegate bMap;//mapping for b button

    public GameObject arrow_short;
    public GameObject arrow_long;
    Animator anim;
    public int health;
	// Use this for initialization
	void Start () {
        //see setname, Gets info from Game Setup Script
        //class_name = gameObject.tag+" ";
        anim = gameObject.GetComponent<Animator>();
		setMapping ();
	}
	
    public void sleep(float time) {
        canPress = false;
        Invoke("wake", time);
    }
    void wake() {
        canPress = true;
    }
	// Update is called once per frame
	void Update () {
        if (canPress) {
            if (Input.GetButtonDown(gameObject.name + "_Fire2")) {
                xMap();
            }else if (Input.GetButtonDown(gameObject.name + "_Fire3")) {
                yMap();
            } else if (Input.GetButtonDown(gameObject.name + "_Fire4")) {
                bMap();
            }
        }
	}

    public void setName(string name)
    {
        class_name = name;
        print(name);
        setMapping();
    }

    public string getName() {
        return class_name;
    }

	void setMapping(){
		xMap = attack;
		if (class_name.Equals ("Knight")) {
            print("1");
            yMap = knight_ground;
			bMap = knight_block;
            health = 200;
            gameObject.GetComponentInChildren<AttackTrigger>().dmg = 20;
		} else if (class_name.Equals ("Ranger")) {
            print("2");
            yMap = ranger_short;
			bMap = ranger_long;
            health = 200;
        } else if (class_name.Equals ("Berserker")) {
            print("3");

            yMap = berserk_y;
            bMap = berserk_b;
            //temp
            yMap = ranger_short;
            bMap = ranger_long;
            health = 200;
        } else if (class_name.Equals ("Wizard")) {
            print("4");
            yMap = wizard_flame;
            bMap = wizard_b;
            health = 200;
        } else if (class_name.Equals ("Rogue")) {
            print("5");
            yMap = rogue_y;
            bMap = rogue_vanish;
            health = 200;
        } else if(class_name.Equals("Empty")) {
            print("No class selected removed player");
            Destroy(gameObject);
		}
        
        anim.runtimeAnimatorController = GameObject.Find("AnimatorSelect").GetComponent<AnimationSelect>().get(class_name);
		GetComponent<MoveScript> ().setAnim ();
    }

    void damage(int dmg) {
        health -= dmg;
        print(health);
        if (health <= 0) {
			anim.SetTrigger("Dead");
            Invoke("death",3f);
            Destroy(gameObject.GetComponent<Collider2D>());
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        } else {
            anim.SetTrigger("Hit");
        }
    }
    void death() {
        Destroy(gameObject);
    }
	void attack(){
        GetComponent<Attack>().basicAttack();
        anim.SetTrigger("Attacking");
	}


	void knight_block(){
        GetComponent<Attack>().block();
	}
	void knight_ground(){
        canPress = false;
	}


	void ranger_short(){
        
        Vector3 playerDirection;
        Quaternion playerRotation = transform.rotation;
        if (gameObject.GetComponent<MoveScript>().facingLeft)
        {
            playerDirection = new Vector3(transform.position.x - 2, transform.position.y);
        }
        else
        {
            playerDirection = new Vector3(transform.position.x + 2, transform.position.y);
        }
        Instantiate(arrow_long, playerDirection, playerRotation);
        sleep(0.3f);

    }
	void ranger_long(){
        canPress = false;
        Vector3 playerDirection;
        Quaternion playerRotation = transform.rotation;
        if(gameObject.GetComponent<MoveScript>().facingLeft)
        {
            playerDirection = new Vector3(transform.position.x - 2, transform.position.y);
        } else
        {
            playerDirection = new Vector3(transform.position.x + 2, transform.position.y);
        }
        Instantiate(arrow_long, playerDirection, playerRotation);
        sleep(0.3f);

    }



	void berserk_y(){

	}
	void berserk_b(){

	}




	void wizard_flame(){

	}
	void wizard_b(){

	}




	void rogue_y(){

	}
	void rogue_vanish(){

	}

    void shoot()
    {

    }
}
