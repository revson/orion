using UnityEngine;
using System.Collections;

public class MoveShoot : MonoBehaviour {
	
	public float speedShoot ;
	
	// Update is called once per frame
	void Update () {		
		transform.Translate(Vector2.up * Time.deltaTime * speedShoot);
	}


}
