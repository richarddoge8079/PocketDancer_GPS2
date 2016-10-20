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
			DataManager.Instance.moneyCount = GameManager.Instance.playerStatsScript.moneyCount;
			DataManager.Instance.Save ();
			if (GameManager.Instance.pickPocket > 11) {
				UIManager.Instance.GotoScene ("WinScene");
			} 
			else {
				UIManager.Instance.GotoScene("LoseScene");
			}
		}
	}
}
