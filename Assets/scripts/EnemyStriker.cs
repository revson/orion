using UnityEngine;
using System.Collections;

public class EnemyStriker : MonoBehaviour {

	public GameObject projectilePrefab;
	public GameObject firePoint;
	public float speedShoot;

	// Use this for initialization
	void Start () {
		StartCoroutine(shooting());
		PlayerPrefs.SetInt ("qtdStriker", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator shooting(){

		yield return new WaitForSeconds (3f);

		for (int i = 0; i <= 4; i++) {			
			shoot ();
			yield return new WaitForSeconds (0.15f);
		}

		StartCoroutine(shooting());
	}

	void shoot(){
		
		Instantiate (projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);

	}

	void OnDestroy () {
		
		PlayerPrefs.SetInt ("qtdStriker", PlayerPrefs.GetInt ("qtdStriker") + 1 );

		Destroy (transform.parent.gameObject);
		if(PlayerPrefs.GetInt ("qtdStriker") == 2){
			//desativa o container
			transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
		}
	}
}
