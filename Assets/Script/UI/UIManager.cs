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

	public Image tutorialImage;
//	public Color tutorialImageColor;

	public Image onBeatFX_Image;
	public Color onBeatFX_Color;
	public float onBeatFX_FadeSpeed;

	public Slider DetectionBar;

	// Use this for initialization
	void Awake () {
	}

	void Start(){
		if(beatImage != null){
			color = beatImage.color;
		}
//		tutorialImageColor = tutorialImage.color;
//		tutorialImageColor.a = 0.0f;
//		tutorialImage.color = tutorialImageColor;
		tutorialImage.enabled = false;

		onBeatFX_Color = onBeatFX_Image.color;
	}

	// Update is called once per frame
	void Update () {
		DetectionBar.value = GameManager.Instance.playerStatsScript.detectionLevel;



		if (onBeatFX_Color.a > 0) {
			onBeatFX_Color.a -= onBeatFX_FadeSpeed * Time.deltaTime;

			if(onBeatFX_Color.a > 0.8f){
				onBeatFX_Color.a = 0.8f;
			}
		} 
		else {
			onBeatFX_Color.a = 0.0f;
		}
		onBeatFX_Image.color = onBeatFX_Color;
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

	public void EnableTutorial(bool temp){
		tutorialImage.enabled = temp;
	}

}