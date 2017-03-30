using UnityEngine;
using System.Collections;

public class EnemyHunter : MonoBehaviour {
	public GameObject projectilePrefab, firePoint;
	public float speedEnemy;

	private Rigidbody2D enemyRb;


	// Use this for initialization
	void Start () {

		//inicializando a imagem do ship player
		enemyRb = GetComponent<Rigidbody2D> ();

		StartCoroutine(shooting());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		
		//move enemy
		enemyRb.velocity = new Vector2 (0, -1 * speedEnemy);

	}

	public IEnumerator shooting(){

		yield return new WaitForSeconds (1.5f);
		shoot ();
		StartCoroutine(shooting());
	}

	void shoot(){
		Instantiate (projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);

	}
}
