using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PickScene(){
		SceneManager.LoadScene("LoadingScreen_HouseParty_1");
	}
}
