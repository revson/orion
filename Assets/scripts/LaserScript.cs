using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public  Transform startPoint;
	public  Transform endPoint;
	LineRenderer laserLine;



	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer> ();
		laserLine.SetWidth (0.5f, 0.5f);
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);
		StartCoroutine (remove());

	}
	
	// Update is called once per frame
	void Update () {
		//laserLine.SetPosition (0, startPoint.position);
		//laserLine.SetPosition (1, endPoint.position);
	}

	IEnumerator remove(){	

		yield return new WaitForSeconds (5);
		Destroy (laserLine);
		Destroy (GameObject.Find("LaserEfects"));


	}

	void laserClose(){
		
	}
}
