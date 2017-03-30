using UnityEngine;
using System.Collections;

public class MoveBalls : MonoBehaviour {
	    
	private GameObject player;
	public float speed;
	void Start() {
		player = GameObject.Find ("ShipPlayer");
	}
	void Update() {
        if (PlayerPrefs.GetString("activePlayer") == "yes")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
	}
}
