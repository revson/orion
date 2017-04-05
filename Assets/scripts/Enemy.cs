using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject explosion, energyBall;


	private int enemyValue;
	private float hp;
	private int score;
	private string name;

	// Use this for initialization
	void Start () {
		name = transform.name;
		hp = PlayerPrefs.GetFloat(name+"Hp");
		enemyValue = PlayerPrefs.GetInt(name+"Value");

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
			print (name);
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

		score = PlayerPrefs.GetInt ("score");
		score += enemyValue;
		PlayerPrefs.SetInt ("score", score );

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


}
