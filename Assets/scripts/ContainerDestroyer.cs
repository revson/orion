using UnityEngine;
using System.Collections;

public class ContainerDestroyer : MonoBehaviour {

	public Transform destroyer, A, B, C, D;
	private Vector3 destiny;
	public float speedEnemy;

	// Use this for initialization
	void Start () {
		
		destroyer.position = A.position;
		destiny = B.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		destroyer.position = Vector3.MoveTowards (destroyer.position, destiny, speedEnemy * Time.deltaTime);
		//print (destiny);
		if(destroyer.position == destiny){
			//encotrando proxima posicao
			if (destiny == B.position) {
				destiny = C.position;
			} else if(destiny == C.position){
				destiny = D.position;
			} else if(destiny == D.position){
				destiny = B.position;
			} 

		}

	}
}
