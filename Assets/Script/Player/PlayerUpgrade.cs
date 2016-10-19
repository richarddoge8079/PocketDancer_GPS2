using UnityEngine;
using System.Collections;

public class PlayerUpgrade : MonoBehaviour {

	int Money;
	public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;

	// Use this for initialization
	void Start () {
		Money = gameObject.GetComponent<PlayerStats> ().moneyCount;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
