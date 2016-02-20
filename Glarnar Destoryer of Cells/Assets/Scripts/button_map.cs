using UnityEngine;
using System.Collections;

public class button_map : MonoBehaviour {
	public bool hasPressed = false;
	int first=1;
	int second=2;
	int third=3;
	int fourth=4;

	string msgPwr1;
	string msgPwr2;
	string msgPwr3;
	string msgPwr4;

	

	// Use this for initialization
	void Start () {

		resetMap ();
		
		//random button 
		first = ranNum ();
		do {
			second = ranNum ();
		} while (second == first);
		
		do {
			third = ranNum ();
		} while(third == first || third == second);
		
		fourth = 10 - first - second - third;

	}
	
	// Update is called once per frame
	void Update () {
		resetMap ();
		if (!hasPressed) {
			if (Input.GetButtonDown (name + "_Fire" +  first.ToString())) {
				SendMessage(msgPwr1);
				hasPressed = true;
			} else if (Input.GetButtonDown (name + "_Fire" + second.ToString())) {
				SendMessage(msgPwr2);
				hasPressed = true;
			} else if (Input.GetButtonDown (name + "_Fire" + third.ToString())) {
				SendMessage(msgPwr3);
				hasPressed = true;
			} else if (Input.GetButtonDown (name + "_Fire" + fourth.ToString ())) {
				SendMessage(msgPwr4);
				hasPressed = true;
			}
		}
	}


	void resetMap(){


		int good = getPlace ();
		int bad = 4 - good;


		for(int i=0;i<4;i++){
			int coin = ranNum()%2;
			if(coin==0){
				if(good>0){
					good--;
				}else{
					coin=1;
					bad--;
				}
			}else {
				if(bad>0){
					bad--;
				}else{
					coin = 1;
					good--;
				}
			}

			int someNum = ranNum()+(coin*4)-1;
			if(i==0){
				msgPwr1 = "power"+someNum.ToString();
			}
			if(i==1){
				msgPwr2 = "power"+someNum.ToString();
			}
			if(i==2){
				msgPwr3 = "power"+someNum.ToString();
			}
			if(i==3){
				msgPwr4 = "power"+someNum.ToString();
			}

		}
	}
	int ranNum(){
		return (int)(Random.Range (1f, 4.99f));
	}

	/*
	 * Super
	 * 0 increaseSpeed
	 * 1 increaseSize
	 * 2 bonusPoints
	 * 3 otherDestruct
	 * 4 decreaseSpeed
	 * 5 decreaseSize
	 * 6 minusPoints
	 * 7 selfDestruct
	 * */
	void power0(){
		gameObject.GetComponent<moveScript> ().move_force *= 2f;
	}
	void power4(){
		gameObject.GetComponent<moveScript> ().move_force /= 2f;
		//gameObject.SendMessage (
	}
	void power1(){
		transform.localScale*=2f;
	}
	void power5(){
		transform.localScale /= 2f;
	}
	void power7(){
		gameObject.SendMessage ("pDeath");
		//gameObject.GetComponent<moveScript> ().SendMessage("pDeath");
	}
	void power3(){
		//go through each player
		for (int i=1; i<5; i++) {
			if(gameObject.name!="P"+i){//if it is not current player destroy
				GameObject.Find("P"+i).GetComponent<moveScript>().SendMessage("pDeath");
			}
		}
	}
	void power2(){
		GetComponent<moveScript> ().Score += 2500;
	}
	void power6(){
		GetComponent<moveScript> ().Score -= 2000;
	}


	int getPlace(){
		int place = 1;
		for (int i=1; i<5; i++) {
			if(getScore ("P"+i)>getScore(name)){
				place++;
			}
		}
		return place;
	}

	int getScore(string player){
		return GameObject.Find (player).GetComponent<moveScript> ().Score;
	}

}
