using UnityEngine;
using System.Collections;

public class Capsule : MonoBehaviour {
	public GameObject energyBall, hpBall, explosion;
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
		int range = Random.Range (0, 10);

		if (range > 5) {
			Instantiate (energyBall, transform.position, transform.rotation);
		} else {
			Instantiate (hpBall, transform.position, transform.rotation);
		}

		Instantiate (explosion, transform.position, transform.rotation);
	}
}
