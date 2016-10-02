using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private static UIManager mInstance;

	public static UIManager Instance{
		get{
			if(mInstance == null){
				GameObject tempObject = GameObject.FindGameObjectWithTag ("UIManager");

				if (tempObject == null) {
					GameObject obj = new GameObject ("UIManager");
					obj.tag = "UIManager";
					mInstance = obj.AddComponent<UIManager> ();
				} 
				else {
					mInstance = tempObject.GetComponent<UIManager> ();
				}

			}
			return mInstance;
		}
	}

	public Image beatImage;
	Color color;

	// Use this for initialization
	void Awake () {
	}

	void Start(){
		if(beatImage != null){
			color = beatImage.color;
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnBeat(){
		beatImage.rectTransform.localScale = new Vector3 (1.4f, 1.4f, 1.4f);
		StopCoroutine ("ResetBeatSizeTimer");
		StartCoroutine ("ResetBeatSizeTimer", 0.2f);
		color.a = 1.0f;
		beatImage.color = color;
	}

	IEnumerator ResetBeatSizeTimer(float t){
		yield return new WaitForSeconds (t);
		beatImage.rectTransform.localScale = new Vector3 (1, 1, 1);
		color.a = 0.75f;
		beatImage.color = color;
	}

	public void GotoScene(string sceneName){
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

	public void ExitGame(){
		Application.Quit ();
	}

}