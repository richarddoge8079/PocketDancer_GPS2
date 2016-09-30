using UnityEngine;
using System.Collections;

public class PlayerCollsion : MonoBehaviour {
	public float detect;
	public int playerMoney;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Wall") || coll.CompareTag("Victim")){
			GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
		}
	}

//	void OnCollisionEnter(Collision coll){
//		if(coll.CompareTag("Wall") || coll.CompareTag("Victim")){
//			GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
//		}
//	}
}
