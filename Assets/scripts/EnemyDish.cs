using UnityEngine;
using System.Collections;

public class EnemyDish : MonoBehaviour {

    public GameObject projectilePrefab;
    public float speedShoot;
    public GameObject[] firePoint;
    
    // Use this for initialization
    void Start () {
        StartCoroutine(shooting());
    }
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 4f));
	}

    public IEnumerator shooting()
    {
		yield return new WaitForSeconds(2f);
        for (int i = 0; i < 5; i++)
        {
            shoot();
            yield return new WaitForSeconds(0.10f);
        }
        
        StartCoroutine(shooting());
    }

    void shoot()
    {
        for (int i = 0; i<=7; i++) {
            
            Instantiate(projectilePrefab, firePoint[i].transform.position, firePoint[i].transform.rotation);
        }
        
        
    }

    
}
