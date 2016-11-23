using UnityEngine;
using System.Collections;

public class VictimCautionIcon : MonoBehaviour 
{
	public GameObject questionMark;
	public GameObject exclamationMark;

	public GameObject questionParticle;
	public GameObject exclamationParticle;
	
	public VictimBehaviour victimBehaviorScript;

	public GameObject victimFollowerObject;

	public bool isDisabled;


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
				isDisabled = false;
			} 
			else {
				questionMark.SetActive (true);
				exclamationMark.SetActive (false);
				isDisabled = false;
			}
		}
		else if(!isDisabled){
			StartCoroutine ("DisableIconTimer",1.5f);
			isDisabled = true;
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

	IEnumerator DisableIconTimer(float t){
		yield return new WaitForSeconds (t);
		questionMark.SetActive (false);
		exclamationMark.SetActive (false);
	}

	public void TriggerStart(){
		questionMark = victimFollowerObject.transform.FindChild ("QuestionMark").gameObject;
		exclamationMark = victimFollowerObject.transform.FindChild ("ExclamationMark").gameObject;
	}
}
