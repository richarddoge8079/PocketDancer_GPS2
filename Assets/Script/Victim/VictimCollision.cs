using UnityEngine;
using System.Collections;

public class VictimCollision : MonoBehaviour {
	//VFX
	public GameObject rob;
	public GameObject questionMark;
	public GameObject exclamationMark;
	//End if VFX
	public GameObject victimBackFX;

	public float pickpocketRange;
	public bool playerInRangeBack = false;
	public bool playerInRangeLeft = false;
	public bool playerInRangeRight = false;
	public bool picked = false;
	public int maxBackMoney;
	public int minBackMoney;
	public int maxLeftMoney;
	public int minLeftMoney;
	public int maxRightMoney;
	public int minRightMoney;
	public int money;
	public float defaultTime;
	public float detectionLevel;
	RaycastHit isPickpocketed;
	// Use this for initialization
	// Update is called once per frame
	void Update ()
	{
		Ray pickpocketRayBack = new Ray (transform.localPosition, -transform.forward);
		Ray pickpocketRayRight = new Ray (transform.localPosition, transform.right);
		Ray pickpocketRayLeft = new Ray (transform.localPosition, -transform.right);
		if (Physics.Raycast (pickpocketRayBack, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeBack = true;
				//				Debug.Log ("Target In Range");
			} 
		} 
		else if (Physics.Raycast (pickpocketRayRight, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeRight = true;
				//Debug.Log ("Target In Range");
			} 
		} 
		else if (Physics.Raycast (pickpocketRayLeft, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeLeft = true;
				//Debug.Log ("Target In Range");
			} 
		} 
		else 
		{
			StartCoroutine (Timer (defaultTime));
		}
		//Debug.DrawRay (transform.localPosition, -transform.forward * pickpocketRange, Color.green);
	}
	void OnTriggerEnter (Collider coll)
	{
		if(coll.CompareTag("Player"))
		{
			if (playerInRangeBack)  
			{
				if (!picked)
				{
					//					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minBackMoney, maxBackMoney);
					if (UIManager.Instance.updateTotalMoney) 
					{
						UIManager.Instance.UiVictimMoney += money;

						GameObject obj = ObjectPoolingScript.Current.GetPooledObject ();

						if (obj == null)return;

						obj.transform.position = transform.position;
						obj.SetActive (true);

						picked = true;
					}
					else
					{
						UIManager.Instance.UiVictimMoney += money;
						UIManager.Instance.UpdateMoney ();
						GameObject obj = ObjectPoolingScript.Current.GetPooledObject ();

						if (obj == null)return;

						obj.transform.position = transform.position;
						obj.SetActive (true);

						picked = true;
					}
				} 
				else 
				{
					//					Debug.Log ("Why did someone touch my butt?!");
					GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
					if (GameManager.Instance.playerStatsScript.detectionLevel >= 50) 
					{
						//						Instantiate(questionMark, transform.localPosition + new Vector3(0f, 1.5f, 0f), )
					}
				}
			} 
			if (playerInRangeRight)  
			{
				if (!picked)
				{
					//					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minRightMoney, maxRightMoney);

					victimBackFX.SetActive (false);

					if (UIManager.Instance.updateTotalMoney) 
					{
						UIManager.Instance.UiVictimMoney += money;
						GameObject obj = ObjectPoolingScript.Current.GetPooledObject ();

						if (obj == null)return;

						obj.transform.position = transform.position;
						obj.SetActive (true);

						picked = true;
					}
					else
					{
						UIManager.Instance.UiVictimMoney += money;
						UIManager.Instance.UpdateMoney ();
						picked = true;
					}
				} 
				else 
				{
					//Debug.Log ("Why did someone touch my butt?!");
					GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
				}
			} 
			if (playerInRangeLeft)  
			{
				if (!picked)
				{
					//Debug.Log ("I've just been robbed!?");
					money = Random.Range (minLeftMoney, maxLeftMoney);

					victimBackFX.SetActive (false);

					if (UIManager.Instance.updateTotalMoney) 
					{
						UIManager.Instance.UiVictimMoney += money;
						GameObject obj = ObjectPoolingScript.Current.GetPooledObject ();

						if (obj == null)return;

						obj.transform.position = transform.position;
						obj.SetActive (true);

						picked = true;
					}
					else
					{
						UIManager.Instance.UiVictimMoney += money;
						UIManager.Instance.UpdateMoney ();
						GameObject obj = ObjectPoolingScript.Current.GetPooledObject ();

						if (obj == null)return;

						obj.transform.position = transform.position;
						obj.SetActive (true);

						picked = true;
					}
				} 
				else 
				{
					//Debug.Log ("Why did someone touch my butt?!");
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
		playerInRangeBack= false;
		playerInRangeRight = false;
		playerInRangeLeft = false;
	}
}

