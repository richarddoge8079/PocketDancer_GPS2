using UnityEngine;
using System.Collections;

public class ExclamationDisable : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.Instance.inSight == false || GameManager.Instance.playerStatsScript.detectionLevel == 0.0f) 
		{
			gameObject.SetActive (false);
		}
	}
}
