using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text score, record;
	private string stage;
	// Use this for initialization
	void Start () {
		score.text = PlayerPrefs.GetInt("score").ToString();
        record.text = PlayerPrefs.GetInt("record").ToString();
		stage =  "stage0" + PlayerPrefs.GetInt("stage").ToString();
    }
	
	public void goToMenu(){
		SceneManager.LoadScene ("menuPrincipal");
	}

	public void continueGame(){
		SceneManager.LoadScene (stage);
	}
}
