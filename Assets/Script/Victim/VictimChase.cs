using UnityEngine;
using System.Collections;

public class VictimChase : MonoBehaviour {

	public float moveTimer;

	public bool canChase;

	void Start(){
		StartCoroutine ("ChasePlayerTimer",moveTimer);
	}

	IEnumerator ChasePlayerTimer(float t){
		yield return new WaitForSeconds (t);
		if (canChase) {
			if (GameManager.Instance.playerObject.transform.position.x > transform.position.x) {
				transform.Translate (Vector3.right * 2);
			} else if (GameManager.Instance.playerObject.transform.position.x < transform.position.x) {
				transform.Translate (-Vector3.right * 2);
			}

			if (GameManager.Instance.playerObject.transform.position.z > transform.position.z) {
				transform.Translate (Vector3.forward * 2);
			} else if (GameManager.Instance.playerObject.transform.position.z < transform.position.z) {
				transform.Translate (-Vector3.forward * 2);
			}
			StartCoroutine ("ChasePlayerTimer", moveTimer);
		}
	}
}
