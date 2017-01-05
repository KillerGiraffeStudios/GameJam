using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
    public string class_name;
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

    /*
     * _Fire2 = bMap = Block
     * _Fire3 = xMap = Attack
     * _Fire4 = yMap = Special
    */
    
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponent<MoveScript>().lock_strong) {
            if (Input.GetButtonDown(gameObject.name + "_Fire3")) {
				anim.SetTrigger ("Attack");
                xMap();
            }else if (Input.GetButtonDown(gameObject.name + "_Fire4")) {
                anim.SetTrigger("Special");
                yMap();
            } else if (Input.GetButtonDown(gameObject.name + "_Fire2")) {
				anim.SetTrigger ("Block");
                bMap();
            }
        }
	}

    public void setName(string name)
    {
        class_name = name;

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
                yMap = ranger_long;
			    bMap = ranger_short;
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
        //Middle of hit/Dead animation? INVULNERABLE!!
        if (gameObject.GetComponent<MoveScript>().lock_strong)
            return;

        //Deal damage
        health -= dmg;

        //Trigger death if health below zero
        //otherwise trigger damage
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
	void attack() {
        anim.SetTrigger("Attack");
    }


	void knight_block(){
    }
	void knight_ground(){

	}


	void ranger_short(){
        GameObject temp = Instantiate<GameObject>(arrow_short);
        temp.transform.position = arrow_short.transform.position;
        if (GetComponent<MoveScript>().facingLeft)
            temp.transform.Rotate(0, 0, 180);
        temp.SetActive(true);
    }
	void ranger_long(){
        GameObject temp = Instantiate<GameObject>(arrow_long);
        temp.transform.position = arrow_long.transform.position;
        if (GetComponent<MoveScript>().facingLeft)
            temp.transform.Rotate(0, 180, 90);
        temp.SetActive(true);
    }


	void berserk_y(){

	}
	void berserk_b(){

	}




	void wizard_flame(){
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
