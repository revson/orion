using UnityEngine;
using System.Collections;

public class ContainerHiperion : MonoBehaviour {

    public Transform hiperion, A, B, C;
    private Vector3 destiny;
    public float speedEnemy;

	// Use this for initialization
	void Start () {
        hiperion.position = A.position;
        destiny = C.position;
	}
	
	// Update is called once per frame
	void Update () {

        hiperion.position = Vector3.MoveTowards(hiperion.position, destiny, speedEnemy * Time.deltaTime);
        //print (destiny);
        if (hiperion.position == destiny)
        {
            //encotrando proxima posicao
            if (destiny == C.position)
            {
                destiny = B.position;
            }
            else if (destiny == B.position)
            {
                destiny = C.position;
            }

        }

    }
}
