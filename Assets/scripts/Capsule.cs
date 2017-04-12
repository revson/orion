using UnityEngine;
using System.Collections;

public class Capsule : MonoBehaviour {
	public GameObject shieldBall, hpBall, explosion;
	private GameObject preFab;
		
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(0, 0, Time.deltaTime * 5f);
	}

	void OnTriggerEnter2D(Collider2D col){

		switch (col.gameObject.tag) {
		case "simpleShootPlayer":			

			Destroy (this.gameObject);
			break;
					
		}

	}

	void OnDestroy(){
		//int range = Random.Range (0, 10);
		int range =6;

		if (range > 5) {
			Instantiate (shieldBall, transform.position, transform.rotation);
		} else {
			Instantiate (hpBall, transform.position, transform.rotation);
		}

		Instantiate (explosion, transform.position, transform.rotation);
	}
}
