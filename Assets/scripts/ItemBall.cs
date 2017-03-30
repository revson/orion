using UnityEngine;
using System.Collections;

public class ItemBall : MonoBehaviour {

	public AudioSource itemBallFX;

    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.gameObject.tag)
        {

            case "Player":

                itemBallFX.Play();
                Destroy(this.gameObject, 0.2f);
                break;
        }

    }
}
