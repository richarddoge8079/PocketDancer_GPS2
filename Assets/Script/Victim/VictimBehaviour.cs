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

	public List<PatternInfo> patternInfoList = new List<PatternInfo>();

	// Use this for initialization
	void Start () {
		patternInfoList.Add(new PatternInfo ("PatrolLeft", moveCounter));
		patternInfoList.Add(new PatternInfo ("PatrolIdle", moveCounter));
		patternInfoList.Add(new PatternInfo ("PatrolRight", moveCounter));
		patternInfoList.Add(new PatternInfo ("PatrolIdle", moveCounter));
		isPatternCompleted = true;
	}

	// Update is called once per frame
	void Update () {
		if (isPatternCompleted == true) {
			currentPatternIndex++;
			if (currentPatternIndex >= patternInfoList.Count) {
				currentPatternIndex = 0; 
			}
			StartCoroutine (patternInfoList[currentPatternIndex].functionName, patternInfoList[currentPatternIndex].yieldDelay);
			isPatternCompleted = false;
		}
	}

	IEnumerator PatrolLeft (float c)
	{
		yield return new WaitForSeconds (c);
		RotateLeft ();
		MoveForward ();
		isPatternCompleted = true;
	}

	IEnumerator PatrolRight (float c)
	{
		yield return new WaitForSeconds (c);
		RotateRight ();
		MoveForward ();
		isPatternCompleted = true;
	}

	IEnumerator PatrolIdle (float c)
	{
		yield return new WaitForSeconds (c);
		Idle ();
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
