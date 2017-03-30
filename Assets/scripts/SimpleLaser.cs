using UnityEngine;
using System.Collections;

public class SimpleLaser : MonoBehaviour {

	public LineRenderer LrLaser;
	public bool activeLaser;
	public float width;


	// Use this for initialization
	void Start () {
		activeLaser = false;

		LrLaser = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	




		//LrLaser.enabled = false;
		//activeLaser = true;


	}

	void FixedUpdate(){



	}


	public IEnumerator finalizeLaser(){
		
		yield return new WaitForSeconds (5);
		width = 0.50f;
		LrLaser.SetWidth (width, width);
		yield return new WaitForSeconds (0.40f);
		width = 0;
		LrLaser.SetWidth (1, 1);
		LrLaser.enabled = false;
		LrLaser.GetComponentInChildren<BoxCollider2D> ().enabled = false;
		width = 1;
		activeLaser = false;


	}

}
