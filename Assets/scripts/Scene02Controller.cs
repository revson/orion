using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Scene02Controller : MonoBehaviour {

	public Text textInfo;
	private bool control, finalize; // default false

	public Text theText;
	public TextAsset textFile;
	private string[] textLines;
	public GameObject walker, laura, dialBox, text2, cam, ship;
	private float duracao ;
	private AudioSource thrusterSound, ignition, backgroundSound;
	private Fade scriptFade;
	public GameObject thrusterIgnition;
	private ParticleSystem th_particle;



	// Use this for initialization
	void Start () {
		ignition = thrusterIgnition.GetComponent<AudioSource> ();
		thrusterSound = ship.GetComponent<AudioSource> ();
		backgroundSound = cam.GetComponent<AudioSource> ();
		th_particle = thrusterIgnition.GetComponent<ParticleSystem>();
		scriptFade = FindObjectOfType(typeof(Fade)) as Fade;
		StartCoroutine ("information");



	}

	// Update is called once per frame
	void Update () {

		if (control) {
			TextFadeOut ();
		}

		if(finalize){
			ship.transform.Translate (Vector2.up * Time.deltaTime * 1);
		}

	}


	public IEnumerator information(){

		yield return new WaitForSeconds (1.5f);
		//backgroundSound.Play ();
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
				laura.SetActive (true);
				break;

			case 2:
				walker.SetActive (true);
				laura.SetActive (false);
				backgroundSound.Play ();

				break;

			case 3:
				walker.SetActive (false);
				laura.SetActive (true);
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
		laura.SetActive (false);

		//yield return new WaitForSeconds (2);


		yield return new WaitForSeconds (0.30f);

		th_particle.Play ();
		ignition.Play ();

		yield return new WaitForSeconds (0.20f);
		thrusterSound.Play ();

		yield return new WaitForSeconds (1);
		finalize = true;

		yield return new WaitForSeconds (3);
		backgroundSound.volume = 0;
		scriptFade.StartCoroutine("fadeIn");

		//yield return new WaitForSeconds (2);
		//thrusterSound.volume = 0;

		yield return new WaitForSeconds (1);

		SceneManager.LoadScene ("stage01");


	}



	void TextFadeOut (){
		if (textInfo.color.a < 0) {
			control = false;
		}
		textInfo.color = new Color(textInfo.color.r, textInfo.color.g, textInfo.color.b,  textInfo.color.a - ( 0.7f * Time.deltaTime) );

	}



}
