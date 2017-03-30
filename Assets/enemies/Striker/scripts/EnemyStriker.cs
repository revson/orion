using UnityEngine;
using System.Collections;

public class EnemyStriker : MonoBehaviour {

	public GameObject projectilePrefab;
	public GameObject firePoint;
	public float speedShoot;

	// Use this for initialization
	void Start () {
		StartCoroutine(shooting());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator shooting(){

		yield return new WaitForSeconds (3f);

		for (int i = 0; i <= 3; i++) {			
			shoot ();
			yield return new WaitForSeconds (0.15f);
		}

		StartCoroutine(shooting());
	}

	void shoot(){
		
		Instantiate (projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);

	}

}
