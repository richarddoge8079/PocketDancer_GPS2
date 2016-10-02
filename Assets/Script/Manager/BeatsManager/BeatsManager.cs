using UnityEngine;
using System.Collections;
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

//	public float timerCount1;
//	public float timerCount2;

	public float resetBeatTimer;
	public float offbeatTimer;

	public bool startTimer;

	// Use this for initialization
	void Awake () {
	}

	void Start(){
//		StartCoroutine ("StartTimer", 1.0f);
	}

	// Update is called once per frame
	void Update () {
//		if(startTimer){
//			timerCount1 += Time.deltaTime;
//			if(timerCount1 >= 1.0f){
//				timerCount1 = 0.0f;
////				SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_EXPLOSION);
//			}
//		}
		if(onBeat){
			resetBeatTimer += Time.deltaTime;
			if(resetBeatTimer >= offbeatTimer){
				onBeat = false;
				resetBeatTimer = 0.0f;
			}
		}
	}

	void FixedUpdate(){
	}
}