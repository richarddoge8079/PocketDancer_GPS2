using UnityEngine;
using System.Collections;

public class VictimCollision : MonoBehaviour {
	public float pickpocketRange;
	public bool playerInRange = false;
	public bool picked = false;
	public int maxMoney;
	public int minMoney;
	public int money;
	public float offRangeTimer;
	//	public float timer = defaultTime;
	//	public bool timerStart = false;
	RaycastHit isPickpocketed;
	// Use this for initialization

	// Update is called once per frame
	void Update ()
	{
		//		if (timerStart) 
		//		{
		//			timer -= Time.deltaTime;
		//			if (timer <= 0) 
		//			{
		//				playerInRange = false;
		//				timer = defaultTime;
		//				timerStart = false;
		//			}
		//		}
		Ray pickpocketRayBack = new Ray (transform.localPosition, -transform.forward);
		//		Ray pickpocketRayRight = new Ray (transform.localPosition, transform.right);
		//		Ray pickpocketRayLeft = new Ray (transform.localPosition, -transform.right);
		if (Physics.Raycast (pickpocketRayBack, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRange = true;
				//				Debug.Log ("Target In Range");
			} 
		}
		//		else if (Physics.Raycast (pickpocketRayRight, out isPickpocketed, pickpocketRange)) 
		//		{
		//			if (isPickpocketed.collider.tag == "Player") 
		//			{
		//				playerInRange = true;
		////				Debug.Log ("Target In Range");
		//			} 
		//		}
		//		else if (Physics.Raycast (pickpocketRayLeft, out isPickpocketed, pickpocketRange)) 
		//		{
		//			if (isPickpocketed.collider.tag == "Player") 
		//			{
		//				playerInRange = true;
		////				Debug.Log ("Target In Range");
		//			} 
		//		} 
		else 
		{
			StartCoroutine (Timer (offRangeTimer));
			//			timerStart = true;
			//			Debug.Log ("Target Lost");
		}
		Debug.DrawRay (transform.localPosition, -transform.forward * pickpocketRange, Color.green);
		//		Debug.DrawRay (transform.localPosition, transform.right, Color.blue);
		//		Debug.DrawRay (transform.localPosition, -transform.right, Color.red);
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
					picked = true;
					//					GameManager.Instance.playerObject.transform.position = GameManager.Instance.playerPreviousPosition;
				} 
				else 
				{
//					Debug.Log ("Why did someone touch my butt?!");

				}
			} 
			else 
			{
//				Debug.Log ("Watch Where You're Going!?");
			}
		}
	}

	IEnumerator Timer(float Delay)
	{
		yield return new WaitForSeconds (Delay);
		playerInRange = false;
	}
}

