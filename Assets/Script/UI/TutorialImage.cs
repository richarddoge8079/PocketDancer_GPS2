using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour {

	public Image tutImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Player")){
			UIManager.Instance.EnableTutorial(true);
			UIManager.Instance.tutorialImage.sprite = tutImage.sprite;
		}
	}
	void OnTriggerExit(Collider coll){
		if(coll.CompareTag("Player")){
//						Debug.Log ("bb");
			//			UIManager.Instance.tutorialImage = tutImage;
//			Color color = UIManager.Instance.tutorialImageColor;
//			color.a = 1.0f;
//
//			UIManager.Instance.tutorialImageColor = color;
//			UIManager.Instance.tutorialImageColor.a = 0.0f;

			UIManager.Instance.EnableTutorial(false);

		}
	}
}
