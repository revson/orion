using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour {


	public GameObject projetilPrefab;
	public GameObject firePoint;
	private bool visible;


	// Use this for initialization
	void Start () {

		StartCoroutine (shoot());
	}


	void  OnBecameVisible()
	{
		visible = true;
	}
	void  OnBecameInvisible()
	{
		visible = false;
	}



	IEnumerator shoot(){	

		yield return new WaitForSeconds (5);
		if (visible) {
			Instantiate (projetilPrefab, firePoint.transform.position, firePoint.transform.rotation);
		}
		StartCoroutine (shoot());


	}




}
