using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Player")){
			//			GameManager.Instance.RestartLevel ();
			DataManager.Instance.moneyCount += GameManager.Instance.playerStatsScript.moneyCount;
			DataManager.Instance.stolenMoney = 0;
			DataManager.Instance.Save ();
			DataManager.Instance.MinusDay ();
//			if (GameManager.Instance.pickPocket > 11) {
//				UIManager.Instance.GotoScene ("WinScene");
//			} 
//			else {
//				UIManager.Instance.GotoScene("LoseScene");
//			}
			//Win
			if (DataManager.Instance.moneyCount >= 2500) {
				UIManager.Instance.GotoScene ("WinScene");
			} 
			//Lose
			else if(DataManager.Instance.dayCount <= 0){
				UIManager.Instance.GotoScene ("LoseScene");
			}
			// COntinue Level
			else {
				UIManager.Instance.GotoScene(sceneName);
			}
//			SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
			this.gameObject.SetActive(false);
		}
	}
}
