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
		aTexture = Resources.Load ("black") as Texture;
		maxHP = 100;
		curHP = 100;
		//maxHP = GetComponent<PlayerClass>().health; 
		//curHP = GetComponent<PlayerClass>().health; 
		percentOfHP = maxHP / curHP;
	}

	// Update is called once per frame
	void Update () {
		//move the health bar to the object
		pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + xOffset, transform.position.y + yOffset,transform.position.z));
		pos.y = Screen.height - pos.y;
		//pos.x += xOffset;
		//check if any damage has been done, if so, reduce hp
		//curHP = GetComponent<PlayerClass>().health; 
		curHP -= 1;
		percentOfHP = curHP / maxHP;
	}

	void OnGUI(){
		if (curHP > 0) {
			GUI.DrawTexture(new Rect(pos.x,pos.y, percentOfHP * 100, 40), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
		}
	}
}