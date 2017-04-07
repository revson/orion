using UnityEngine;
using System.Collections;

public class EnemyHyperion : MonoBehaviour {

	private int enemyValue;
	private int score;
	public GameObject[] explosionAnimate;
	// Use this for initialization
	void Start () {
		
		enemyValue = PlayerPrefs.GetInt(name+"Value");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerPrefs.GetFloat ("HyperionHp") == 0) {
			finalize();
		}


	}

	void finalize(){
		score = PlayerPrefs.GetInt ("score");
		score += enemyValue;
		PlayerPrefs.SetInt ("score", score);
		//hp recebe 1 para sair do loop
		PlayerPrefs.SetFloat ("HyperionHp", 1);

		for (int i = 0; i <= 12; i++) {
			explosionAnimate[i].SetActive(true);
		}
	}
}
