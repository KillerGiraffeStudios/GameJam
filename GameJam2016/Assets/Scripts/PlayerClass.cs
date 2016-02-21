using UnityEngine;
using System.Collections;
using UnityEditor;

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
            yMap = knight_ground;
			bMap = knight_block;
            health = 200;
            gameObject.GetComponentInChildren<AttackTrigger>().dmg = 20;
		} else if (class_name.Equals ("Ranger")) {
			yMap = ranger_short;
			bMap = ranger_long;
            health = 200;
        } else if (class_name.Equals ("Berserker")) {
            yMap = berserk_y;
            bMap = berserk_b;
            health = 200;
        } else if (class_name.Equals ("Wizard")) {
            yMap = wizard_flame;
            bMap = wizard_b;
            health = 200;
        } else if (class_name.Equals ("Rogue")) {
            yMap = rogue_y;
            bMap = rogue_vanish;
            health = 200;
        } else {
            print("No class selected removed player");
            Destroy(gameObject);
		}
        
        anim.runtimeAnimatorController = GameObject.Find("AnimatorSelect").GetComponent<AnimationSelect>().get(class_name);
    }

    void damage(int dmg) {
        health -= dmg;
        if (health <= 0) {
            anim.SetBool("Death", true);
            Invoke("death",1f);
            Destroy(gameObject.GetComponent<Collider2D>());
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

	}
	void knight_ground(){
        canPress = false;
	}


	void ranger_short(){
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        float spawnDistance = 30;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        Instantiate(arrow_short, spawnPos, playerRotation);

    }
	void ranger_long(){
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        float spawnDistance = 30;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        Instantiate(arrow_long, spawnPos, playerRotation);
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
