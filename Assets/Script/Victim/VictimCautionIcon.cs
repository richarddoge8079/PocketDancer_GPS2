using UnityEngine;
using System.Collections;

public class VictimCautionIcon : MonoBehaviour 
{
	public GameObject questionMark;
	public GameObject exclamationMark;

	public GameObject questionParticle;
	public GameObject exclamationParticle;
	
	public VictimBehaviour victimBehaviorScript;


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(victimBehaviorScript.playerInSight && GameManager.Instance.playerStatsScript.detectionLevel > 0.0f){
			if (GameManager.Instance.playerStatsScript.isDetected) {
				questionMark.SetActive (false);
				exclamationMark.SetActive (true);
			} 
			else {
				questionMark.SetActive (true);
				exclamationMark.SetActive (false);
			}
		}
	}

	public void TriggerIcon(){
		if(!victimBehaviorScript.playerInSight){
			if(GameManager.Instance.playerStatsScript.detectionLevel>=0){
				questionMark.SetActive (true);
			}
		}
	}

	IEnumerator showQuestionMarkIcon(float t){
		yield return new WaitForSeconds (t);
		if(!victimBehaviorScript.playerInSight){
			questionMark.SetActive (false);
		}
	}
}
