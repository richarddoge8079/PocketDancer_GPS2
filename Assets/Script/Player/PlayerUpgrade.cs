using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour {

	public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;
	public bool upgrade4Active;
	public bool upgrade5Active;
	public bool upgrade6Active;
	public bool upgrade7Active;
	public bool upgrade8Active;

	public Sprite Upgrade1;
	public Sprite Upgrade2;
	public Sprite Upgrade3;
	public Sprite Upgrade4;
	public Sprite Upgrade5;
	public Sprite Upgrade6;
	public Sprite Upgrade7;
	public Sprite Upgrade8;

	public Text Money;
	public float currentMoney;
	public Text Day;

	public Button upgrade1;
	public Button upgrade2;
	public Button upgrade3;

	public Image upgrade1Image;
	public Image upgrade2Image;
	public Image upgrade3Image;

	//public int[] Upgrades = new int[8] {1,2,3,4,5,6,7,8};
	public int[] Upgrades = new int[6] {2,4,5,6,7,8};
	public int[] selectedUpgrades = new int[3];
	//public int[] upgradePrice = new int[8] {1000, 4000, 500, 5000, 850, 500, 650, 800};
	public int[] upgradePrice = new int[6] {400, 500, 85, 50, 65, 80};
	//public Sprite[] upgradeImages = new Sprite[6];

	// Use this for initialization
	void Start () {
		Debug.Log ("game begin");
		//currentMoney = gameObject.GetComponent<PlayerStats> ().moneyCount;
		//currentMoney = DataManager.Instance.moneyCount;
		currentMoney = 10000;
		upgrade1 = upgrade1.GetComponent<Button> ();
		upgrade2 = upgrade2.GetComponent<Button> ();
		upgrade3 = upgrade3.GetComponent<Button> ();
		upgrade1Image = upgrade1Image.GetComponent<UnityEngine.UI.Image> ();
		upgrade2Image = upgrade2Image.GetComponent<UnityEngine.UI.Image> ();
		upgrade3Image = upgrade3Image.GetComponent<UnityEngine.UI.Image> ();

	}

	void Awake()
	{
		Debug.Log ("game loop");
		fetchLatestStat ();
		reshuffle (Upgrades);
		for (int i = 0; i < selectedUpgrades.Length; i++) {
			for (int j = 0; j < Upgrades.Length; j++) {
				selectedUpgrades [i] = Upgrades [j];
				j++;
				i++;
			}
		}
		Debug.Log ("game start");
		Upgrade1Sprite ();
		Upgrade2Sprite ();
		Upgrade3Sprite ();
	}

	void reshuffle(int[] upgrade)
	{
		Debug.Log ("shuffle start");
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int i = 0; i < upgrade.Length; i++ )
		{
			int tmp = upgrade[i];
			int r = UnityEngine.Random.Range(i, upgrade.Length);
			upgrade[i] = upgrade[r];
			upgrade[r] = tmp;
		}
		Debug.Log ("shuffle end");
	}

	// Update is called once per frame
	void Update () 
	{
		if (Money != null) 
		{
			Money.text = "$ " + currentMoney;
		}

		Day.text = "Day(s) left: " + DataManager.Instance.dayCount;	
	}	

	void fetchLatestStat()
	{
		upgrade1Active = DataManager.Instance.upgrade1Active;
		upgrade2Active = DataManager.Instance.upgrade2Active;
		upgrade3Active = DataManager.Instance.upgrade3Active;
		upgrade4Active = DataManager.Instance.upgrade4Active;
		upgrade5Active = DataManager.Instance.upgrade5Active;
		upgrade6Active = DataManager.Instance.upgrade6Active;
		upgrade7Active = DataManager.Instance.upgrade7Active;
		upgrade8Active = DataManager.Instance.upgrade8Active;
		if (DataManager.Instance.upgrade2Active == true) {
			removeFromArray (2);
		}
		if (DataManager.Instance.upgrade4Active == true) {
			removeFromArray (4);
		}
		if (DataManager.Instance.upgrade5Active == true) {
			removeFromArray (5);
		}
		if (DataManager.Instance.upgrade6Active == true) {
			removeFromArray (6);
		}
		if (DataManager.Instance.upgrade7Active == true) {
			removeFromArray (7);
		}
		if (DataManager.Instance.upgrade8Active == true) {
			removeFromArray (8);
		}
	}

	void removeFromArray(int i)
	{
		var list = new List<int> (Upgrades);
		list.Remove (i);
		Upgrades = list.ToArray();
	}

	void Upgrade1Sprite()
	{
		Debug.Log ("image rotation initiated");
		/*if (selectedUpgrades [0] == 1) {
			upgrade1Image.overrideSprite = Upgrade1;
		}*/
		if (selectedUpgrades [0] == 2) {
			upgrade1Image.overrideSprite = Upgrade2;
		}
		/*if (selectedUpgrades [0] == 3) {
			upgrade1Image.overrideSprite = Upgrade3;
		}*/
		if (selectedUpgrades [0] == 4) {
			upgrade1Image.overrideSprite = Upgrade4;
		}
		if (selectedUpgrades [0] == 5) {
			upgrade1Image.overrideSprite = Upgrade5;
		}
		if (selectedUpgrades [0] == 6) {
			upgrade1Image.overrideSprite = Upgrade6;
		}
		if (selectedUpgrades [0] == 7) {
			upgrade1Image.overrideSprite = Upgrade7;
		}
		if (selectedUpgrades [0] == 8) {
			upgrade1Image.overrideSprite = Upgrade8;
		}
	}
	void Upgrade2Sprite()
	{
		Debug.Log ("image rotation initiated");
		/*if (selectedUpgrades [1] == 1) {
			upgrade2Image.overrideSprite = Upgrade1;
		}*/
		if (selectedUpgrades [1] == 2) {
			upgrade2Image.overrideSprite = Upgrade2;
		}
		/*if (selectedUpgrades [1] == 3) {
			upgrade2Image.overrideSprite = Upgrade3;
		}*/
		if (selectedUpgrades [1] == 4) {
			upgrade2Image.overrideSprite = Upgrade4;
		}
		if (selectedUpgrades [1] == 5) {
			upgrade2Image.overrideSprite = Upgrade5;
		}
		if (selectedUpgrades [1] == 6) {
			upgrade2Image.overrideSprite = Upgrade6;
		}
		if (selectedUpgrades [1] == 7) {
			upgrade2Image.overrideSprite = Upgrade7;
		}
		if (selectedUpgrades [1] == 8) {
			upgrade2Image.overrideSprite = Upgrade8;
		}
	}
	void Upgrade3Sprite()
	{
		Debug.Log ("image rotation initiated");
		/*if (selectedUpgrades [2] == 1) {
			upgrade3Image.overrideSprite = Upgrade1;
		}*/
		if (selectedUpgrades [2] == 2) {
			upgrade3Image.overrideSprite = Upgrade2;
		}
		/*if (selectedUpgrades [2] == 3) {
			upgrade3Image.overrideSprite = Upgrade3;
		}*/
		if (selectedUpgrades [2] == 4) {
			upgrade3Image.overrideSprite = Upgrade4;
		}
		if (selectedUpgrades [2] == 5) {
			upgrade3Image.overrideSprite = Upgrade5;
		}
		if (selectedUpgrades [2] == 6) {
			upgrade3Image.overrideSprite = Upgrade6;
		}
		if (selectedUpgrades [2] == 7) {
			upgrade3Image.overrideSprite = Upgrade7;
		}
		if (selectedUpgrades [2] == 8) {
			upgrade3Image.overrideSprite = Upgrade8;
		}
	}

	public void onUpgrade1Press()
	{
		/*if (selectedUpgrades [0] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
			}
		}*/
		if (selectedUpgrades [0] == 2) {
			// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				upgrade1.interactable = false;
			}
		}
		/*if (selectedUpgrades [0] == 3) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
			}
		}*/
		if (selectedUpgrades [0] == 4) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 5) {
			// DJ Bribe (Consumable for repeating song in the level)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for consumables addition
				removeFromArray (5);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 6) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade6Active = true;
				DataManager.Instance.upgrade6Active = true;
				//code for detection meter increase
				removeFromArray (6);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 7) {
			// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade7Active = true;
				DataManager.Instance.upgrade7Active = true;
				//code for minimum cash increase
				removeFromArray (7);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 8) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			if (currentMoney >= upgradePrice [5]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [5];
				upgrade8Active = true;
				DataManager.Instance.upgrade8Active = true;
				//code for Detected HP increase
				removeFromArray (8);
				upgrade1.interactable = false;
			}
		} else {
			Debug.Log ("You can't buy this upgrade");
		}
	}
	public void onUpgrade2Press()
	{
		/*if (selectedUpgrades [1] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
			}
		}*/
		if (selectedUpgrades [1] == 2) {
			// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				upgrade2.interactable = false;
			}
		}
		/*if (selectedUpgrades [1] == 3) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
			}
		}*/
		if (selectedUpgrades [1] == 4) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 5) {
			// DJ Bribe (Consumable for repeating song in the level)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for consumables addition
				removeFromArray (5);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 6) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade6Active = true;
				DataManager.Instance.upgrade6Active = true;
				//code for detection meter increase
				removeFromArray (6);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 7) {
			// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade7Active = true;
				DataManager.Instance.upgrade7Active = true;
				//code for minimum cash increase
				removeFromArray (7);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 8) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time)
			if (currentMoney >= upgradePrice [5]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [5];
				upgrade8Active = true;
				DataManager.Instance.upgrade8Active = true;
				//code for Detected HP increase
				removeFromArray (8);
				upgrade2.interactable = false;
			}
		} else {
			Debug.Log ("You can't buy this upgrade");
		}
	}
	public void onUpgrade3Press()
	{
		/*if (selectedUpgrades [2] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
			}
		}*/
		if (selectedUpgrades [2] == 2) {
			// Slippery Fingers 101: A Guide to Pickpocket (Pickpocket from all sides with 25% penalty from sides and 50% in front)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				upgrade3.interactable = false;
			}
		}
		/*if (selectedUpgrades [2] == 3) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
			}
		}*/
		if (selectedUpgrades [2] == 4) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 5) {
			// DJ Bribe (Consumable for repeating song in the level)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for consumables addition
				removeFromArray (5);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 6) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade6Active = true;
				DataManager.Instance.upgrade6Active = true;
				//code for detection meter increase
				removeFromArray (6);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 7) {
			// Plastic Finger Extension (Raise minimum cash per pickpocket by 20)
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade7Active = true;
				DataManager.Instance.upgrade7Active = true;
				//code for minimum cash increase
				removeFromArray (7);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 8) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time)
			if (currentMoney >= upgradePrice [5]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [5];
				upgrade8Active = true;
				DataManager.Instance.upgrade8Active = true;
				//code for Detected HP increase
				removeFromArray (8);
				upgrade3.interactable = false;
			}
		} else {
			Debug.Log ("You can't buy this upgrade");
		}
	}
	
	public void UpdateDays()
	{
		DataManager.Instance.dayCount -= 1;
		DataManager.Instance.moneyCount = currentMoney;
	}
}