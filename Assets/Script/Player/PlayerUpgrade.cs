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

	public Sprite Upgrade1;
	public Sprite Upgrade2;
	public Sprite Upgrade3;
	public Sprite Upgrade4;
	public Sprite Upgrade5;

	public Text Money;
	public float currentMoney;
	public Text Day;
	public int days;

	public Button upgrade1;
	public Button upgrade2;
	public Button upgrade3;

	public Image upgrade1Image;
	public Image upgrade2Image;
	public Image upgrade3Image;

	public int[] Upgrades = new int[5] {1,2,3,4,5};
	public int[] selectedUpgrades = new int[3];
	public int[] upgradePrice = new int[5] {100,200,500,50,85};

	/*int[] weights;
	int weightTotal;

	struct upgrades { //this is just for code-read niceness
		public const int suitNTie = 1;
		public const int funkyFreshOutfit = 2;
		public const int loanExtension = 3;
		public const int dazzlerStrips = 4;
		public const int crashCourseTaiChi = 5;
	}

	int RandomWeighted () {
		int result = 0, total = 0;
		int randVal = Random.Range( 0, weightTotal );
		for ( result = 0; result < weights.Length; result++ ) {
			total += weights[result];
			if ( total > randVal ) break;
		}
		return result;
	}*/

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
		//probabilitySelection ();
		Debug.Log ("game start");
		Upgrade1Sprite ();
		Upgrade2Sprite ();
		Upgrade3Sprite ();

		/*weights = new int[5]; //number of things

		//weighting of each thing, high number means more occurrance
		weights[upgrades.suitNTie] = 35;
		weights[upgrades.funkyFreshOutfit] = 45;
		weights[upgrades.loanExtension] = 5;
		weights[upgrades.dazzlerStrips] = 10;
		weights[upgrades.crashCourseTaiChi] = 5;

		weightTotal = 100;
		foreach ( int w in weights ) {
			weightTotal += w;
		}*/
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("game begin");
		currentMoney = DataManager.Instance.moneyCount;
		//currentMoney = 10000;
		upgrade1 = upgrade1.GetComponent<Button> ();
		upgrade2 = upgrade2.GetComponent<Button> ();
		upgrade3 = upgrade3.GetComponent<Button> ();
		upgrade1Image = upgrade1Image.GetComponent<UnityEngine.UI.Image> ();
		upgrade2Image = upgrade2Image.GetComponent<UnityEngine.UI.Image> ();
		upgrade3Image = upgrade3Image.GetComponent<UnityEngine.UI.Image> ();
		days = DataManager.Instance.dayCount;

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
		if (Day != null)
		{
			Day.text = "Day(s) left: " + days;
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
			upgrade1Image.overrideSprite = Upgrade1;
		}
		if (selectedUpgrades [0] == 2) {
			upgrade1Image.overrideSprite = Upgrade2;
		}
		if (selectedUpgrades [0] == 3) {
			upgrade1Image.overrideSprite = Upgrade3;
		}
		if (selectedUpgrades [0] == 4) {
			upgrade1Image.overrideSprite = Upgrade4;
		}
		if (selectedUpgrades [0] == 5) {
			upgrade1Image.overrideSprite = Upgrade5;
		}
	}
	void Upgrade2Sprite()
	{
		Debug.Log ("image rotation initiated");
		if (selectedUpgrades [1] == 1) {
			upgrade2Image.overrideSprite = Upgrade1;
		}
		if (selectedUpgrades [1] == 2) {
			upgrade2Image.overrideSprite = Upgrade2;
		}
		if (selectedUpgrades [1] == 3) {
			upgrade2Image.overrideSprite = Upgrade3;
		}
		if (selectedUpgrades [1] == 4) {
			upgrade2Image.overrideSprite = Upgrade4;
		}
		if (selectedUpgrades [1] == 5) {
			upgrade2Image.overrideSprite = Upgrade5;
		}
	}
	void Upgrade3Sprite()
	{
		Debug.Log ("image rotation initiated");
		if (selectedUpgrades [2] == 1) {
			upgrade3Image.overrideSprite = Upgrade1;
		}
		if (selectedUpgrades [2] == 2) {
			upgrade3Image.overrideSprite = Upgrade2;
		}
		if (selectedUpgrades [2] == 3) {
			upgrade3Image.overrideSprite = Upgrade3;
		}
		if (selectedUpgrades [2] == 4) {
			upgrade3Image.overrideSprite = Upgrade4;
		}
		if (selectedUpgrades [2] == 5) {
			upgrade3Image.overrideSprite = Upgrade5;
		}
	}

	public void onUpgrade1Press()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESS);
		if (selectedUpgrades [0] == 1) {
			// Suit & Tie (Enter VIP section without being insta-detect)
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
				upgrade1.interactable = false;
			}
		}
		if (selectedUpgrades [0] == 4) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				upgrade1.interactable = false;

				if(upgrade4Active == true)
				{
					DataManager.Instance.dayCount = DataManager.Instance.dayCount + 2;
				}	
			}
		}
		if (selectedUpgrades [0] == 5) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for detection meter increase
				removeFromArray (5);
				upgrade1.interactable = false;
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
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
				upgrade2.interactable = false;
			}
		}
		if (selectedUpgrades [1] == 4) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				upgrade2.interactable = false;

				if(upgrade4Active == true)
				{
					DataManager.Instance.dayCount = DataManager.Instance.dayCount + 2;
				}	
			}
		}
		if (selectedUpgrades [1] == 5) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for detection meter increase
				removeFromArray (5);
				upgrade2.interactable = false;
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
			if (currentMoney >= upgradePrice [0]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [0];
				upgrade1Active = true;
				//code for VIP section
				removeFromArray(1);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 2) {
			// Funky Fresh Outfit (Access Nightclub level)
			if (currentMoney >= upgradePrice [1]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [1];
				upgrade2Active = true;
				DataManager.Instance.upgrade2Active = true;
				//code for all direction pickpocket
				removeFromArray (2);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 3) {
			// A Loan Extension (One time purchase of 2 day extension)
			if (currentMoney >= upgradePrice [2]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [2];
				upgrade3Active = true;
				//code Nightclub level access?
				removeFromArray(3);
				upgrade3.interactable = false;
			}
		}
		if (selectedUpgrades [2] == 4) {
			// Dazzler Strips (Increase Maximum Detection Meter by 5)
			if (currentMoney >= upgradePrice [3]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [3];
				upgrade4Active = true;
				DataManager.Instance.upgrade4Active = true;
				//code for additional days
				removeFromArray (4);
				upgrade3.interactable = false;

				if(upgrade4Active == true)
				{
					DataManager.Instance.dayCount = DataManager.Instance.dayCount + 2;
				}	
			}
		}
		if (selectedUpgrades [2] == 5) {
			// Crash Course in Tai Chi (HP increase by 1 during detected stage/Can be bump by NPC 1 more time
			if (currentMoney >= upgradePrice [4]) {
				Debug.Log ("upgrade purchased");
				currentMoney -= upgradePrice [4];
				upgrade5Active = true;
				DataManager.Instance.upgrade5Active = true;
				//code for detection meter increase
				removeFromArray (5);
				upgrade3.interactable = false;
			}
		} else {
			Debug.Log ("You can't buy this upgrade");
		}
	}

	public void UpdateDays()
	{
		//		DataManager.Instance.dayCount -= 1;
		DataManager.Instance.moneyCount = currentMoney;
	}

	/*void probabilitySelection()
	{
		float rdm1 = Random.value;
		float rdm2 = Random.value;
		float rdm3 = Random.value;
		if(rdm1 >= 0.35)
		{
			Debug.Log ("rdm1: " + 1);
		}
		else if(rdm1 >= 0.45)
		{
			Debug.Log ("rdm1: " + 2);
		}
		else if(rdm1 >= 0.05)
		{
			Debug.Log ("rdm1: " + 3);
		}
		else if(rdm1 >= 0.1)
		{
			Debug.Log ("rdm1: " + 4);
		}
		else if(rdm1 >= 0.05)
		{
			Debug.Log ("rdm1: " + 5);
		}

		if(rdm2 >= 0.35 && rdm2 != rdm1)
		{
			Debug.Log ("rdm2: " + 1);
		}
		else if(rdm2 >= 0.45 && rdm2 != rdm1)
		{
			Debug.Log ("rdm2: " + 2);
		}
		else if(rdm2 >= 0.05 && rdm2 != rdm1)
		{
			Debug.Log ("rdm2: " + 3);
		}
		else if(rdm2 >= 0.1 && rdm2 != rdm1)
		{
			Debug.Log ("rdm2: " + 4);
		}
		else if(rdm2 >= 0.05 && rdm2 != rdm1)
		{
			Debug.Log ("rdm2: " + 5);
		}

		if(rdm3 >= 0.35 && rdm3 != rdm1 && rdm3 != rdm2)
		{
			Debug.Log ("rdm3: " + 1);
		}
		else if(rdm3 >= 0.45 && rdm3 != rdm1 && rdm3 != rdm2)
		{
			Debug.Log ("rdm3: " + 2);
		}
		else if(rdm3 >= 0.05 && rdm3 != rdm1 && rdm3 != rdm2)
		{
			Debug.Log ("rdm3: " + 3);
		}
		else if(rdm3 >= 0.1 && rdm3 != rdm1 && rdm3 != rdm2)
		{
			Debug.Log ("rdm3: " + 4);
		}
		else if(rdm3 >= 0.05 && rdm3 != rdm1 && rdm3 != rdm2)
		{
			Debug.Log ("rdm3: " + 5);
		}
	}*/
}
