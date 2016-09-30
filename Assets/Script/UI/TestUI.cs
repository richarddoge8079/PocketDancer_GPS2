using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestUI : MonoBehaviour {

	public Text moneyText;
	public Text detectionText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money : " + GameManager.Instance.playerStatsScript.moneyCount;
		detectionText.text = "Detection Level : " + GameManager.Instance.playerStatsScript.detectionLevel + "%";
	}
}
