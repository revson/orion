using UnityEngine;
using System.Collections;

public class ConatinerStriker : MonoBehaviour {

	public Transform striker, A, B, C, D;
	private Vector3 destiny;
	public float speedEnemy;

	// Use this for initialization
	void Start () {
		striker.position = A.position;
		destiny = B.position;
	}
	
	// Update is called once per frame
	void Update () {
		striker.position = Vector3.MoveTowards (striker.position, destiny, speedEnemy * Time.deltaTime);
		//print (destiny);
		if(striker.position == destiny){
			//encotrando proxima posicao
			if (destiny == B.position) {
				destiny = C.position;
			} else if(destiny == C.position){
				destiny = D.position;
			} else if(destiny == D.position){
				destiny = C.position;
			} 

		}
	}
}
