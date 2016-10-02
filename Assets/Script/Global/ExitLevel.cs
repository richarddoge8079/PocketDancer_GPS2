using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Player")){
//			GameManager.Instance.RestartLevel ();
			UIManager.Instance.GotoScene("MainMenu");
		}
	}
}
