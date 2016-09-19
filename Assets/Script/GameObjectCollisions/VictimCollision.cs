using UnityEngine;
using System.Collections;

public class VictimCollision : MonoBehaviour {
	public float pickpocketRange;
	public bool playerInRange = false;
	public bool picked = false;
	public int maxMoney;
	public int minMoney;
	public int money;
	RaycastHit isPickpocketed;
	// Use this for initialization

	// Update is called once per frame
	void Update ()
	{
		Ray pickpocketRay = new Ray (transform.position, Vector3.back);
		if (Physics.Raycast (pickpocketRay, out isPickpocketed, pickpocketRange)) 
		{
			if (isPickpocketed.collider.tag == "Player") 
			{
				playerInRange = true;
				Debug.Log ("Target In Range");
			} 
			else if(isPickpocketed.collider.tag != "Player")
			{
				playerInRange = false;
				Debug.Log ("Target Lost");
			}
		}
	}
	void OnTriggerEnter (Collider coll)
	{
		if(coll.CompareTag("Player"))
		{
			if (!picked) 
			{
				if (playerInRange == true) 
				{
					Debug.Log ("I've just been robbed!?");
					money = Random.Range (minMoney,maxMoney);
					picked = true;
				}
			} 
			else 
			{
				if (playerInRange == true) 
				{
					Debug.Log ("Why did someone touch my butt?!");
				}	
			}
		}

	}
}

