using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	private Transform target;
	public float rotatespeed;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("ShipPlayer").transform;
	}
			
	// Update is called once per frame
	void Update () { 		

		if (target.transform.name != null) {
			//rotation
			var dir = transform.position - target.position;
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg + 90;
			var newRotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * rotatespeed);
		}
		
	}

}
