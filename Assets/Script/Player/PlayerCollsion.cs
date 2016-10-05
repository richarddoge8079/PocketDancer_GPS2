using UnityEngine;
using System.Collections;

public class PlayerCollsion : MonoBehaviour {
	public float detect;
	public int playerMoney;

	public bool collidedObject;

//	public Vector3 previousPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Wall") || coll.CompareTag("Victim")){
//			GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
			GameManager.Instance.playerObject.transform.Translate(-Vector3.forward * 2);
			collidedObject = true;
		}
	}

//	public void SetPreviousPosition(Vector3 temp){
//		if (!collidedObject) {
//			GameManager.Instance.playerPreviousPosition = temp;
//			Debug.Log ("AS");
//		} 
//		else {
//			collidedObject = false;
//			GameManager.Instance.playerMovementScript.previousPos = temp;
//			GameManager.Instance.playerPreviousPosition = temp;
//		}			
//	}

//	void OnCollisionEnter(Collision coll){
//		if(coll.CompareTag("Wall") || coll.CompareTag("Victim")){
//			GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
//		}
//	}
}
