using UnityEngine;
using System.Collections;

public class WaveTracker : MonoBehaviour {



	public GameObject tracker;
   

	// Use this for initialization
	void Start () {
		StartCoroutine (wave());
	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator wave(){ 

		for(int i = 0; i<=5; i++){
			yield return new WaitForSeconds (0.3f);
			Instantiate (tracker);

		}

		//inicia a wave somente se o player estiver ativo, fix para o problema de erro 
		//com a perda de referencia do objeto quando a wave é iniciada na hora do game over.
		if(PlayerPrefs.GetString("activePlayer") == "yes"){ 
			wave ();
		}

		StartCoroutine (wave());
	}





}
