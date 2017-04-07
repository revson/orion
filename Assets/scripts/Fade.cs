using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public SpriteRenderer fadeTexture;
	public float fadeSpeed;

	// Use this for initialization
	void Start () {
		fadeTexture = GetComponent<SpriteRenderer> ();
		//StartCoroutine ("fadeIn");
		StartCoroutine ("fadeOut");

	}

	public void fadeEffect(string efeito){

		StartCoroutine (efeito);
	}

	IEnumerator fadeOut(){ //diminuir a cor, desaparece
		Color cor = new Color(0,0,0,1); // criou a cor preta
		fadeTexture.material.color = cor;

		for(float f = 1; f > 0; f -= fadeSpeed){
			cor.a = f;
			fadeTexture.material.color = cor;
			yield return new WaitForEndOfFrame ();
		}

		//yield return new WaitForSeconds (1);
		//StartCoroutine ("fadeOut");

	}

	IEnumerator fadeIn(){ //aumenta a cor, aparece
		Color cor = new Color(0,0,0,0); // criou a cor preta
		fadeTexture.material.color = cor;

		for(float f = 0; f < 1; f += fadeSpeed){
			cor.a = f;
			fadeTexture.material.color = cor;
			yield return new WaitForEndOfFrame ();
		}

	}


}
