using UnityEngine;
using System.Collections;

public class VictimCollision : MonoBehaviour {
	public float pickpocketRange;
	public bool playerInRange = false;
	public bool picked = false;
	public int maxMoney;
	public int minMoney;
	public int money;
	public float defaultTime;
	public float detectionLevel;
	public GameObject rob;
	RaycastHit isPickpocketed;
	// Use this for initialization

	// Update is called once per frame
	void Update ()
	{
		Ray pickpocketRayBack = new Ray (transform.localPosition, -transform.forward);
		if (Physics.Raycast (pickpocketRayBack, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRange = true;
				//Debug.Log ("Target In Range");
			} 
		} 
		else 
		{
			StartCoroutine (Timer (defaultTime));
		}



		Debug.DrawRay (transform.localPosition, -transform.forward * pickpocketRange, Color.green);
	}
	void OnTriggerEnter (Collider coll)
	{
		if(coll.CompareTag("Player"))
		{
			if (playerInRange)  
			{
				if (!picked)
				{
//					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minMoney, maxMoney);
					GameManager.Instance.playerStatsScript.moneyCount += money;
					Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);
					picked = true;
				} 
				else 
				{
//					Debug.Log ("Why did someone touch my butt?!");
					GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
				}
			} 
			else 
			{
//				Debug.Log ("Watch Where You're Going!?");
				GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
			}
		}
	}

	IEnumerator Timer(float Delay)
	{
		yield return new WaitForSeconds (Delay);
		playerInRange = false;
	}
}

