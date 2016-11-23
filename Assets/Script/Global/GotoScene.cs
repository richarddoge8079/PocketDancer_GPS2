using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour {

	public string sceneName;
	public float timer;

	// Use this for initialization
	void Start () {
//		StartCoroutine ("GoToSceneTimer", timer);
	}

	public void GoScene(){
		StartCoroutine ("GoToSceneTimer", timer);
	}

	IEnumerator GoToSceneTimer(float t){
		yield return new WaitForSeconds (t);
		SceneManager.LoadSceneAsync (sceneName);
	}
}
