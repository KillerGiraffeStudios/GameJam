﻿using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    int max_speed = 3;
    int move_force = 10;
    Rigidbody2D r_body;
    int numOfJumpsRemaning =2;
    bool jumpPressed = false;
    bool onFloor = false;
    // Use this for initialization
    void Start()
    {
        r_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis(gameObject.name+"_Horizontal")) > 0.1 && Mathf.Abs(r_body.velocity.x) < max_speed)
        {
            r_body.drag = 0;
            r_body.AddForce(new Vector2(Input.GetAxis(gameObject.name + "_Horizontal") * move_force, 0));
            
            if(Input.GetAxis(gameObject.name + "_Horizontal") >0.1)
            {
                transform.eulerAngles= new Vector3(0,180,0);
            }
            if (Input.GetAxis(gameObject.name + "_Horizontal") < -0.1)
            {
                transform.eulerAngles = new Vector3(0, -1, 0);
            }
        } else
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
        if(Input.GetButtonUp(gameObject.name + "_Fire1"))
        {
            jumpPressed = true;
        }
        if(Input.GetButtonDown(gameObject.name + "_Fire2"))
        {
            shoot();
        }
    }

    void jump()
    {
        r_body.drag = 0;
        r_body.velocity = new Vector2(0, 0);
        r_body.AddForce(new Vector2(0, 200));
        numOfJumpsRemaning--;
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Floor"))
        {
            numOfJumpsRemaning = 2;
            onFloor = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }

    }
    public GameObject Arrow;
    void shoot() {
        Instantiate(Arrow, transform.position, Quaternion.identity);

    }

}
