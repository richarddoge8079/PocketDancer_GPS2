using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PatternInfo
{
	public string functionName;
	public float yieldDelay;

	public PatternInfo(string f, float y)
	{
		this.functionName = f;
		this.yieldDelay = y;
	}
}

public class VictimBehaviour : MonoBehaviour {

	public int currentPatternIndex = 0;
	public bool isPatternCompleted = false;

	public int speed;

	public float moveCounter;
	public bool isIdle;

	public bool startChase;
	public bool canChase;
	public bool playerInSight;

	public List<PatternInfo> patternInfoList = new List<PatternInfo>();

	//Animation
	public AnimationRandomizer victimAnimationScript;

	//Chase Player
	public bool isChasingPlayer;
	public NavMeshAgent navMeshChaserObject;
	//End of Chase Player

	// Use this for initialization
	void Start () {
		isPatternCompleted = true;
	}

	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.playerStatsScript.isDetected){
			isChasingPlayer = true;
		}

		if (!isChasingPlayer) {
			if (isPatternCompleted == true) {
				currentPatternIndex++;
				if (currentPatternIndex >= patternInfoList.Count) {
					currentPatternIndex = 0; 
				}
				StartCoroutine (patternInfoList [currentPatternIndex].functionName, patternInfoList [currentPatternIndex].yieldDelay);
				isPatternCompleted = false;
			}
		} 
		else {
			if(!startChase){
				StartCoroutine ("ChaseBlink", 0.3f);
				startChase = true;
			}
		}
	}

	//Chase Timer
	IEnumerator ChaseBlink(float t){
		yield return new WaitForSeconds (t);
		if (playerInSight) {
			if (canChase) {
				navMeshChaserObject.SetDestination (GameManager.Instance.playerObject.transform.position);
				StopCoroutine ("ResetChase");
			}
		} 
		else {
			if(canChase){
				StartCoroutine ("ResetChase",1.0f);
			}
		}

		transform.position = navMeshChaserObject.transform.position;
		transform.rotation = navMeshChaserObject.transform.rotation;
		StartCoroutine ("ChaseBlink", 0.3f);
	}

	IEnumerator ResetChase(float t){
		yield return new WaitForSeconds (t);
		canChase = false;
	}

	//End of Chase Timer

	IEnumerator PatrolLeft (float c)
	{
		yield return new WaitForSeconds (c);
		RotateLeft ();
		isPatternCompleted = true;
	}

	IEnumerator PatrolRight (float c)
	{
		yield return new WaitForSeconds (c);
		RotateRight ();
		isPatternCompleted = true;
	}

	IEnumerator PatrolIdle (float c)
	{
		yield return new WaitForSeconds (c);
		Idle ();
		isPatternCompleted = true;
	}

	IEnumerator PatrolForward (float c)
	{
		yield return new WaitForSeconds (c);
		MoveForward ();
		isPatternCompleted = true;
	}
	IEnumerator PatrolBackward (float c)
	{
		yield return new WaitForSeconds (c);
		MoveBackward ();
		isPatternCompleted = true;
	}


	void Idle(){
		transform.Translate (Vector3.zero);
		//PlayAnimation ();
	}

	void RotateLeft(){
		transform.Rotate (0, -90.0f, 0);
		//PlayAnimation ();
	}

	void RotateRight(){
		transform.Rotate (0, 90.0f, 0);
		//PlayAnimation ();
	}

	void MoveForward(){
		transform.Translate (Vector3.forward*speed);
		//PlayAnimation ();
	}

	void MoveBackward(){
		transform.Translate (-Vector3.forward*speed);
		//PlayAnimation ();
	}

//	void PlayAnimation(){
//		victimAnimationScript.PlayAnimation ();
//	}
}
