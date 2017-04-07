using UnityEngine;
using System.Collections;

public class MoveOnPath : MonoBehaviour {

	public EditorPathScript PathToFollow;
	public int CurrentWaiPointID = 0;
	public float speed;
	private float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;

	Vector3 lastPosition;
	Vector3 currentPosition;

	// Use this for initialization
	void Start () {	
		//PathToFollow = GameObject.Find (pathName).GetComponent<EditorPathScript> ();
		lastPosition = transform.position;
		//print (transform.name);
	}
	
	// Update is called once per frame
	void Update () {
		//distancia do proximo ponto
		float distance = Vector3.Distance (PathToFollow.path_objs [CurrentWaiPointID].position, lastPosition);
		//print (distance);
		transform.position = Vector3.MoveTowards (lastPosition, PathToFollow.path_objs [CurrentWaiPointID].position, Time.deltaTime * speed);

		if(distance <= reachDistance){ 
			CurrentWaiPointID++;
		}

		if (CurrentWaiPointID > PathToFollow.path_objs.Count) {
			//CurrentWaiPointID = 0;
			CurrentWaiPointID = PathToFollow.path_objs.Count;
		}

	}
}
