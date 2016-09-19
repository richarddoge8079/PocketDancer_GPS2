using UnityEngine;
using System.Collections;

public class VictimBehaviour : MonoBehaviour {

	public int Dir;

	public float timer;

	public int speed;

	// Use this for initialization
	void Start () {
		StartCoroutine("RandomMoveTimer", timer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RandomMoveTimer (float d)
	{
		
		yield return new WaitForSeconds (d);
		Dir = Random.Range (0, 3);
		Debug.Log ("timer");
		CheckDirection ();
		StartCoroutine ("RandomMoveTimer", timer);
	}

	void MoveLeft(){
		transform.Translate (Vector3.left*speed*Time.deltaTime);
	}

	void MoveRight(){
		transform.Translate (Vector3.right*speed*Time.deltaTime);
	}

	void MoveForward(){
		transform.Translate (Vector3.forward*speed*Time.deltaTime);
	}

	void MoveBackward(){
		transform.Translate (-Vector3.forward*speed*Time.deltaTime);
	}

	void CheckDirection(){
		if (Dir == 0) {
			MoveLeft ();
		} else if (Dir == 1) {
			MoveRight ();
		} else if (Dir == 2) {
			MoveForward ();
		} else if (Dir == 3) {
			MoveBackward ();
		}
	}
}
