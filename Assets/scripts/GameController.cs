using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	  

    // Use this for initialization
    void Start () {
		PlayerPrefs.SetInt ("score", 0);
		PlayerPrefs.SetInt ("qtdDestroyer", 0);


	}

	// Update is called once per frame
	void Update () {
		
		if(PlayerPrefs.GetString("activePlayer") == "no"){
			StartCoroutine (gameOver());
		}

	}

	public IEnumerator gameOver(){
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("gameOver");
	}





	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void UnpauseGame()
	{
		Time.timeScale = 1;
	}
}
