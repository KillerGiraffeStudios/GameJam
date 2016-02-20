using UnityEngine;
using System.Collections;

public class summoning : MonoBehaviour {

	public GameObject Speed;
	public GameObject GrowthB;
    public GameObject Points;
	// Use this for initialization
	void Start () {
		for(int i = 5;i<70;i=i+5) {
            int x = Random.Range (0,10);
			if(x>6) {
				Invoke("SpawnSize",(i));
			} else if(x>3)  {
				Invoke("SpawnSpeed",(i));
            }
            else
            {
                Invoke("SpawnPoints", (i));
            }
                
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnSpeed() {
		Vector3 rand = new Vector3(Random.Range(-13f,13f),Random.Range(-6.4f,6.4f),0 );
		Instantiate(Speed,rand,Quaternion.identity);

	}

	void SpawnSize() {
		Vector3 rand = new Vector3(Random.Range(-13f,13f),Random.Range(-6.4f,6.4f),0 );
		Instantiate(GrowthB,rand,Quaternion.identity);
		
	}

    void SpawnPoints()
    {
        Vector3 rand = new Vector3(Random.Range(-13f, 13f), Random.Range(-6.4f, 6.4f), 0);
        Instantiate(Points, rand, Quaternion.identity);

    }

}
