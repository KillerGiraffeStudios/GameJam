using UnityEngine;
using System.Collections;

public class gun_rotation : MonoBehaviour {
	public float radian;
	public float cutoffRange = 0f;
	public float pxxx;
	public float pyyy;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Transform something = transform;
		float x_dir = Input.GetAxis ("P1_RX");
		float y_dir = Input.GetAxis ("P1_RY");
		pxxx = x_dir;
		pyyy = y_dir;
		//Vector3 dir = new Vector3(0,0);
		/*if (x_dir > -cutoffRange && x_dir < cutoffRange) {
			x_dir = 0;
		}
		if (y_dir > -cutoffRange && y_dir < cutoffRange) {
			y_dir = 0;
		}*/
		if (x_dir != 0 && y_dir != 0) {
			//radian = Mathf.Rad2Deg* (Mathf.Atan2 (y_dir, x_dir));
			transform.eulerAngles = new Vector3 (x_dir, y_dir, radian);
			//dir.x = x_dir;
			//dir.y = y_dir;
			//dir.Normalize();

		}

			//transform.eulerAngles = dir;
	}
}
