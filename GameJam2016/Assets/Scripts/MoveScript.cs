using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
    public int max_speed = 3;
    public int move_force = 10;
    public int jump_force = 200;
    public int max_jumps = 2;
    int numOfJumpsRemaning;
    Rigidbody2D r_body;
    bool jumpPressed = false;
    bool onFloor = false;
    bool isSleeping = false;

    // Use this for initialization
    void Start() {
        r_body = GetComponent<Rigidbody2D>();
        numOfJumpsRemaning = max_jumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSleeping)
        {
            float h = Input.GetAxis(gameObject.name + "_Horizontal");
            if (Mathf.Abs(h) > 0.1 && Mathf.Abs(r_body.velocity.x) < max_speed) {
                r_body.AddForce(new Vector2(h * move_force, 0));
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
            if (Input.GetButtonDown(gameObject.name + "_Fire2"))
            {
                shoot();
            }
        }
    }
    

    void jump() {
        Vector2 tmp = r_body.velocity;
        tmp.y = 0;
        r_body.velocity = tmp;
        r_body.AddForce(new Vector2(0, jump_force));
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
    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Floor")) {
            onFloor = false;
        }
    }
    public GameObject Arrow;
    void shoot()
    {
        Instantiate(Arrow, transform.position, Quaternion.identity);
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
