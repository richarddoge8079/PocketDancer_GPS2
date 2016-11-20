using UnityEngine;
using System.Collections;

public class VIPRegion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Player")){
			UIManager.Instance.TriggerUI ("VIP Zone");
		}
	}

	void OnTriggerExit(Collider coll){
		if(coll.CompareTag("Player")){
			UIManager.Instance.TriggerUI ("Normal Zone");
		}
	}
}
