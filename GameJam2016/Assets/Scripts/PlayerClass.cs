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

    private int dmg_dealt = 10;
	// Use this for initialization
	void Start () {
        //see setname, Gets info from Game Setup Script
        //class_name = gameObject.tag+" ";
        anim = gameObject.GetComponent<Animator>();
        //*******************************************************************
        setMapping();
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
        if (canPress && !gameObject.GetComponent<MoveScript>().lock_strong) {
            if (Input.GetButtonDown(gameObject.name + "_Fire2")) {
				anim.SetTrigger ("Attack");
                xMap();
            }else if (Input.GetButtonDown(gameObject.name + "_Fire3")) {
                anim.SetTrigger("Special");
                yMap();
            } else if (Input.GetButtonDown(gameObject.name + "_Fire4")) {
				anim.SetTrigger ("Block");
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
        switch (class_name) {
            case "Knight":
                yMap = knight_ground;
			    bMap = knight_block;
                health = 200;
                dmg_dealt = 20;
                break;
            case "Ranger":
                yMap = ranger_short;
			    bMap = ranger_long;
                health = 200;
                break;
            case "Berserker":
                yMap = berserk_y;
                bMap = berserk_b;
                health = 200;
                break;
            case "Wizard":
                yMap = wizard_flame;
                bMap = wizard_b;
                health = 200;
                break;
            case "Assassin":
                yMap = assassin_y;
                bMap = assassin_vanish;
                health = 200;
                break;
            default:
                print("No class selected removed player");
                Destroy(gameObject);
                break;
		}
        anim.runtimeAnimatorController = GameObject.Find("AnimatorSelect").GetComponent<AnimationSelect>().get(class_name);
		//GetComponent<MoveScript> ().setAnim ();
    }

    void damage(int dmg) {
        health -= dmg;
        print(health);
        if (health <= 0) {
			anim.SetTrigger("Dead");
            Invoke("death",3f);
            Destroy(gameObject.GetComponent<Collider2D>());
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<MoveScript>().lock_strong = true;
        } else {
            anim.SetTrigger("Hit");
        }
    }
    void death() {
        Destroy(gameObject);
    }
	void attack(){
        anim.SetTrigger("Attack");
	}


	void knight_block(){
        anim.SetTrigger("Block");
    }
	void knight_ground(){
        canPress = false;
	}


	void ranger_short(){
        
        Vector3 playerDirection;
        Quaternion playerRotation = transform.rotation;
        if (gameObject.GetComponent<MoveScript>().facingLeft)
        {
            playerRotation.eulerAngles = new Vector3(0, 0, 170);
            playerDirection = new Vector3(transform.position.x - 1, transform.position.y);

        }
        else
        {
            playerDirection = new Vector3(transform.position.x + 1, transform.position.y);
        }
        Instantiate(arrow_long, playerDirection, playerRotation);
        

    }
	void ranger_long(){
        canPress = false;
        Vector3 playerDirection;
        Quaternion playerRotation = transform.rotation;
        if(gameObject.GetComponent<MoveScript>().facingLeft)
        {
            playerRotation.eulerAngles = new Vector3(0, 0, 150);
            playerDirection = new Vector3(transform.position.x - 1, transform.position.y);
        } else
        {
            playerRotation.eulerAngles = new Vector3(0, 0, 20);
            playerDirection = new Vector3(transform.position.x + 1, transform.position.y);

        }
        Instantiate(arrow_long, playerDirection, playerRotation);

    }



	void berserk_y(){

	}
	void berserk_b(){

	}




	void wizard_flame(){
        anim.SetTrigger("Special");
    }
	void wizard_b(){

	}




	void assassin_y(){

	}
	void assassin_vanish(){

	}

    void shoot()
    {

    }
}
