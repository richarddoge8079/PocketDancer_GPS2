using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestBeat : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if (BeatsManager.Instance.onBeat) {
//				Debug.Log ("Good");
				text.text = "On BEAT!";
			} 
			else {
//				Debug.Log ("Bad");
				text.text = "Try Again!";
			}
		}
	}
}
