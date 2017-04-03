using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShipPlayer : MonoBehaviour {

	private SimpleLaser simpleLaser;

	public Sprite[] spritePlayer;
	public GameObject projectilePrefab, explosion;
	public Transform firePoint;
	public float shootForce, speedShip, hpMax, hp, percentageHp;
	public float energy, shield;



	private SpriteRenderer spriteRender;
	private Rigidbody2D ShipRb;
	private Transform redBar, blueBar, yellowBar;

	private Vector3 vector3;
	public AudioSource energyBallFX;
	private AudioSource hitFX;

	private Transform top, left, right, bottom;

	public Text txtScore;


	// Use this for initialization
	void Start () {
		
		energy = 0;

        PlayerPrefs.SetString("activePlayer", "yes");

        simpleLaser = FindObjectOfType(typeof(SimpleLaser)) as SimpleLaser;

		redBar = GameObject.Find ("redBar").transform;
		blueBar = GameObject.Find ("blueBar").transform;
		yellowBar = GameObject.Find ("yellowBar").transform;


		top = GameObject.Find ("Top").transform;
		left = GameObject.Find ("Left").transform;
		right = GameObject.Find ("Right").transform;
		bottom = GameObject.Find ("Bottom").transform;

		//inicializando a imagem do ship player
		spriteRender = GetComponent<SpriteRenderer>();
		spriteRender.sprite = spritePlayer[PlayerPrefs.GetInt("stage")-1];///arrumar
		ShipRb = GetComponent<Rigidbody2D> ();
		hitFX = GetComponent<AudioSource> ();

		hp = hpMax;
		percentageHp = hp / hpMax;
		vector3 = redBar.localScale;
		vector3.x = percentageHp;
		redBar.localScale = vector3;



	}

	//1280 X 720

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//move
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		ShipRb.velocity = new Vector2 (moveX * speedShip, moveY * speedShip);

		// definindo limites de tela
		if (transform.position.x < left.position.x) {
			
			transform.position = new Vector3 (left.position.x, transform.position.y, transform.position.z);

		}else if (transform.position.x > right.position.x) {
			
			transform.position = new Vector3 (right.position.x, transform.position.y, transform.position.z);

		}else if (transform.position.y > top.position.y) {

			transform.position = new Vector3 (transform.position.x, top.position.y, transform.position.z);

		}else if (transform.position.y < bottom.position.y) {

			transform.position = new Vector3 (transform.position.x, bottom.position.y, transform.position.z);

		}



		if(Input.GetButtonDown("Fire1")){
			shoot ();
			//Time.timeScale = 0;// pause para testar

		}

		if(Input.GetButtonDown("Fire2") && blueBar.localScale.x == 1){

			specialWeapon ();

		}

		txtScore.text = "score: "+PlayerPrefs.GetInt ("score").ToString();

	}



	void shoot(){
		Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);


	}



	void OnTriggerEnter2D(Collider2D col){

		switch (col.gameObject.tag) {
	    case "projectileHunter":

			shotHit (PlayerPrefs.GetInt("HunterHit")); 
		    Destroy (col.gameObject);
		    break;

		case "projectileTracker":

			shotHit (PlayerPrefs.GetInt("TrackerHit"));
			Destroy (col.gameObject);
			break;

		case "projectileHawk":

			shotHit (PlayerPrefs.GetInt("HawkHit"));
			Destroy (col.gameObject);
			break;

		case "projectileStriker":

			shotHit (PlayerPrefs.GetInt("StrikerHit"));
			Destroy (col.gameObject);
			break;

		case "ProjectileDestroyer":
			shotHit (PlayerPrefs.GetInt("DestroyerHit"));
			Destroy (col.gameObject);
			break;

		case "ProjectileDishAtack":
			shotHit (PlayerPrefs.GetInt("DishAtackHit"));
			Destroy (col.gameObject);
			break;

		case "ProjectileHyperion":
			shotHit (PlayerPrefs.GetInt("HyperionHit"));
			Destroy (col.gameObject);
			break;

		case "energyBall":			

		    energy += 0.05f;
		    if (energy >= 1f) {
			    energy = 1f;
		    }
		
		    vector3 = blueBar.localScale;
		    vector3.x = energy;
		    blueBar.localScale = vector3;
				
		    break;

		case "hpBall":

			vector3 = redBar.localScale;
			vector3.x = 1;
			redBar.localScale = vector3;

			break;

		case "shieldBall":
			vector3 = yellowBar.localScale;
			vector3.x = 1;
			yellowBar.localScale = vector3;
			shield = 1;

            break;

		
		}

	} 

	void OnCollisionEnter2D(Collision2D col){

		switch (col.gameObject.tag){
		case "enemy":
			if (shield == 0) {
				finalize ();
			} else {
				shield = 0;
				vector3 = yellowBar.localScale;
				vector3.x = shield;
				yellowBar.localScale = vector3;
			}

			break;
		}

	}

	//pega o objto particula
	void OnParticleCollision(GameObject go) {
		//hit = 5;
		shotHit(5);
		Destroy (go);

	}


    //quando leva um tiro
    void shotHit(int hit){
		//se campo de força desligado.

		if (shield == 0) {

			hp -= hit;
			if (hp <= 0) {
				hp = 0;
				//finaliza o jogo
				finalize();
				
			}

			percentageHp = hp / hpMax;
			vector3 = redBar.localScale;
			vector3.x = percentageHp;
			redBar.localScale = vector3;
			if (PlayerPrefs.GetString ("activePlayer") == "yes") {
				hitFX.Play ();
			}

		
		} else {
            //shield perde 0.05 a cada hit
            shield -= 0.05f;
            if (shield < 0) {
                shield = 0;
            }
			vector3 = yellowBar.localScale;
			vector3.x = shield;
			yellowBar.localScale = vector3;

		}



	}

	void specialWeapon(){

		if (PlayerPrefs.GetInt("stage") == 1) {

			vector3 = blueBar.localScale;
			vector3.x = 0;
			blueBar.localScale = vector3;
			simpleLaser.LrLaser.enabled = true;
			simpleLaser.LrLaser.GetComponentInChildren<BoxCollider2D> ().enabled = true;
			simpleLaser.LrLaser.GetComponent<AudioSource> ().Play();
			StartCoroutine (simpleLaser.finalizeLaser ());
			simpleLaser.activeLaser = true;
			energy = 0;

		}

	}

	void finalize(){
		
		Instantiate (explosion, transform.position, transform.rotation);

		redBar.localScale = new Vector3 (0, 0, 0);

		PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") );

		if(PlayerPrefs.GetInt ("score") > PlayerPrefs.GetInt("record")){
			PlayerPrefs.SetInt ("record", PlayerPrefs.GetInt ("score"));
		}

        PlayerPrefs.SetString("activePlayer", "no");
        gameObject.SetActive (false);

	}

}
