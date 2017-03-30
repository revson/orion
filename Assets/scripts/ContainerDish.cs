using UnityEngine;
using System.Collections;

public class ContainerDish : MonoBehaviour {

	public Transform dish, A, B, C;
	private Vector3 destiny;
	public float speedEnemy;

	// Use this for initialization
	void Start () {
	
		dish.position = A.position;
		destiny = C.position;

	}
	
	// Update is called once per frame
	void Update () {
		
		dish.position = Vector3.MoveTowards (dish.position, destiny, speedEnemy * Time.deltaTime);
		//print (destiny);
		if(dish.position == destiny){ 
			//encotrando proxima posicao
			if (destiny == C.position) {
				destiny = B.position;
			} else if(destiny == B.position){
				destiny = C.position;
			} 

		}

	}
}
