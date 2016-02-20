using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    private bool attacking = false;
    private bool blocking = true;
    private float blockingTimer = 0f;
    private float blockCd = 2f;

    private float attackTimer = 0f;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;
    public Collider2D blockTrigger;

    private Animator anim;

    public GameObject Block;

	// Use this for initialization
	void Awake () {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if(blockingTimer >0)
        {
            blockingTimer -= Time.deltaTime;
        }
    }

    void block()
    {
        if(!blocking)
        {
            blocking = true;
            attackTimer = blockCd;

            blockTrigger.enabled = true;
        }

        if(blocking)
        {
            if(blockingTimer>0)
            {
                gameObject.GetComponent<PlayerClass>().SendMessage("sleep", 0.3f);
                gameObject.GetComponent<MoveScript>().SendMessage("sleep", 0.3f);
                Invoke("finishBlock", 0.3f);
            }
        }
    }

    void basicAttack()
    {
        if (!attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                gameObject.GetComponent<PlayerClass>().SendMessage("sleep", 0.3f);
                gameObject.GetComponent<MoveScript>().SendMessage("sleep", 0.3f);
                Invoke("finishAttack", 0.3f);
            }
        }
    }

    void finishAttack()
    {
        attacking = false;
        attackTrigger.enabled = false;
    }

    void finishBlock() {
        blocking = false;
        blockTrigger.enabled = false;
    }

    void destroySelf()
    {
        Destroy(gameObject);
    }


}
