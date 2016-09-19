using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BeatsManager : MonoBehaviour {

	private static BeatsManager mInstance;

	public static BeatsManager Instance{
		get{
			if(mInstance == null){
				GameObject tempObject = GameObject.FindGameObjectWithTag ("BeatsManager");

				if (tempObject == null) {
					GameObject obj = new GameObject ("BeatsManager");
					obj.tag = "BeatsManager";
					mInstance = obj.AddComponent<BeatsManager> ();
				} 
				else {
					mInstance = tempObject.GetComponent<BeatsManager> ();
				}

			}
			return mInstance;
		}
	}

	public float MusicTimer;
	public float beatTimer;
	public float startBeatTimer;
	public bool onBeat;

	public float TimerCount;
	public float timerCount2;

	public bool startTimer;

	// Use this for initialization
	void Awake () {
	}

	void Start(){

	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		
	}
}