using UnityEngine;
using System.Collections;

public class VictimFollow : MonoBehaviour {


	public float smoothTimerX,smoothTimerY,smoothTimerZ;

	public float xSpeed,ySpeed,zSpeed; //xDistance,yDistance,zDistance;

	public GameObject victimObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position == victimObject.transform.position){
			Debug.Log ("No Follow");
			return;
		}

		float posX = Mathf.SmoothDamp (transform.position.x, victimObject.transform.position.x, ref xSpeed,smoothTimerX);
		float posY = Mathf.SmoothDamp (transform.position.y, victimObject.transform.position.y, ref ySpeed,smoothTimerY);
		float posZ = Mathf.SmoothDamp (transform.position.z, victimObject.transform.position.z, ref zSpeed,smoothTimerZ);

		transform.position = new Vector3 (posX,posY,posZ);

		transform.rotation = victimObject.transform.rotation;
	}

	public void SetFollow(GameObject ga){
		victimObject = ga;
	}
}
