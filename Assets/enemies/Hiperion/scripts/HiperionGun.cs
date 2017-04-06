using UnityEngine;
using System.Collections;

public class HiperionGun : MonoBehaviour {

	private bool visible;

	public GameObject explosion, energyBall, projectilePrefab, firePoint;

	private int enemyValue;
	private float hp;
	private int score;
	//private string name;


	// Use this for initialization
	void Start () {

		//name = "Hyperion";
		hp = 20;
		//enemyValue = PlayerPrefs.GetInt(name+"Value");
		StartCoroutine(shooting());

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){

		switch (col.gameObject.tag){
		case "Player":			
			death (true);
			break;

		case "shieldBall":
			Destroy (this.gameObject);
			break;


		}

	}

	void OnTriggerEnter2D(Collider2D col){

		switch (col.gameObject.tag) {
		case "simpleShootPlayer":
			//simple shoot = 1
			shotHit (1);
			Destroy (col.gameObject);
			break;

		case "simpleLaser":
			//Laser Force = 10
			shotHit (5);

			break;
		}

	}

	void shotHit(int hit){		
		hp -= hit;

		if(hp <= 0 ){
			hp = 0;
			//finalize enemy, manda false para nao instanciar a energia.
			death(false);

		}

	}

	void death (bool col){
		// add point

		//score = PlayerPrefs.GetInt ("score");
		//score += enemyValue;
		//PlayerPrefs.SetInt ("score", score );

		hp = PlayerPrefs.GetFloat("HyperionHp");
		hp -= 20;
		PlayerPrefs.SetFloat("HyperionHp", hp);
		//start explosion
		Instantiate(explosion, transform.position, transform.rotation);

		// se a morte não foi por colisao, libera energia
		if (!col) {
			//start energy
			Instantiate (energyBall, transform.position, transform.rotation);
		}


		//destroy
		Destroy(this.gameObject);

	}

	public IEnumerator shooting(){

		yield return new WaitForSeconds (3f);
		if (visible) {
			shoot ();
		}

		StartCoroutine(shooting());
	}

	void shoot(){
		Instantiate (projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
	}

	void  OnBecameVisible()
	{
		visible = true;
	}
	void  OnBecameInvisible()
	{
		visible = false;
	}


}
