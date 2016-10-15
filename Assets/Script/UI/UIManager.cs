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
	public Animator beatImage_Animator;
	public Image beatImageFX;
	public Color beatImageFX_Color;
	public float beatImageFX_FadeSpeed;

	Color color;

	public Image tutorialImage;
//	public Color tutorialImageColor;

	public Image onBeatFX_Image;
	public Color onBeatFX_Color;
	public float onBeatFX_FadeSpeed;

	public Image offBeatFX_Image;
	public Color offBeatFX_Color;
	public float offBeatFX_FadeSpeed;

	public Slider DetectionBar;

	// Use this for initialization
	void Awake () {
	}

	void Start(){
		if(beatImage != null){
			color = beatImage.color;
			beatImage_Animator = beatImage.GetComponent<Animator> ();

			beatImageFX_Color = beatImageFX.color;
		}
//		tutorialImageColor = tutorialImage.color;
//		tutorialImageColor.a = 0.0f;
//		tutorialImage.color = tutorialImageColor;
		tutorialImage.enabled = false;

		//Initialize FX color
		onBeatFX_Color = onBeatFX_Image.color;
		onBeatFX_Color.a = 0.0f;
		onBeatFX_Image.color = onBeatFX_Color;

		offBeatFX_Color = offBeatFX_Image.color;
		offBeatFX_Color.a = 0.0f;
		offBeatFX_Image.color = offBeatFX_Color;
	}

	// Update is called once per frame
	void Update () {
		DetectionBar.value = GameManager.Instance.playerStatsScript.detectionLevel;


		//OnBeat Screen FX
		if (onBeatFX_Color.a > 0) {
			onBeatFX_Color.a -= onBeatFX_FadeSpeed * Time.deltaTime;

			if(onBeatFX_Color.a > 1.0f){
				onBeatFX_Color.a = 1.0f;
			}
		} 
		else {
			onBeatFX_Color.a = 0.0f;
		}

		//OffBeat Screen FX
		if (offBeatFX_Color.a > 0) {
			offBeatFX_Color.a -= offBeatFX_FadeSpeed * Time.deltaTime;

			if(offBeatFX_Color.a > 1.0f){
				offBeatFX_Color.a = 1.0f;
			}
		} 
		else {
			offBeatFX_Color.a = 0.0f;
		}

		//BeatUI FX
		if (beatImageFX_Color.a > 0) {
			beatImageFX_Color.a -= beatImageFX_FadeSpeed * Time.deltaTime;

			if (beatImageFX_Color.a > 1.0f) {
				beatImageFX_Color.a = 1.0f;
			}
		} 
		else {
			beatImageFX_Color.a = 0.0f;
		}

		beatImageFX.color = beatImageFX_Color;
		onBeatFX_Image.color = onBeatFX_Color;
		offBeatFX_Image.color = offBeatFX_Color;
	}

	public void OnBeat(){
		beatImage.rectTransform.localScale = new Vector3 (1.4f, 1.4f, 1.4f);
		StopCoroutine ("ResetBeatSizeTimer");
		StartCoroutine ("ResetBeatSizeTimer", 0.2f);
		color.a = 1.0f;
		beatImage.color = color;
	}

	public void OffBeat(){
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