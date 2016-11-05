using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using System;

public class PlayerUpgrade : MonoBehaviour {

	public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;
	public bool upgrade4Active;
	public bool upgrade5Active;
	public bool upgrade6Active;
	public bool upgrade7Active;
	public bool upgrade8Active;

	int currentMoney;
	//public string[] upgradeOnList = new string[3];
	//public string[] selectedUpgrade = new string[3];

	public List<string> selectedUpgrade = new List<string>();
	public List<string> upgradeOnList = new List<string>();

	public Button upgrade1;
	public Button upgrade2;
	public Button upgrade3;

	public int[] upgradePrice = new int[8] {1000, 4000, 500, 5000, 850, 500, 650, 800};
	/*public enum upgradeList
	{
		Upgrade1 = 0,
		Upgrade2,
		Upgrade3,
		Upgrade4,
		Upgrade5,
		Upgrade6,
		Upgrade7,
		Upgrade8
	};*/

	//public string[] upgradeList = new string[] {"Upgrade1", "Upgrade2", "Upgrade3", "Upgrade4", "Upgrade5", "Upgrade6", "Upgrade7", "Upgrade8"};
	public List<string> upgradeList = new List<string> {"Upgrade1", "Upgrade2", "Upgrade3", "Upgrade4", "Upgrade5", "Upgrade6", "Upgrade7", "Upgrade8"};

	//upgradeList upList = upgradeList.Upgrade1 | upgradeList.Upgrade2 | upgradeList.Upgrade3 | upgradeList.Upgrade4 | upgradeList.Upgrade5 | upgradeList.Upgrade6 | upgradeList.Upgrade7 | upgradeList.Upgrade8;

	/*static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}*/


	// Use this for initialization
	void Start () {
		currentMoney = gameObject.GetComponent<PlayerStats> ().moneyCount;
		upgrade1 = gameObject.GetComponent<Button> ();
		upgrade2 = gameObject.GetComponent<Button> ();
		upgrade3 = gameObject.GetComponent<Button> ();
	}

	// Update is called once per frame
	void Update () {
		UpgradeRotation ();
	}

	List<string> UpgradeRotation()
	{
		Debug.Log ("rotation begin");
		for (int i = 0; i < 3; i++) {
			selectedUpgrade [i] = upgradeList [Random.Range (0, upgradeList.Count)];
			upgradeOnList [i] = selectedUpgrade [i];
			if (selectedUpgrade[0] != selectedUpgrade[1] && selectedUpgrade[0] != selectedUpgrade[2]) {
				upgradeOnList [0] = selectedUpgrade[0];
			}
			if (selectedUpgrade[1] != selectedUpgrade[0] && selectedUpgrade[1] != selectedUpgrade[2]) {
				upgradeOnList [1] = selectedUpgrade[1];
			}
			if (selectedUpgrade[2] != selectedUpgrade[0] && selectedUpgrade[2] != selectedUpgrade[1]) {
				upgradeOnList [2] = selectedUpgrade[2];
			}
		}
		Debug.Log ("rotation finished");
		return upgradeOnList;
	}

	/*public void onUpgrade1Press()
	{
		if (upgradeOnList [0] == 0) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				//upList &= ~upgradeList.Upgrade1;

			}
		}
		if (upgradeOnList [0] == 1) {
			// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
			if (currentMoney >= upgradePrice [1]) {
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				//code for all direction pickpocket
				upList &= ~upgradeList.Upgrade2;
			}
		}
		if (upgradeOnList [0] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [2]) {
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				upList &= ~upgradeList.Upgrade3;
			}
		}
		if (upgradeOnList [0] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [3]) {
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				//code for additional days
				upList &= ~upgradeList.Upgrade4;
			}
		}
		if (upgradeOnList [0] == 4) {
			// DJ Bribe (Consumable for repeating song in the level)
			if (currentMoney >= upgradePrice [4]) {
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				//code for consumables addition
				//upList &= ~upgradeList.Upgrade5;
			}
		}
		if (upgradeOnList [0] == 5) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [5]) {
				currentMoney -= upgradePrice [5];
				upgrade6Active = true;
				//code for detection meter increase
				upList &= ~upgradeList.Upgrade6;
			}
		}
		if (upgradeOnList [0] == 6) {
			// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
			if (currentMoney >= upgradePrice [6]) {
				currentMoney -= upgradePrice [6];
				upgrade7Active = true;
				//code for minimum cash increase
				upList &= ~upgradeList.Upgrade7;
			}
		}
		if (upgradeOnList [0] == 7) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time)
			if (currentMoney >= upgradePrice [7]) {
				currentMoney -= upgradePrice [7];
				upgrade8Active = true;
				//code for Detected HP increase
				upList &= ~upgradeList.Upgrade8;
			}
		}
	}

	public void onUpgrade2Press()
	{
		if (upgradeOnList [1] == 0) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				upList &= ~upgradeList.Upgrade1;
			}
		}
		if (upgradeOnList [1] == 1) {
			// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
			if (currentMoney >= upgradePrice [1]) {
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				//code for all direction pickpocket
				upList &= ~upgradeList.Upgrade2;
			}
		}
		if (upgradeOnList [1] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [2]) {
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				upList &= ~upgradeList.Upgrade3;
			}
		}
		if (upgradeOnList [1] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [3]) {
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				//code for additional days
				upList &= ~upgradeList.Upgrade4;
			}
		}
		if (upgradeOnList [1] == 4) {
			// DJ Bribe (Consumable for repeating song in the level)
			if (currentMoney >= upgradePrice [4]) {
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				//code for consumables addition
				//upList &= ~upgradeList.Upgrade5;
			}
		}
		if (upgradeOnList [1] == 5) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [5]) {
				currentMoney -= upgradePrice [5];
				upgrade6Active = true;
				//code for detection meter increase
				upList &= ~upgradeList.Upgrade6;
			}
		}
		if (upgradeOnList [1] == 6) {
			// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
			if (currentMoney >= upgradePrice [6]) {
				currentMoney -= upgradePrice [6];
				upgrade7Active = true;
				//code for minimum cash increase
				upList &= ~upgradeList.Upgrade7;
			}
		}
		if (upgradeOnList [1] == 7) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time)
			if (currentMoney >= upgradePrice [7]) {
				currentMoney -= upgradePrice [7];
				upgrade8Active = true;
				//code for Detected HP increase
				upList &= ~upgradeList.Upgrade8;
			}
		}
	}

	public void onUpgrade3Press()
	{
		if (upgradeOnList [2] == 0) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				upList &= ~upgradeList.Upgrade1;
			}
		}
		if (upgradeOnList [2] == 1) {
			// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
			if (currentMoney >= upgradePrice [1]) {
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				//code for all direction pickpocket
				upList &= ~upgradeList.Upgrade2;
			}
		}
		if (upgradeOnList [2] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [2]) {
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				upList &= ~upgradeList.Upgrade3;
			}
		}
		if (upgradeOnList [2] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [3]) {
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				//code for additional days
				upList &= ~upgradeList.Upgrade4;
			}
		}
		if (upgradeOnList [2] == 4) {
			// DJ Bribe (Consumable for repeating song in the level)
			if (currentMoney >= upgradePrice [4]) {
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				//code for consumables addition
				//upList &= ~upgradeList.Upgrade5;
			}
		}
		if (upgradeOnList [2] == 5) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [5]) {
				currentMoney -= upgradePrice [5];
				upgrade6Active = true;
				//code for detection meter increase
				upList &= ~upgradeList.Upgrade6;
			}
		}
		if (upgradeOnList [2] == 6) {
			// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
			if (currentMoney >= upgradePrice [6]) {
				currentMoney -= upgradePrice [6];
				upgrade7Active = true;
				//code for minimum cash increase
				upList &= ~upgradeList.Upgrade7;
			}
		}
		if (upgradeOnList [2] == 7) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time)
			if (currentMoney >= upgradePrice [7]) {
				currentMoney -= upgradePrice [7];
				upgrade8Active = true;
				//code for Detected HP increase
				upList &= ~upgradeList.Upgrade8;
			}
		}
	}*/
}

// For upgrade reference sake
/*case 0:
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
					*/