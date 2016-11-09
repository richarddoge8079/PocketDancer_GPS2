using UnityEngine;
using System.Collections;

public class FadeInScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FadeManager.Instance.Fade (false, 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
