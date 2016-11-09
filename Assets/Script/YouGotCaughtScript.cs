using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class YouGotCaughtScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FadeManager.Instance.Fade (false, 1.25f);
	}
	
	// Update is called once per frame
	void Update () {

		if (DataManager.Instance.dayCount >= 0) 
		{
			SceneManager.LoadScene("Hideout");
		} 
		else if (DataManager.Instance.dayCount < 0) 
		{
			SceneManager.LoadScene("LoseScene");
		}
	}
}
