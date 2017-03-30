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
	}
	



}
