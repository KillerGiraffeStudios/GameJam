﻿using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    int max_speed = 5;
    int move_force = 5;
    Rigidbody2D r_body;
    int numOfJumpsRemaning =2;
    bool jumpPressed = false;
    // Use this for initialization
    void Start()
    {
        r_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("P1_Horizontal")) > 0.1 && Mathf.Abs(r_body.velocity.x) < max_speed)
        {
            r_body.AddForce(new Vector2(Input.GetAxis("P1_Horizontal") * move_force, 0));
        }
        if (jumpPressed != false)
        {
            if (Input.GetButtonDown("P1_Fire1"))
            {
                if (numOfJumpsRemaning > 0)
                {
                    jump();
                }

            }
        }
        if(Input.GetButtonUp("P1_Fire1"))
        {
            jumpPressed = true;
        }
        if(Input.GetButtonDown("P1_Fire2"))
        {
            shoot();
        }
    }

    void jump()
    {
        r_body.velocity = new Vector2(0, 0);
        r_body.AddForce(new Vector2(0, 200));
        numOfJumpsRemaning--;
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Floor"))
        {
            numOfJumpsRemaning = 2;
        }
    }
    public GameObject Arrow;
    void shoot() {
        Instantiate(Arrow, transform.position, Quaternion.identity);

    }

}
