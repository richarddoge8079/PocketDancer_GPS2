using UnityEngine;
using System.Collections;

public class VictimBehaviour : MonoBehaviour {

	//public int Dir;
	//public float timer;

	public int speed;

	public float moveCounter;
	public bool isIdle;

	// Use this for initialization
	void Start () {
		//StartCoroutine("RandomMoveTimer", timer);
		if (!isIdle) {
			StartCoroutine ("PatrolLeft", moveCounter);
		} else {
//			StartCoroutine ("PatrolIdle1", moveCounter);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	/*IEnumerator RandomMoveTimer (float d)
	{
		yield return new WaitForSeconds (d);
		Dir = Random.Range (0, 4);
		Debug.Log ("timer");
		CheckDirection ();
		StartCoroutine ("RandomMoveTimer", timer);
	}*/

	IEnumerator PatrolLeft (float c)
	{
		yield return new WaitForSeconds (c);
		MoveLeft ();
		StartCoroutine("PatrolIdle1", moveCounter);
	}

	IEnumerator PatrolRight (float c)
	{
		yield return new WaitForSeconds (c);
		MoveRight ();
		StartCoroutine("PatrolIdle2", moveCounter);
	}

	IEnumerator PatrolIdle1 (float c)
	{
		yield return new WaitForSeconds (c);
		Idle ();
		StartCoroutine("PatrolRight", moveCounter);
	}

	IEnumerator PatrolIdle2 (float c)
	{
		yield return new WaitForSeconds (c);
		Idle ();
		StartCoroutine("PatrolLeft", moveCounter);
	}

	void Idle(){
		transform.Translate (Vector3.zero);
	}

	void MoveLeft(){
		transform.Translate (Vector3.left*speed);
	}

	void MoveRight(){
		transform.Translate (Vector3.right*speed);
	}

	void MoveForward(){
		transform.Translate (Vector3.forward*speed);
	}

	void MoveBackward(){
		transform.Translate (-Vector3.forward*speed);
	}

	/*void CheckDirection(){
		if (Dir == 0) {
			Idle ();
		} else if (Dir == 1) {
			MoveLeft ();
		} else if (Dir == 2) {
			MoveRight ();
		} else if (Dir == 3) {
			MoveForward ();
		} else if (Dir == 4) {
			MoveBackward ();
		}
		Debug.Log ("Direction code " + Dir);
	}*/
}
