using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Scene01Controller : MonoBehaviour {
	
	public Text textInfo;
	private bool control, finalize; // default false

	public Text theText;
	public TextAsset textFile;
	private string[] textLines;
	public GameObject walker, thane, dialBox, text2, cam, centroComando;
	private float duracao ;
	private AudioSource sound, backgroundSound;
	private Fade scriptFade;
	//chaturbate.com



	// Use this for initialization
	void Start () {
		sound = cam.GetComponent<AudioSource> ();
		backgroundSound = centroComando.GetComponent<AudioSource> ();
		StartCoroutine ("information");


	}
	
	// Update is called once per frame
	void Update () {
		
		if (control) {
			TextFadeOut ();
		}

		if(finalize){
			zoomOut ();
		}

	}


	public IEnumerator information(){

		yield return new WaitForSeconds (1.5f);
		backgroundSound.Play ();
		string letters = "123 testando tudo isso ção.";
		int count = 0;
		textInfo.text = "";

		yield return new WaitForSeconds (2);
		while(count <= letters.Length - 1){
			textInfo.text += letters[count];
			count += 1;
			yield return new WaitForSeconds (0.07f);
		}

		yield return new WaitForSeconds (2);
		control = true;

		yield return new WaitForSeconds (2);
		StartCoroutine ("dialog");

	}

	public IEnumerator dialog(){
		int currentLine = 0;

		if(textFile != null){
			textLines = (textFile.text.Split ('\n'));
		}


		while(currentLine <= textLines.Length - 1){			 

			int count = 0;

			switch (currentLine) {
			case 0:
				dialBox.SetActive (true);
				text2.SetActive (true);
				walker.SetActive (true);
				break;

			case 1:
				walker.SetActive (false);
				thane.SetActive (true);
				break;

			case 2:
				walker.SetActive (true);
				thane.SetActive (false);
				break;

			case 3:
				walker.SetActive (false);
				thane.SetActive (true);
				break;

			default:

				break;
			}

			while(count <= textLines [currentLine].Length - 1){								
				theText.text += textLines [currentLine][count];
				count += 1;
				yield return new WaitForSeconds (0.10f);
			}

			yield return new WaitForSeconds (1);
			theText.text = "";
			currentLine += 1;

		}

		dialBox.SetActive (false);
		text2.SetActive (false);
		walker.SetActive (false);
		thane.SetActive (false);

		yield return new WaitForSeconds (2);
		finalize = true;

		yield return new WaitForSeconds (0.30f);
		sound.Play ();

		yield return new WaitForSeconds (11.3f);
		backgroundSound.Stop ();
		Color cor = new Color(0,0,0,1); // criou a cor preta
		scriptFade.fadeTexture.material.color = cor;

		yield return new WaitForSeconds (3);

		SceneManager.LoadScene ("scene02");

	
	}



	void TextFadeOut (){
		if (textInfo.color.a < 0) {
			control = false;
		}
		textInfo.color = new Color(textInfo.color.r, textInfo.color.g, textInfo.color.b,  textInfo.color.a - ( 0.7f * Time.deltaTime) );

	}

	void zoomOut(){
		duracao =  0.3f * Time.deltaTime;
		cam.GetComponent<Camera> ().orthographicSize =  Mathf.Lerp(cam.GetComponent<Camera> ().orthographicSize, 6, duracao);
	}

}
