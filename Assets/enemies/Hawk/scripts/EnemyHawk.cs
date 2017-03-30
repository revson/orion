using UnityEngine;
using System.Collections;

public class EnemyHawk : MonoBehaviour {

	public GameObject projectilePrefab;
	public float speedShoot;
	public GameObject firePoint, firePoint2;

	// Use this for initialization
	void Start () {
		StartCoroutine(shooting());
		PlayerPrefs.SetInt ("qtdHawk", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator shooting(){

		yield return new WaitForSeconds (3f);
		for (int i = 0; i <= 3; i++) {
			shoot ();
			yield return new WaitForSeconds (0.10f);
		}

		StartCoroutine(shooting());
	}

	void shoot(){
		Instantiate (projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
		Instantiate (projectilePrefab, firePoint2.transform.position, firePoint2.transform.rotation);
	}


}
