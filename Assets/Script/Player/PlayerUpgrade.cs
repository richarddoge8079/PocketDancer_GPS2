using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour {

	public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;
	public bool upgrade4Active;
	public bool upgrade5Active;

	public Sprite Upgrade1Desc;
	public Sprite Upgrade2Desc;
	public Sprite Upgrade3Desc;
	public Sprite Upgrade4Desc;
	public Sprite Upgrade5Desc;

	public Animator UpgradeButton;
	public GameObject UB1;
	public GameObject UB2;
	public GameObject UB3;
	public GameObject UB4;
	public GameObject UB5;
	public GameObject lastUB;

	public Text Money;
	public float currentMoney;

	public Button upgrade1;
	public Button upgrade2;
	public Button upgrade3;

	public Image upgrade1Image;
	public Image upgrade2Image;
	public Image upgrade3Image;

	public int[] Upgrades = new int[5] {1,2,3,4,5};
	public int[] selectedUpgrades = new int[3];
	public int[] upgradePrice = new int[5] {100,200,500,50,85};

	void Start ()
	{
		/*upgrade1 = upgrade1.GetComponent<Button> ();
		upgrade2 = upgrade2.GetComponent<Button> ();
		upgrade3 = upgrade3.GetComponent<Button> ();
		upgrade1Image = upgrade1Image.GetComponent<UnityEngine.UI.Image> ();
		upgrade2Image = upgrade2Image.GetComponent<UnityEngine.UI.Image> ();
		upgrade3Image = upgrade3Image.GetComponent<UnityEngine.UI.Image> ();
		UpgradeButton = UpgradeButton.GetComponent <Animator> ();
		UB1 = UB1.GetComponent<GameObject> ();
		UB2 = UB2.GetComponent<GameObject> ();
		UB3 = UB3.GetComponent<GameObject> ();
		UB4 = UB4.GetComponent<GameObject> ();
		UB5 = UB5.GetComponent<GameObject> ();
		lastUB = lastUB.GetComponent<GameObject> ();*/

		currentMoney = DataManager.Instance.moneyCount;
		//currentMoney = 10000;

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
		Debug.Log ("game begin");
		DataManager.Instance.canMinusDay = true;
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
	}	

	void fetchLatestStat()
	{
		upgrade1Active = DataManager.Instance.upgrade1Active;
		upgrade2Active = DataManager.Instance.upgrade2Active;
		upgrade3Active = DataManager.Instance.upgrade3Active;
		upgrade4Active = DataManager.Instance.upgrade4Active;
		upgrade5Active = DataManager.Instance.upgrade5Active;
		if (DataManager.Instance.upgrade1Active == true) {
			removeFromArray (1);
		}
		if (DataManager.Instance.upgrade2Active == true) {
			removeFromArray (2);
		}
		if (DataManager.Instance.upgrade3Active == true) {
			removeFromArray (3);
		}
		if (DataManager.Instance.upgrade4Active == true) {
			removeFromArray (4);
		}
		if (DataManager.Instance.upgrade5Active == true) {
			removeFromArray (5);
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
		if (selectedUpgrades [0] == 1) {
			upgrade1Image.overrideSprite = Upgrade1Desc;
		}
		if (selectedUpgrades [0] == 2) {
			upgrade1Image.overrideSprite = Upgrade2Desc;
		}
		if (selectedUpgrades [0] == 3) {
			upgrade1Image.overrideSprite = Upgrade3Desc;
		}
		if (selectedUpgrades [0] == 4) {
			upgrade1Image.overrideSprite = Upgrade4Desc;
		}
		if (selectedUpgrades [0] == 5) {
			upgrade1Image.overrideSprite = Upgrade5Desc;
		}
	}
	void Upgrade2Sprite()
	{
		Debug.Log ("image rotation initiated");
		if (selectedUpgrades [1] == 1) {
			upgrade2Image.overrideSprite = Upgrade1Desc;
			UB5.SetActive(true);
			lastUB = UB5;
			UpgradeButton.Play ("UpgradeButton5");
		}
		if (selectedUpgrades [1] == 2) {
			upgrade2Image.overrideSprite = Upgrade2Desc;
			UB4.SetActive(true);
			lastUB = UB4;
			UpgradeButton.Play ("UpgradeButton4");
		}
		if (selectedUpgrades [1] == 3) {
			upgrade2Image.overrideSprite = Upgrade3Desc;
			UB3.SetActive(true);
			lastUB = UB3;
			UpgradeButton.Play ("UpgradeButton3");
		}
		if (selectedUpgrades [1] == 4) {
			upgrade2Image.overrideSprite = Upgrade4Desc;
			UB1.SetActive(true);
			lastUB = UB1;
			UpgradeButton.Play ("UpgradeButton1");
		}
		if (selectedUpgrades [1] == 5) {
			upgrade2Image.overrideSprite = Upgrade5Desc;
			UB2.SetActive(true);
			lastUB = UB2;
			UpgradeButton.Play ("UpgradeButton2");
		}
	}
	void Upgrade3Sprite()
	{
		Debug.Log ("image rotation initiated");
		if (selectedUpgrades [2] == 1) {
			upgrade3Image.overrideSprite = Upgrade1Desc;
		}
		if (selectedUpgrades [2] == 2) {
			upgrade3Image.overrideSprite = Upgrade2Desc;
		}
		if (selectedUpgrades [2] == 3) {
			upgrade3Image.overrideSprite = Upgrade3Desc;
		}
		if (selectedUpgrades [2] == 4) {
			upgrade3Image.overrideSprite = Upgrade4Desc;
		}
		if (selectedUpgrades [2] == 5) {
			upgrade3Image.overrideSprite = Upgrade5Desc;
		}
	}

	public void onUpgrade1Press()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESS);
		if (selectedUpgrades [0] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			lastUB.SetActive(false);
			UB5.SetActive (true);
			lastUB = UB5;
			UpgradeButton.Play ("UpgradeButton5");
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
				//upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			lastUB.SetActive(false);
			UB4.SetActive(true);
			lastUB = UB4;
			UpgradeButton.Play ("UpgradeButton4");
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				//upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			lastUB.SetActive(false);
			UB3.SetActive(true);
			lastUB = UB3;
			UpgradeButton.Play ("UpgradeButton3");
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
				//upgrade1.interactable = false;
				if(upgrade3Active == true)
				{
					DataManager.Instance.dayCount = DataManager.Instance.dayCount + 2;
				}
			}
		}
		if (selectedUpgrades [0] == 4) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			lastUB.SetActive(false);
			UB1.SetActive (true);
			lastUB = UB1;
			UpgradeButton.Play ("UpgradeButton1");
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				//upgrade1.interactable = false;	
			}
		}
		if (selectedUpgrades [0] == 5) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			lastUB.SetActive(false);
			UB2.SetActive (true);
			lastUB = UB2;
			UpgradeButton.Play ("UpgradeButton2");
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for detection meter increase
				removeFromArray (5);
				//upgrade1.interactable = false;
			}
		} else {
			Debug.Log ("You can't buy this upgrade");
		}
	}

	public void onUpgrade2Press()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESS);
		if (selectedUpgrades [1] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			lastUB.SetActive(false);
			UB5.SetActive (true);
			lastUB = UB5;
			UpgradeButton.Play ("UpgradeButton5");
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
				//upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			lastUB.SetActive(false);
			UB4.SetActive(true);
			lastUB = UB4;
			UpgradeButton.Play ("UpgradeButton4");
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				//upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			lastUB.SetActive(false);
			UB3.SetActive(true);
			lastUB = UB3;
			UpgradeButton.Play ("UpgradeButton3");
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
				//upgrade2.interactable = false;
				if(upgrade3Active == true)
				{
					DataManager.Instance.dayCount = DataManager.Instance.dayCount + 2;
				}
			}
		}
		if (selectedUpgrades [1] == 4) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			lastUB.SetActive(false);
			UB1.SetActive (true);
			lastUB = UB1;
			UpgradeButton.Play ("UpgradeButton1");
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				//upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 5) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			lastUB.SetActive(false);
			UB2.SetActive (true);
			lastUB = UB2;
			UpgradeButton.Play ("UpgradeButton2");
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for detection meter increase
				removeFromArray (5);
				//upgrade2.interactable = false;
			}
		} else {
			Debug.Log ("You can't buy this upgrade");
		}
	}

	public void onUpgrade3Press()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESS);
		if (selectedUpgrades [2] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			lastUB.SetActive(false);
			UB5.SetActive (true);
			lastUB = UB5;
			UpgradeButton.Play ("UpgradeButton5");
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
				//upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			lastUB.SetActive(false);
			UB4.SetActive(true);
			lastUB = UB4;
			UpgradeButton.Play ("UpgradeButton4");
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				//upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			lastUB.SetActive(false);
			UB3.SetActive(true);
			lastUB = UB3;
			UpgradeButton.Play ("UpgradeButton3");
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
				//upgrade3.interactable = false;
				if(upgrade3Active == true)
				{
					DataManager.Instance.dayCount = DataManager.Instance.dayCount + 2;
				}
			}
		}
		if (selectedUpgrades [2] == 4) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			lastUB.SetActive(false);
			UB1.SetActive (true);
			lastUB = UB1;
			UpgradeButton.Play ("UpgradeButton1");
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				//upgrade3.interactable = false;	
			}
		}
		if (selectedUpgrades [2] == 5) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			lastUB.SetActive(false);
			UB2.SetActive (true);
			lastUB = UB2;
			UpgradeButton.Play ("UpgradeButton2");
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for detection meter increase
				removeFromArray (5);
				//upgrade3.interactable = false;
			}
		}
		else {
			Debug.Log ("You can't buy this upgrade");
		}
	}
}

