using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class MoveScript : MonoBehaviour
{
=======
public class MoveScript : MonoBehaviour {
>>>>>>> Player-moves
    int max_speed = 3;
    int move_force = 10;
    Rigidbody2D r_body;
    int numOfJumpsRemaning = 2;
    bool jumpPressed = false;
    bool onFloor = false;
    bool isSleeping = false;

    // Use this for initialization
    void Start() {
        r_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update()
    {
        if (!isSleeping)
        {
            if (Mathf.Abs(Input.GetAxis(gameObject.name + "_Horizontal")) > 0.1 && Mathf.Abs(r_body.velocity.x) < max_speed)
            {
                r_body.drag = 0;
                r_body.AddForce(new Vector2(Input.GetAxis(gameObject.name + "_Horizontal") * move_force, 0));
                //flip to face the right direction
                if (Input.GetAxis(gameObject.name + "_Horizontal") > 0.1)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                if (Input.GetAxis(gameObject.name + "_Horizontal") < -0.1)
                {
                    transform.eulerAngles = new Vector3(0, -1, 0);
                }
            }
            else
            {
                if (onFloor == true)
                {
                    // r_body.drag = 10;
                }

            }
            if (jumpPressed != false)
            {
                if (Input.GetButtonDown(gameObject.name + "_Fire1"))
                {
                    if (numOfJumpsRemaning > 0)
                    {
                        r_body.drag = 0;
                        jump();
                    }

                }
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

    void jump()
    {
        r_body.drag = 0;
        r_body.velocity = new Vector2(0, 0);
        r_body.AddForce(new Vector2(0, 200));
        numOfJumpsRemaning--;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
=======
    void Update() {
        float h = Input.GetAxis(gameObject.name + "_Horizontal");
        if (Mathf.Abs(h) > 0.1 && Mathf.Abs(r_body.velocity.x) < max_speed) {
            r_body.AddForce(new Vector2(h * move_force, 0));
        }
        if (jumpPressed != false) {
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
        if (Input.GetButtonUp(gameObject.name + "_Fire1")) {
            jumpPressed = true;
        }
        if (Input.GetButtonDown(gameObject.name + "_Fire2")) {
            shoot();
        }
    }

    void jump() {
        Vector2 tmp = r_body.velocity;
        tmp.y = 0;
        r_body.velocity = tmp;
        r_body.AddForce(new Vector2(0, 200));
        numOfJumpsRemaning--;
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Floor")) {
>>>>>>> Player-moves
            numOfJumpsRemaning = 2;
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
    void notBlocking()
    {
        isSleeping = false;
    }

}
