using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetStolenMoney : MonoBehaviour {

	public Text stolenMoneyText;

	// Use this for initialization
	void Start () {
		stolenMoneyText.text = DataManager.Instance.stolenMoney.ToString ();
		DataManager.Instance.stolenMoney = 0;
	}
}
