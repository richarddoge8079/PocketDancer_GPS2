﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictimCollision : MonoBehaviour {
	//VFX
	public GameObject rob;
	public Canvas UICanvas;
	public Camera camera;
	//End if VFX
	public GameObject victimBackFX;

	public Image Money;
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
	public bool allDirectionPick;
	// Use this for initialization
	// Update is called once per frame

	void Start()
	{
		ObjectPoolingScript.Instance.CreatePool (rob, 5, 10);
		UICanvas = UIManager.Instance.gameObject.GetComponent<Canvas>();
		camera = Camera.main;
		allDirectionPick = DataManager.Instance.upgrade2Active;

		if(DataManager.Instance.upgrade7Active == true)
		{
			minFrontMoney += 20;
			minBackMoney += 20;
			minLeftMoney += 20;
			minRightMoney += 20;
		}
	}

	void Update ()
	{
<<<<<<< HEAD
//		Ray pickpocketRayBack = new Ray (transform.localPosition, -transform.forward);
//		Ray pickpocketRayFront = new Ray (transform.localPosition, transform.forward);
//		Ray pickpocketRayRight = new Ray (transform.localPosition, transform.right);
//		Ray pickpocketRayLeft = new Ray (transform.localPosition, -transform.right);
		if (Physics.Raycast (transform.position, -transform.forward, out isPickpocketed, pickpocketRange)) 
=======
		Ray pickpocketRayBack = new Ray (transform.localPosition, -transform.forward);
		Ray pickpocketRayFront = new Ray (transform.localPosition, transform.forward);
		Ray pickpocketRayRight = new Ray (transform.localPosition, transform.right);
		Ray pickpocketRayLeft = new Ray (transform.localPosition, -transform.right);
		Debug.DrawRay (transform.position,-transform.forward);
		if (Physics.Raycast (pickpocketRayBack, out isPickpocketed, pickpocketRange)) 
>>>>>>> 49caa3ee7c2efd59ca59347a083017bd348598a1
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeBack = true;
				StopCoroutine ("Timer");
				//				Debug.Log ("Target In Range");
			} 
		} 
		else if (Physics.Raycast (transform.position, transform.right, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeRight = true;
				StopCoroutine ("Timer");
				//Debug.Log ("Target In Range");
			} 
		} 
		else if (Physics.Raycast (transform.position, -transform.right, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeLeft = true;
				StopCoroutine ("Timer");
				//Debug.Log ("Target In Range");
			} 
		} 
		else if (Physics.Raycast (transform.position, transform.forward, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.CompareTag("Player")) 
			{
				playerInRangeFront = true;
				StopCoroutine ("Timer");
				//Debug.Log ("Target In Range");
			} 
		} 
		else 
		{
			StartCoroutine ("Timer" ,defaultTime);
		}
		//Debug.DrawRay (transform.localPosition, -transform.forward * pickpocketRange, Color.green);
	}
	void OnTriggerEnter (Collider coll)
	{
		if(coll.CompareTag("Player"))
		{
			//Detected
			if(GameManager.Instance.playerStatsScript.isDetected){
				SceneManager.LoadScene ("Hideout");
				DataManager.Instance.upgrade1Active = false;
				DataManager.Instance.upgrade2Active = false;
				DataManager.Instance.upgrade3Active = false;
				DataManager.Instance.upgrade4Active = false;
				DataManager.Instance.upgrade5Active = false;
				DataManager.Instance.upgrade6Active = false;
				DataManager.Instance.upgrade7Active = false;
				DataManager.Instance.upgrade8Active = false;
				return;
			}
			//End of Detected

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
					money = Random.Range (minBackMoney, maxBackMoney);
					//					Debug.Log ("I've just been robbed!?");

					if (UIManager.Instance.updateTotalMoney) 
					{
						Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
						Image Coin = (Image)Instantiate (Money,new Vector3 (screenPos.x,screenPos.y,transform.position.z),Quaternion.identity);
						Coin.transform.SetParent (UICanvas.transform);
						UIManager.Instance.UiVictimMoney += money;
						GameManager.Instance.pickPocket += 1;
					}
					else
					{
						Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
						Image Coin = (Image)Instantiate (Money,new Vector3 (screenPos.x,screenPos.y,transform.position.z),Quaternion.identity);
						Coin.transform.SetParent (UICanvas.transform);
						UIManager.Instance.UiVictimMoney += money;
						UIManager.Instance.UpdateMoney ();

						picked = true;
						victimBackFX.SetActive (false);
					}
				} 
				else 
				{
					//					Debug.Log ("Why did someone touch my butt?!");
					GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
				}
			} 
			if (playerInRangeRight)  
			{
				if (allDirectionPick == true) 
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
						money = Random.Range (minRightMoney, maxRightMoney);
						//					Debug.Log ("I've just been robbed!?");
						victimBackFX.SetActive (false);

						if (UIManager.Instance.updateTotalMoney) 
						{
							Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
							Image Coin = (Image)Instantiate (Money,new Vector3 (screenPos.x,screenPos.y,transform.position.z),Quaternion.identity);
							Coin.transform.SetParent (UICanvas.transform);
							UIManager.Instance.UiVictimMoney += money;
							GameManager.Instance.pickPocket += 1;

							picked = true;
						}
						else
						{
							Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
							Image Coin = (Image)Instantiate (Money,new Vector3 (screenPos.x,screenPos.y,transform.position.z),Quaternion.identity);
							Coin.transform.SetParent (UICanvas.transform);
							UIManager.Instance.UiVictimMoney += money;
							UIManager.Instance.UpdateMoney ();
							picked = true;
						}

						victimBackFX.SetActive (false);
					} 
					else 
					{
						//Debug.Log ("Why did someone touch my butt?!");
						GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
					}
				}
			} 
			if (playerInRangeLeft) {
				if (allDirectionPick == true) {
					if (!picked) {
						//Debug.Log ("I've just been robbed!?");
						//Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);

						GameObject go = ObjectPoolingScript.Instance.GetObject ("MoneyParticleSystem");

						if (go != null) {
							//! Reseting the bullet attributes
							go.transform.position = transform.position;
						}

						picked = true;
						money = Random.Range (minLeftMoney, maxLeftMoney);

						//Debug.Log ("I've just been robbed!?");
						victimBackFX.SetActive (false);

						if (UIManager.Instance.updateTotalMoney) {
							Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
							Image Coin = (Image)Instantiate (Money, new Vector3 (screenPos.x, screenPos.y, transform.position.z), Quaternion.identity);
							Coin.transform.SetParent (UICanvas.transform);
							UIManager.Instance.UiVictimMoney += money;
							GameManager.Instance.pickPocket += 1;

							picked = true;
						} else {
							Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
							Image Coin = (Image)Instantiate (Money, new Vector3 (screenPos.x, screenPos.y, transform.position.z), Quaternion.identity);
							Coin.transform.SetParent (UICanvas.transform);
							UIManager.Instance.UiVictimMoney += money;
							UIManager.Instance.UpdateMoney ();


							picked = true;
						}

						victimBackFX.SetActive (false);
					} else {
						//Debug.Log ("Why did someone touch my butt?!");
						GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
					}
				} else {
					//Debug.Log ("Watch Where You're Going!?");
					GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
				}
			}
		}
		if (playerInRangeFront)  
		{
			if (allDirectionPick == true) {
				if (!picked) {
					//					Debug.Log ("I've just been robbed!?");
					//Instantiate(rob, GameManager.Instance.playerObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);

					GameObject go = ObjectPoolingScript.Instance.GetObject ("MoneyParticleSystem");

					if (go != null) {
						//! Reseting the bullet attributes
						go.transform.position = transform.position;
					}

					picked = true;
					//					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minFrontMoney, maxFrontMoney);
					if (UIManager.Instance.updateTotalMoney) {
						Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
						Image Coin = (Image)Instantiate (Money, new Vector3 (screenPos.x, screenPos.y, transform.position.z), Quaternion.identity);
						Coin.transform.SetParent (UICanvas.transform);
						UIManager.Instance.UiVictimMoney += money;
						GameManager.Instance.pickPocket += 1;

						picked = true;
					} else {
						Vector3 screenPos = camera.WorldToScreenPoint (transform.position);
						Image Coin = (Image)Instantiate (Money, new Vector3 (screenPos.x, screenPos.y, transform.position.z), Quaternion.identity);
						Coin.transform.SetParent (UICanvas.transform);
						UIManager.Instance.UiVictimMoney += money;
						UIManager.Instance.UpdateMoney ();

						picked = true;
					}

					victimBackFX.SetActive (false);
				} else {
					//					Debug.Log ("Why did someone touch my butt?!");
					GameManager.Instance.playerStatsScript.detectionLevel += detectionLevel;
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
