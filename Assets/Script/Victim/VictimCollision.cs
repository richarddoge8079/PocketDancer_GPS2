using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VictimCollision : MonoBehaviour {
	//VFX
	public GameObject rob;
	public Canvas UICanvas;
	//End if VFX
	public GameObject victimBackFX;
	public Image coins;
	public float pickpocketRange;
	public bool playerInRangeFront = false;
	public bool playerInRangeBack = false;
	public bool playerInRangeLeft = false;
	public bool playerInRangeRight = false;
	public bool picked = false;
	public int maxFrontMoney;
	public int minFrontMoney;
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

	void Start()
	{
		ObjectPoolingScript.Instance.CreatePool (rob, 5, 10);
	}

	void Update ()
	{
		Ray pickpocketRayBack = new Ray (transform.localPosition, -transform.forward);
		Ray pickpocketRayFront = new Ray (transform.localPosition, transform.forward);
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
		else if (Physics.Raycast (pickpocketRayFront, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeFront = true;
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
					//Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);

					GameObject go = ObjectPoolingScript.Instance.GetObject ("MoneyParticleSystem");

					if (go != null) 
					{
						//! Reseting the bullet attributes
						go.transform.position = transform.position;
					}

					picked = true;

					Image fuck = (Image)Instantiate (coins,new Vector3 (coll.transform.position.x,coll.transform.position.y,coll.transform.position.z),Quaternion.identity);
					fuck.transform.SetParent (UICanvas.transform);
					//					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minBackMoney, maxBackMoney);
					if (UIManager.Instance.updateTotalMoney) 
					{
						UIManager.Instance.UiVictimMoney += money;
						GameManager.Instance.pickPocket += 1;
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
					//Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);

					GameObject go = ObjectPoolingScript.Instance.GetObject ("MoneyParticleSystem");

					if (go != null) 
					{
						//! Reseting the bullet attributes
						go.transform.position = transform.position;
					}

					picked = true;

					//					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minRightMoney, maxRightMoney);

					victimBackFX.SetActive (false);

					if (UIManager.Instance.updateTotalMoney) 
					{
						UIManager.Instance.UiVictimMoney += money;
						GameManager.Instance.pickPocket += 1;

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
					//Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);

					GameObject go = ObjectPoolingScript.Instance.GetObject ("MoneyParticleSystem");

					if (go != null) 
					{
						//! Reseting the bullet attributes
						go.transform.position = transform.position;
					}

					picked = true;

					//					Debug.Log ("I've just been robbed!?");

					money = Random.Range (minLeftMoney, maxLeftMoney);

					victimBackFX.SetActive (false);

					if (UIManager.Instance.updateTotalMoney) 
					{
						UIManager.Instance.UiVictimMoney += money;
						GameManager.Instance.pickPocket += 1;

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
			else 
			{
				//				Debug.Log ("Watch Where You're Going!?");
				GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
			}
		}
		if (playerInRangeFront)  
		{
			if (!picked)
			{
				//					Debug.Log ("I've just been robbed!?");
				//Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);

				GameObject go = ObjectPoolingScript.Instance.GetObject ("MoneyParticleSystem");

				if (go != null) 
				{
					//! Reseting the bullet attributes
					go.transform.position = transform.position;
				}

				picked = true;

				//					Debug.Log ("I've just been robbed!?");
				money = Random.Range (minFrontMoney, maxFrontMoney);
				if (UIManager.Instance.updateTotalMoney) 
				{
					UIManager.Instance.UiVictimMoney += money;
					GameManager.Instance.pickPocket += 1;

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
				//					Debug.Log ("Why did someone touch my butt?!");
				GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
				if (GameManager.Instance.playerStatsScript.detectionLevel >= 50) 
				{
					//						Instantiate(questionMark, transform.localPosition + new Vector3(0f, 1.5f, 0f), )
				}
			}
		} 
	}

	IEnumerator Timer(float Delay)
	{
		yield return new WaitForSeconds (Delay);
		playerInRangeBack= false;
		playerInRangeFront= false;
		playerInRangeRight = false;
		playerInRangeLeft = false;
	}
}