using UnityEngine;
using System.Collections;

public class ContainerHawk : MonoBehaviour {

	public Transform hawk, A, B, C, D, E, F, G, H, I;
	private Vector3 destiny;
	public float speedEnemy;

	// Use this for initialization
	void Start () {
		hawk.position = A.position;
		destiny = B.position;
	}
	
	// Update is called once per frame
	void Update () {

		hawk.position = Vector3.MoveTowards (hawk.position, destiny, speedEnemy * Time.deltaTime);
		//print (destiny);
		if(hawk.position == destiny){
			//encotrando proxima posicao
			if (destiny == B.position) {
				destiny = C.position;
			} else if(destiny == C.position){
				destiny = D.position;
			} else if(destiny == D.position){
				destiny = E.position;
			} else if(destiny == E.position){
				destiny = F.position;
			}else if(destiny == F.position){
				destiny = G.position;
			}else if(destiny == G.position){
				destiny = H.position;
			}else if(destiny == H.position){
				destiny = I.position;
			}else if(destiny == I.position){
				destiny = B.position;
			}     

		}
	
	}
}
