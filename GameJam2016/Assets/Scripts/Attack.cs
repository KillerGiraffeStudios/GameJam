using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;

    private Animator anim;




    public GameObject Block;

	// Use this for initialization
	void Awake () {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        //Block
        if(Input.GetButtonDown(gameObject.name+"_Fire3"))
        {
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            Quaternion playerRotation = transform.rotation;
            float spawnDistance = 45;
            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

            Instantiate(Block, spawnPos, playerRotation);
        }

        // Attack Animations
        if(Input.GetButtonDown(gameObject.name+"_Fire4")&& !attacking) 
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if(attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
	}


}
