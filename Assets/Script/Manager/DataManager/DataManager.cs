using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour {
	
	private static DataManager mInstance;

	public static DataManager Instance{
		get{
			if(mInstance == null){
				GameObject tempObject = GameObject.FindGameObjectWithTag ("DataManager");

				if (tempObject == null) {
					GameObject obj = new GameObject ("DataManager");
					obj.tag = "DataManager";
					mInstance = obj.AddComponent<DataManager> ();
				} 
				else {
					mInstance = tempObject.GetComponent<DataManager> ();
				}

			}
			return mInstance;
		}
	}

	//Variable
	public int dayCount;
	public float moneyCount;

	public string sceneName;

	//Upgrades
	public PlayerUpgrade playerUpgradeScript;

	public bool upgrade1Active;
	public bool upgrade2Active;
	public bool upgrade3Active;
	public bool upgrade4Active;
	public bool upgrade5Active;
	public bool upgrade6Active;
	public bool upgrade7Active;
	public bool upgrade8Active;

	public void Save(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
//			File.Delete (Application.persistentDataPath + "/playerInfo.dat");
//			FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = new PlayerData ();
			data.dayCount = dayCount;
			data.moneyCount = moneyCount;

			data.upgrade1Active = upgrade1Active;
			data.upgrade2Active = upgrade2Active;
			data.upgrade3Active = upgrade3Active;
			data.upgrade4Active = upgrade4Active;
			data.upgrade5Active = upgrade5Active;
			data.upgrade6Active = upgrade6Active;
			data.upgrade7Active = upgrade7Active;
			data.upgrade8Active = upgrade8Active;

			bf.Serialize (file, data);
			file.Close ();
		} 
		else {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

			PlayerData data = new PlayerData ();
			data.dayCount = dayCount;
			data.moneyCount = moneyCount;

			data.upgrade1Active = upgrade1Active;
			data.upgrade2Active = upgrade2Active;
			data.upgrade3Active = upgrade3Active;
			data.upgrade4Active = upgrade4Active;
			data.upgrade5Active = upgrade5Active;
			data.upgrade6Active = upgrade6Active;
			data.upgrade7Active = upgrade7Active;
			data.upgrade8Active = upgrade8Active;

			bf.Serialize (file, data);
			file.Close ();
		}
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);

			//Setup loaded Data
			dayCount = data.dayCount;
			moneyCount = data.moneyCount;

			upgrade1Active = data.upgrade1Active;
			upgrade2Active = data.upgrade2Active;
			upgrade3Active = data.upgrade3Active;
			upgrade4Active = data.upgrade4Active;
			upgrade5Active = data.upgrade5Active;
			upgrade6Active = data.upgrade6Active;
			upgrade7Active = data.upgrade7Active;
			upgrade8Active = data.upgrade8Active;

			file.Close ();
		}
	}

	//Saving CLass
	[Serializable]
	class PlayerData{
		public int dayCount;
		public float moneyCount;

		public bool upgrade1Active;
		public bool upgrade2Active;
		public bool upgrade3Active;
		public bool upgrade4Active;
		public bool upgrade5Active;
		public bool upgrade6Active;
		public bool upgrade7Active;
		public bool upgrade8Active;
	}

	public void ResetData(){
		dayCount = 3;
		moneyCount = 340;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
