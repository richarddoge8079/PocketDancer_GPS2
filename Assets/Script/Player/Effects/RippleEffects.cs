using UnityEngine;
using System.Collections;

public class RippleEffects : MonoBehaviour {

	public Animator myAnimator;
	public bool isOnBeat;

	void OnEnable(){
		if (isOnBeat) {
			myAnimator.Play ("OnBeatRipple");
		} 
		else {
			myAnimator.Play ("OffBeatRipple");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
