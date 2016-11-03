using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour {

	int currentMoney;
	int upgradePrice;

	/*public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;
	public bool upgrade4Active;
	public bool upgrade5Active;
	public bool upgrade6Active;
	public bool upgrade7Active;
	public bool upgrade8Active;
	public bool upgrade9Active;*/

	//public bool[] upgradeActiveList;

	public Button upgrade1;
	public Button upgrade2;
	public Button upgrade3;

	int[] upgradeList;


	// Use this for initialization
	void Start () {
		currentMoney = gameObject.GetComponent<PlayerStats> ().moneyCount;
		upgradeList = new int[3];
		//upgradeActiveList = new bool[8];
		upgrade1 = gameObject.GetComponent<Button> ();
		upgrade2 = gameObject.GetComponent<Button> ();
		upgrade3 = gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		//! something something for rotation of upgrades replacing activated ones
		for (int i = 0; i < upgradeList.Length; i++) {
			if (currentMoney != 0) {
				int selectedUpgrade;
				selectedUpgrade = Random.Range (0, 7);
				switch (selectedUpgrade) {
				case 0:
					// Suit & Tie (Enter VIP section without being insta-detect)
					upgradePrice = 1000;
					//(placeholder)
					//upgrade1Active = true;
					break;

				case 1:
					// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
					upgradePrice = 4000;
					//(placeholder)
					//upgrade2Active = true;
					break;

				case 2:
					// Funky Fresh Outfit (Access Nightclub level)
					upgradePrice = 500;
					//(placeholder) LevelAccessible = true;
					//upgrade3Active = true;
					break;

				case 3:
					// A Loan Extension (One time purchase of 2 day extension)
					upgradePrice = 5000;
					//(placeholder) dayRemaining += 2;
					//upgrade4Active = true;
					break;

				case 4:
					// DJ Bribe (Consumable for repeating song in the level)
					upgradePrice = 850;
					//(placeholder) songRepeat += 1;
					//upgrade5Active = true;
					break;

				case 5:
					// Dazzler Strips (Increase Maximum Detection Meter by 5)
					upgradePrice = 500;
					//(placeholder) detectionMeter += 5f;
					//upgrade6Active = true;
					break;

				case 6:
					// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
					upgradePrice = 650;
					//(placeholder) cash += 20;
					//upgrade7Active = true;
					break;

				case 7:
					// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time)
					upgradePrice = 800;
					//(placeholder) hp += 1;
					//upgrade8Active = true;
					break;
				}
				upgradeList [i] = selectedUpgrade;
			}
		}
	}

	public void upgrade1Press()
	{
		for (int i = 0; i < upgradeList.Length; i++) {
			if (currentMoney >= upgradeList [i].upgradePrice) {
				currentMoney -= upgradePrice;
			}
		}
	}
}
