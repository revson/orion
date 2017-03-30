using UnityEngine;
using System.Collections;

public class EnemyDestroyer : MonoBehaviour {

    public GameObject projectilePrefab, firePoint, firePoint2;
	public GameObject hpBall, shieldBall;

    public float speedShoot;

    // Use this for initialization
    void Start()
    {
		StartCoroutine(shooting());
    }

   

    public IEnumerator shooting()
    {

        yield return new WaitForSeconds(3f);

		for(int i = 0; i <= 3; i++){
			shoot();
			yield return new WaitForSeconds(0.08f);
		}       
       
        StartCoroutine(shooting());
    }

    void shoot()
    {
        GameObject tempPrefab = Instantiate(projectilePrefab, firePoint.transform.position, transform.rotation) as GameObject;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedShoot);

        GameObject tempPrefab2 = Instantiate(projectilePrefab, firePoint2.transform.position, transform.rotation) as GameObject;
        tempPrefab2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedShoot);
    }

	void OnDestroy () {
		

		//Cada Container Destroyer que for destruido, recupera o valor da variavel qtdConDes e acrescenta 1
		PlayerPrefs.SetInt ("qtdDestroyer", PlayerPrefs.GetInt ("qtdDestroyer") + 1 );

		// quando a quantidade de enimigos do tipo destroyer for 3 ele libera um premio
		if(PlayerPrefs.GetInt ("qtdDestroyer") == 3){
			PlayerPrefs.SetInt ("qtdDestroyer", 0);
			int rang = Random.Range (0, 11);
			if (rang > 5) {
				Instantiate (hpBall, new Vector3 (0, 10, 0), transform.rotation);
			} else {
				Instantiate (shieldBall, new Vector3 (0, 10, 0), transform.rotation);
			}

		}

		Destroy (transform.parent.gameObject);
	}



}

