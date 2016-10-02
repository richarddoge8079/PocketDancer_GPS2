using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

	// Use this for initialization
	void Awake () {
	}

	void Start(){
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnBeat(){
		beatImage.rectTransform.localScale = new Vector3 (2, 2, 2);
		StopCoroutine ("ResetBeatSizeTimer");
		StartCoroutine ("ResetBeatSizeTimer", 0.2f);
	}

	IEnumerator ResetBeatSizeTimer(float t){
		yield return new WaitForSeconds (t);
		beatImage.rectTransform.localScale = new Vector3 (1, 1, 1);
	}

}