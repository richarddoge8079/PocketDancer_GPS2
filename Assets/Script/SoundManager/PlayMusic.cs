using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoundManagerScript.Instance.PlayLoopingBGM (AudioClipID.BGM_BATTLE);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
