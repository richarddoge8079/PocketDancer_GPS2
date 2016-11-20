using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float detectionLevel;
	public bool isDetected;

	public int moneyCount;

	public bool canVIP;

	void Awake(){
		GameManager.Instance.InitializeGame ();
	}

	// Use this for initialization
	void Start () {
//		DataManager.Instance.Load ();
		moneyCount = (int)DataManager.Instance.moneyCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.Instance.songEnded) {
			if (detectionLevel >= 0.1f) {
				detectionLevel -= 5.0f * Time.deltaTime;
				//			detectionLevel -= 100.0f * Time.deltaTime;
			} else {
				detectionLevel = 0.0f;
			}

//			if (detectionLevel >= 100.0f) {
//				GameManager.Instance.RestartLevel ();
//			}
		} 
		else 
		{
			if (DataManager.Instance.upgrade6Active == false) 
			{
				if(detectionLevel <= 99.0f)
				{
				detectionLevel += 20.0f * Time.deltaTime;
				} 
				else
				{
					detectionLevel = 100.0f;
				}
			}

			else 
			{
				if(detectionLevel <= 104.0f)
				{
					detectionLevel += 20.0f * Time.deltaTime;
				} 
				else
				{
					detectionLevel = 105.0f;
				}
			}
		}
		if(DataManager.Instance.upgrade6Active == false && detectionLevel >= 100.0f || DataManager.Instance.upgrade6Active == true && detectionLevel >= 105.0f)
		{
			isDetected = true;
		}
	}
}
