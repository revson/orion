using UnityEngine;
using System.Collections;

public class WaveHunters : MonoBehaviour {

	public GameObject hunter;
	private GameObject preFab;


	// Use this for initialization
	void Start () {
		StartCoroutine (wave());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator wave(){
		Vector3 position = transform.position;
		float x = Random.Range (-12.79f, 12.79f);
		position.x = x;
		preFab = Instantiate (hunter) as GameObject;
		preFab.name = "Hunter";
		preFab.transform.position = position;

		yield return new WaitForSeconds (2f);

		StartCoroutine (wave());
	
	}
}
