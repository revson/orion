using UnityEngine;
using System.Collections;

public class OnTimer : MonoBehaviour {

	public float timeLife;
	private float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time >= timeLife ){
			Destroy (this.gameObject);
		}
	}
}
