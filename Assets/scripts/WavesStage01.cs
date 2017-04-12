using UnityEngine;
using System.Collections;

public class WavesStage01 : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject item;

	// Use this for initialization
	void Start () {
		StartCoroutine (itens());
		StartCoroutine (waves());
		//StartCoroutine (waveStricker());
		//waveDishAtack();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator waves(){

		//======= 1ª wave 3 min. ===========
		yield return new WaitForSeconds (7f);
		StartCoroutine (waveHunter());

		yield return new WaitForSeconds (14f);
		StartCoroutine (waveTracker());
		// ====== end wave ==================

		// ====== first boss ================
		yield return new WaitForSeconds (180f);
		waveDishAtack ();
		//===================================


	}


	public IEnumerator waveHunter(){
		//Hunter enemy 0
		for (int i = 0; i <= 85; i++) {
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

		for(int i = 0; i<=3; i++){

			for(int j = 0; j<=4; j++){
				GameObject preFab;
				preFab = Instantiate (enemies [1]) as GameObject;
				preFab.name = "Tracker";
				yield return new WaitForSeconds (0.80f);
			}
			yield return new WaitForSeconds (20);
		}

		//begin next wave
		//yield return new WaitForSeconds (10f);
		StartCoroutine (waveHawk());


	}

	public IEnumerator waveHawk(){
		//enemy 2 Hawk

		for(int i = 0; i<=3; i++){
			GameObject preFab;
			preFab = Instantiate (enemies [2]) as GameObject;
			preFab.name = "Hawk";
			yield return new WaitForSeconds (2f);
		}

		//begin next wave
		yield return new WaitForSeconds (20f);
		StartCoroutine (waveStricker());

	}

	public IEnumerator waveStricker(){
		//enemy 3 Stricker

		for(int i = 0; i<=3; i++){
			GameObject preFab;
			preFab = Instantiate (enemies [3]) as GameObject;
			preFab.name = "Striker";
			yield return new WaitForSeconds (3f);
		}

	}


	void waveDishAtack(){
		//enemy 4 DishAtack Boss
		GameObject preFab;
		preFab = Instantiate (enemies [4]) as GameObject;
		preFab.name = "DishAtack";


	}

	public IEnumerator itens(){
		//
		yield return new WaitForSeconds (45f);
		Instantiate (item);	
		StartCoroutine (itens());

	}
}
