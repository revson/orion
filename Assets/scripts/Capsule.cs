using UnityEngine;
using System.Collections;

public class Capsule : MonoBehaviour {
	public GameObject energyBall, hpBall, explosion;
	private GameObject preFab;
		
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(0, 0, Time.deltaTime * 5f);
	}

	void OnDestroy(){
		int range = Random.Range (0, 100);

		if (range > 50) {
			Instantiate (energyBall, transform.position, transform.rotation);
		} else {
			Instantiate (hpBall, transform.position, transform.rotation);
		}

		Instantiate (explosion, transform.position, transform.rotation);
	}
}
