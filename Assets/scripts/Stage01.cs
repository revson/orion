using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Stage01 : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		
		PlayerPrefs.SetInt("stage", 1);

		//Setting enemies

		//------------------------------------------
		//Hunter
		//------------------------------------------
		PlayerPrefs.SetFloat("HunterHp", 1);
		PlayerPrefs.SetInt("HunterHit", 1);
		PlayerPrefs.SetInt("HunterValue", 10);

		//------------------------------------------
		//Tracker
		//------------------------------------------
		PlayerPrefs.SetFloat("TrackerHp", 2);
		PlayerPrefs.SetInt("TrackerHit", 2);
		PlayerPrefs.SetInt("TrackerValue", 20);

		//------------------------------------------
		//Hawk
		//------------------------------------------
		PlayerPrefs.SetFloat("HawkHp", 3);
		PlayerPrefs.SetInt("HawkHit", 2);
		PlayerPrefs.SetInt("HawkValue", 30);

		//------------------------------------------
		//Stricker
		//------------------------------------------
		PlayerPrefs.SetFloat("StrikerHp", 4);
		PlayerPrefs.SetInt("StrikerHit", 2);
		PlayerPrefs.SetInt("StrikerValue", 40);
	}
	



}
