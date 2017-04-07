using UnityEngine;
using System.Collections;

public class ItemBall : MonoBehaviour {

	public AudioSource itemBallFX;

    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.gameObject.tag)
        {

			case "Player":				
				StartCoroutine ("finalize");
	            break;
        }

    }

	IEnumerator finalize(){
		itemBallFX.Play();
		yield return new WaitForSeconds (0.2f);
		Destroy (this.gameObject);
	}
}
