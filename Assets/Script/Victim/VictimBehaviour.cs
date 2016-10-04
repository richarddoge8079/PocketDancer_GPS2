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
		MoveLeft ();
		isPatternCompleted = true;
		//StartCoroutine("PatrolIdle1", moveCounter);
	}

	IEnumerator PatrolRight (float c)
	{
		yield return new WaitForSeconds (c);
		MoveRight ();
		isPatternCompleted = true;
		//StartCoroutine("PatrolIdle2", moveCounter);
	}

	IEnumerator PatrolIdle (float c)
	{
		yield return new WaitForSeconds (c);
		Idle ();
		isPatternCompleted = true;
		//StartCoroutine("PatrolRight", moveCounter);
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
}
