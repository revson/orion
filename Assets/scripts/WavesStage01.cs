using UnityEngine;
using System.Collections;

public class WavesStage01 : MonoBehaviour {

	public GameObject[] enemies;
	//public GameObject[] holders;

	// Use this for initialization
	void Start () {
		
		StartCoroutine (waves());
		//StartCoroutine (waveHawk());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator waves(){

		yield return new WaitForSeconds (7f);
		StartCoroutine (waveHunter());

		yield return new WaitForSeconds (14f);
		StartCoroutine (waveTracker());

		yield return new WaitForSeconds (60f);
		StartCoroutine (waveTracker());

	}


	public IEnumerator waveHunter(){
		//Hunter enemy 0
		for (int i = 0; i <= 50; i++) {
			Vector3 position = transform.position;
			GameObject preFab;
			float x = Random.Range (-12.79f, 12.79f);
			position.x = x;
			position.y = 9;
			preFab = Instantiate (enemies [0]) as GameObject;
			preFab.name = "Hunter";
			preFab.transform.position = position;

			yield return new WaitForSeconds (2f);
		}

	}

	public IEnumerator waveTracker(){
		//enemy 1 tracker

		for(int i = 0; i<=2; i++){

			for(int j = 0; j<=4; j++){
				GameObject preFab;
				preFab = Instantiate (enemies [1]) as GameObject;
				preFab.name = "Tracker";
				yield return new WaitForSeconds (0.80f);
			}
			yield return new WaitForSeconds (30);
		}


	}

	public IEnumerator waveHawk(){
		//enemy 2 Hawk

		for(int j = 0; j<=6; j++){
			GameObject preFab;
			preFab = Instantiate (enemies [2]) as GameObject;
			preFab.name = "Hawk";
			yield return new WaitForSeconds (2f);
		}

	}

}
