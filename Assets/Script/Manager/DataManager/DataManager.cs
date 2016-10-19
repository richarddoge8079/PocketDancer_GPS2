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
	public int DayCount;

	public void Save(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = new PlayerData ();
			data.DayCount = DayCount;

			bf.Serialize (file, data);
			file.Close ();
		} 
		else {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

			PlayerData data = new PlayerData ();
			data.DayCount = DayCount;

			bf.Serialize (file, data);
			file.Close ();
		}
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			//Setup loaded Data
			DayCount = data.DayCount;
		}
	}

	//Saving CLass
	[Serializable]
	class PlayerData{
		public int DayCount;
	}

	public void ResetData(){
		DayCount = 3;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
