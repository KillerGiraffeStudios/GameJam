using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	//the postition and hp of the object
	public Vector3 pos;
	public float xOffset, yOffset, curHP, maxHP, percentOfHP;
	public Texture aTexture;

	// Use this for initialization
	//initializes the health bar as well as the maxHP of what the object originally had
	//and its current hp as the same
	void Start () {
		aTexture = Resources.Load ("health") as Texture;
		maxHP = GetComponent<PlayerClass>().health; 
		curHP = GetComponent<PlayerClass>().health; 
		percentOfHP = maxHP / curHP;
	}

	// Update is called once per frame
	void Update () {
		//move the health bar to the object
		pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z));
		pos.y = Screen.height - pos.y;
		//check if any damage has been done, if so, reduce hp
		//curHP = GetComponent<PlayerClass>().health;  --uncomment this for hp going down
		curHP -= 1;
		percentOfHP = curHP / maxHP;
	}

	void OnGUI(){
		if (curHP > 0) {
			GUI.DrawTexture(new Rect(pos.x,pos.y, percentOfHP * Screen.width/14, Screen.height/50), aTexture, ScaleMode.StretchToFill, true, 10.0F);
		}
	}
}