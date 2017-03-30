using UnityEngine;
using System.Collections;

public class PlasmaGun : MonoBehaviour {

	public GameObject projectilePrefab;
	private bool visible;


	// Use this for initialization
	void Start () {
		StartCoroutine(shooting());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator shooting(){

		yield return new WaitForSeconds (2f);
		if (visible) {
			shoot ();
		}

		StartCoroutine(shooting());
	}

	void shoot(){
		Instantiate (projectilePrefab, transform.position, transform.rotation) ;
	}

	void  OnBecameVisible()
	{
		visible = true;
	}
	void  OnBecameInvisible()
	{
		visible = false;
	}

}
