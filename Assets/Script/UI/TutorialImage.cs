using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour {

	public float tutorialRange;
	RaycastHit isTutorial;
	public Image tutImage;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Ray tutorialRay = new Ray (transform.localPosition, transform.right);
		if (Physics.Raycast (tutorialRay, out isTutorial, tutorialRange)) {
			checkPlayer ();
		} else {
//			Debug.Log ("kdone");

		}
		Debug.DrawRay (transform.localPosition, transform.right * tutorialRange, Color.red);
	}

	void checkPlayer()
	{
		if (isTutorial.collider.CompareTag ("Player")) {
			UIManager.Instance.EnableTutorial (true);	
			UIManager.Instance.tutorialImage.sprite = tutImage.sprite;
		} else {
			UIManager.Instance.EnableTutorial (false);
		}
	}
}