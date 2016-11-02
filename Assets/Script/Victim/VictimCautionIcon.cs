using UnityEngine;
using System.Collections;

public class VictimCautionIcon : MonoBehaviour 
{
	public GameObject questionMark;
	public GameObject exclamationMark;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.Instance.inSight == true && GameManager.Instance.playerStatsScript.detectionLevel > 0.0f) 
		{
			questionMark.SetActive (true);
		} 
		else if (GameManager.Instance.inSight == true && GameManager.Instance.playerStatsScript.detectionLevel == 100.0f) 
		{
			exclamationMark.SetActive (true);
		} 
	}
}
