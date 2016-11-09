using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour {

<<<<<<< HEAD
	public PlayerUpgrade playerUpgradeScript;
	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
=======
>>>>>>> a206c28dfa7b4db1f8c9670a7e7148f216aaf635
	// Update is called once per frame
	void Update () {
	
	}

	public void PickScene(){
		//Club Level
		if (playerUpgradeScript.upgrade1Active) {
//			SceneManager.LoadScene("Club_1");
			sceneName = "Club_1";
		} 
		// House Level
		else {
			sceneName = "HouseParty_1";
		}
		DataManager.Instance.sceneName = sceneName;
		SceneManager.LoadSceneAsync ("LoadingScreen");
	}
	
	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
