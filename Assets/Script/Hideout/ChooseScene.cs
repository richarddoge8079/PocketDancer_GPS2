using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour {

	public PlayerUpgrade playerUpgradeScript;
	public string sceneName;

	public void PickScene01(){
		//Club Level
//		if (playerUpgradeScript.upgrade1Active) {
////			SceneManager.LoadScene("Club_1");
//			sceneName = "Club_1";
//		} 
		// House Level
//		else {
			sceneName = "HouseParty_1";
//		}
		DataManager.Instance.sceneName = sceneName;
		SceneManager.LoadSceneAsync ("LoadingScreen");
	}
	public void PickScene02()
	{
		sceneName = " ";
		DataManager.Instance.sceneName = sceneName;
		SceneManager.LoadSceneAsync ("LoadingScreen");
	}
	
	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
