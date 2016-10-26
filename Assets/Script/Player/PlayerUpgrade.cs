using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour {

	int Money;
	bool isPressed;
	public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;
	//public bool upgrade4Active;
	//public bool upgrade5Active;
	//public bool upgrade6Active;
	//public bool upgrade7Active;
	//public bool upgrade8Active;
	//public bool upgrade9Active;
	public Button upgrade1;
	public Button upgrade2;
	public Button upgrade3;
	//public Button upgrade4;
	//public Button upgrade5;
	//public Button upgrade6;
	//public Button upgrade7;
	//public Button upgrade8;
	//public Button upgrade9;

	// Use this for initialization
	void Start () {
		Money = gameObject.GetComponent<PlayerStats> ().moneyCount;
		upgrade1 = gameObject.GetComponent<Button> ();
		upgrade2 = gameObject.GetComponent<Button> ();
		upgrade3 = gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	//! something something for rotation of upgrades replacing activated ones
	}

	void activateUpgrade()
	{
		/*if (upgrade1.) {
			if(Money >= 1000)
			{
				Money -= 1000;
				upgrade1Active = true;
			}
		}
		if (upgrade2.) {
			Money -= 4000;
			upgrade2Active = true;
		}
		if (upgrade2.) {
			Money -= 500;
			upgrade3Active = true;
		}*/
	}
}
