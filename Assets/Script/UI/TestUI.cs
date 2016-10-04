using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestUI : MonoBehaviour {

	public Text moneyText;
	public Text detectionText;
	public Slider DetectionBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money : " + GameManager.Instance.playerStatsScript.moneyCount;
		detectionText.text = "Detection Level : " + GameManager.Instance.playerStatsScript.detectionLevel + "%";
		DetectionBar.value = GameManager.Instance.playerStatsScript.detectionLevel;
	}
}
