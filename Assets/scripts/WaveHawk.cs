using UnityEngine;
using System.Collections;

public class WaveHawk : MonoBehaviour {

	public GameObject containerHawk;

	// Use this for initialization
	void Start () {
		StartCoroutine (wave());
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator wave(){

		for (int i = 1; i<=5; i++){
			Instantiate(containerHawk, transform.position, transform.rotation);
			yield return new WaitForSeconds (1f);
		}

		//StartCoroutine (wave());
	}

}
