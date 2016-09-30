using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float detectionLevel;
	public int moneyCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (detectionLevel >= 0.1f) {
			detectionLevel -= 5.0f * Time.deltaTime;
		} 
		else {
			detectionLevel = 0.0f;
		}

		if(detectionLevel >= 100.0f){
			GameManager.Instance.RestartLevel ();
		}
	}
}
