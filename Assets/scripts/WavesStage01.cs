using UnityEngine;
using System.Collections;

public class WavesStage01 : MonoBehaviour {

	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator waves(){
	
	}

	//Hunter enemy 0
	public IEnumerator waveHunter(){
		for (int i = 0; i <= 99; i++) {
			Vector3 position = transform.position;
			GameObject preFab;
			float x = Random.Range (-12.79f, 12.79f);
			position.x = x;
			preFab = Instantiate (enemies [0]) as GameObject;
			preFab.name = "Hunter";
			preFab.transform.position = position;

			yield return new WaitForSeconds (2f);
		}

	}
}
