using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

	public void PickScene(){
		SceneManager.LoadScene("LoadingScreen_HouseParty_1");
	}
}
