using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject cameraObject;
	//	public GameObject playerObject; // use GameManager pls

	public float xSpeed,ySpeed,zSpeed, xDistance,yDistance,zDistance;

	//	public bool onBoundary;
	public Vector3 minCameraPos,maxCameraPos;


	public float smoothTimerX,smoothTimerY,smoothTimerZ;

	Vector3 offset;
	Vector3 rotate;

	// Use this for initialization
	void Start () 
	{
		cameraObject = GameObject.FindGameObjectWithTag ("Player");

		offset = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		float posX = Mathf.SmoothDamp (transform.position.x,cameraObject.transform.position.x + offset.x, ref xSpeed,smoothTimerX);
		float posY = Mathf.SmoothDamp (transform.position.y,cameraObject.transform.position.y + offset.y, ref ySpeed,smoothTimerY);
		float posZ = Mathf.SmoothDamp (transform.position.z,cameraObject.transform.position.z + offset.z, ref zSpeed,smoothTimerZ);

		transform.position = new Vector3 (posX,posY,posZ);
		//transform.position = cameraObject.transform.position;

		//		offset = transform.position - cameraObject.transform.position;
		//		transform.LookAt(GameManager.Instance.playerObject.transform);

		//		if(onBoundary){
		//			transform.position = new Vector3 (Mathf.Clamp(transform.position.x,minCameraPos.x,maxCameraPos.x),
		//				Mathf.Clamp(transform.position.y,minCameraPos.y,maxCameraPos.y),
		//				Mathf.Clamp(transform.position.z,minCameraPos.z,maxCameraPos.z));
		//		}


	}
}
