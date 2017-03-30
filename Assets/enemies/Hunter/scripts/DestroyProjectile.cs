using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 8);
	}	

}
