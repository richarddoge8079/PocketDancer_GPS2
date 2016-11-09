using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour {

	public string levelSceneName;

	public Scene loadingScene;

	private static _SceneManager mInstance;

	public static _SceneManager Instance{
		get{
			if(mInstance == null){
				GameObject tempObject = GameObject.FindGameObjectWithTag ("_SceneManager");

				if (tempObject == null) {
					GameObject obj = new GameObject ("_SceneManager");
					obj.tag = "_SceneManager";
					mInstance = obj.AddComponent<_SceneManager> ();
				} 
				else {
					mInstance = tempObject.GetComponent<_SceneManager> ();
				}

			}
			return mInstance;
		}
	}

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene (loadingScene.name,LoadSceneMode.Additive);
	}

	public void ChangeToLevel(string sceneName){
//		SceneManager.LoadScene (sceneName,LoadSceneMode.Additive);
//		SceneManager.SetActiveScene (sceneName);
	}

	public void ChangeToHideout(){
//		SceneManager.SetActiveScene("LoadingScreen");
//		SceneManager.UnloadScene (levelSceneName);
	}
}
