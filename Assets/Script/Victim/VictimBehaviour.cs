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

	public List<PatternInfo> patternInfoList = new List<PatternInfo>();

	//Chase Player
	public bool isChasingPlayer;
	public NavMeshAgent navMeshChaserObject;
	//End of Chase Player

	// Use this for initialization
	void Start () {
//		if (isIdle) {
//			//Patrol Pattern
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolForward", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolRight", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolLeft", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolBackward", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//		} else {
//			//Idle Pattern
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolRight", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolLeft", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//			patternInfoList.Add (new PatternInfo ("PatrolIdle", moveCounter));
//		}
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
		transform.position = navMeshChaserObject.transform.position;
		transform.rotation = navMeshChaserObject.transform.rotation;
		navMeshChaserObject.SetDestination (GameManager.Instance.playerObject.transform.position);
		StartCoroutine ("ChaseBlink", 0.3f);
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
	}

	void RotateLeft(){
		transform.Rotate (0, -90.0f, 0);
	}

	void RotateRight(){
		transform.Rotate (0, 90.0f, 0);
	}

	void MoveForward(){
		transform.Translate (Vector3.forward*speed);
	}

	void MoveBackward(){
		transform.Translate (-Vector3.forward*speed);
	}
}
