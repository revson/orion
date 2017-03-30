using UnityEngine;
using System.Collections;

public class WaveDestroyer : MonoBehaviour {

	public GameObject containerDestryer;

	// Use this for initialization
	void Start () {
		StartCoroutine (wave());
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator wave(){
		yield return new WaitForSeconds (50f);
        if (PlayerPrefs.GetString("activePlayer") == "yes") {
            Instantiate(containerDestryer, new Vector3(0.09f, 0, 0), transform.rotation);
            Instantiate(containerDestryer, new Vector3(7.19f, 0, 0), transform.rotation);
            Instantiate(containerDestryer, new Vector3(-7.1f, 0, 0), transform.rotation);
        }
            
		StartCoroutine (wave());
	}
}
