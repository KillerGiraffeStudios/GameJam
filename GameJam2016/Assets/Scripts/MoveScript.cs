using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
    public int max_speed = 3;
    public int move_force = 10;
    public int max_jumps = 2;
    public int jump_force = 200;
    public bool facingLeft;
    Rigidbody2D r_body;
    int numOfJumpsRemaning;
    bool jumpPressed = false;
    bool onFloor = false;
    bool isSleeping = false;
	Animator anim;
	bool animSet=false;
    // Use this for initialization
    void Start() {
        r_body = GetComponent<Rigidbody2D>();
        numOfJumpsRemaning = max_jumps;
    }

	public void setAnim(){
		anim = GetComponent<Animator> ();
	}
		
    // Update is called once per frame
    void Update()
	{
		//Animations
		anim.SetFloat ("Speed", Mathf.Abs (r_body.velocity.x));
		if (Mathf.Abs (r_body.velocity.y) > 0) {
			anim.SetBool("jumping", true);
		} else {
			anim.SetBool("jumping", false);
		}

        if (!isSleeping)
        {
            float h = Input.GetAxis(gameObject.name + "_Horizontal");
            if (Mathf.Abs(h) > 0.15 && Mathf.Abs(r_body.velocity.x) < max_speed) {
                if(h>0.15)
                {
                    facingLeft = false;
                } else
                {
                    facingLeft = true;
                }
                r_body.AddForce(new Vector2(h * move_force, 0));
                //gameObject.GetComponent<PlayerClass>().SendMessage("run");
            }
            if (jumpPressed == true) {
                if (Input.GetButtonDown(gameObject.name + "_Fire1")) {
                    if (numOfJumpsRemaning > 0) {
                        jump();
                    }

                }
            }
            if (Mathf.Abs(h) > .1f) {
                Vector3 tmp = transform.localScale;
                tmp.x = Mathf.Abs(tmp.x);
                tmp.x *= Mathf.Sign(h);
                transform.localScale = tmp;
            }
            if (Input.GetButtonUp(gameObject.name + "_Fire1"))
            {
                jumpPressed = true;
            }
        }
        if (r_body.velocity.y < 0) {
            onFloor = false;
        }
    }
    

    void jump() {
        Vector2 tmp = r_body.velocity;
        tmp.y = 0;
        r_body.velocity = tmp;
        if(r_body.velocity.x*Input.GetAxis(gameObject.name+"_Horizontal")<0)
        {
            Vector2 tmp2 = r_body.velocity;
            tmp2.x = 0;
            r_body.velocity = tmp2;
            r_body.AddForce(new Vector2(Input.GetAxis(gameObject.name + "_Horizontal")*move_force, jump_force));
        } else
        {
                    r_body.AddForce(new Vector2(0, jump_force));
        }

        numOfJumpsRemaning--;
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Floor")) {

            numOfJumpsRemaning = max_jumps;
            onFloor = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }

    }


    void sleep(float time)
    {
        isSleeping = true;
        Invoke("notSleeping", time);
    }
    void notSleeping()
    {
        isSleeping = false;
    }

}
