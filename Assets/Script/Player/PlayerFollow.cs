using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {


	public float smoothTimerX,smoothTimerY,smoothTimerZ;

	public float xSpeed,ySpeed,zSpeed; //xDistance,yDistance,zDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = GameManager.Instance.playerObject.transform.rotation;
		if(transform.position == GameManager.Instance.playerObject.transform.position){
			return;
		}

		float posX = Mathf.SmoothDamp (transform.position.x,GameManager.Instance.playerObject.transform.position.x, ref xSpeed,smoothTimerX);
		float posY = Mathf.SmoothDamp (transform.position.y,GameManager.Instance.playerObject.transform.position.y, ref ySpeed,smoothTimerY);
		float posZ = Mathf.SmoothDamp (transform.position.z,GameManager.Instance.playerObject.transform.position.z, ref zSpeed,smoothTimerZ);

		transform.position = new Vector3 (posX,posY,posZ);

	}
}
