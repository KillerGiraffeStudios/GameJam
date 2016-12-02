using UnityEngine;
using System.Collections;


/**
 * <summary>Controls most of the movement and </summary>
 * <remarks></remarks>
 */
public class MoveScript : MonoBehaviour {
    public int max_speed = 3;
    public int move_force = 10;
    public int max_jumps = 2;
    public float initial_jump_force = 75f;
    public float continued_jump_force = 10f;
    public int jump_limit = 20;
    int jump_time = 0;
    public bool facingLeft;

    public bool lock_weak = false;     //Used for animation and facing direction
    public bool lock_strong = false;   //Disable all user input
    Rigidbody2D r_body;
    int numOfJumpsRemaning;
    bool onFloor = false;
	Animator anim;
	//bool animSet=false;
    // Use this for initialization
    void Start() {
        r_body = GetComponent<Rigidbody2D>();
        numOfJumpsRemaning = max_jumps;
        anim = GetComponent<Animator>();
    }

	public void setAnim() {
        anim = GetComponent<Animator>();
    }
		
    void FixedUpdate() {

    }
    // Update is called once per frame
    void Update()
	{
        if (lock_strong)//Don't do anything on strong lock
            return;


		//Animations
		anim.SetFloat ("Speed", Mathf.Abs (r_body.velocity.x));
        anim.SetFloat("yVelocity", r_body.velocity.y);
        anim.SetBool("OnGround", onFloor);
        anim.SetBool("canMove", !lock_weak);

        if (!lock_weak) {
            float h = Input.GetAxis(gameObject.name + "_Horizontal");
            if (Mathf.Abs(h) > 0.15 && Mathf.Abs(r_body.velocity.x) < max_speed && !lock_weak) {
                if (h > 0.15) {
                    facingLeft = false;
                } else {
                    facingLeft = true;
                }
                r_body.AddForce(new Vector2(h * move_force, 0));
                //gameObject.GetComponent<PlayerClass>().SendMessage("run");
            }
            if (Mathf.Abs(h) > .1f) {
                Vector3 tmp = transform.localScale;
                tmp.x = Mathf.Abs(tmp.x);
                tmp.x *= Mathf.Sign(h);
                transform.localScale = tmp;
            }








            if(Input.GetButtonDown(gameObject.name + "_Fire1")) {
                
                Vector2 tmp = r_body.velocity;
                tmp.y = 0;

                if (r_body.velocity.x * Input.GetAxis(gameObject.name + "_Horizontal") < 0)
                    tmp.x = 0;
                r_body.velocity = tmp;

                r_body.AddForce(new Vector2(Input.GetAxis(gameObject.name + "_Horizontal") * move_force, initial_jump_force));
            }

            if (Input.GetButton(gameObject.name + "_Fire1")) {
                jump();
            }

            if (Input.GetButtonUp(gameObject.name + "_Fire1"))
            {
                jump_time = 0;
                if (numOfJumpsRemaning > 0)
                    numOfJumpsRemaning--; 

            }






        }
        if (r_body.velocity.y < 0) {
            onFloor = false;
        }
    }


    void jump() {
        if (jump_time < jump_limit) { 
            
            r_body.AddForce(new Vector2(Input.GetAxis(gameObject.name + "_Horizontal") * move_force, continued_jump_force));
            jump_time++;
        }
        //r_body.AddForce(new Vector2(0, jump_force));
        anim.SetTrigger("Jump");
        
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


    
}
