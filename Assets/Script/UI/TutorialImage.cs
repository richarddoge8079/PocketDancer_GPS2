using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour {

	public GameObject self;
	public GameObject other;
	public float tutorialRange;
	RaycastHit isTutorial;
	public float timer;
	public Image tutImage;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Ray tutorialRay = new Ray (transform.position, transform.right);
		if (Physics.Raycast (tutorialRay, out isTutorial, tutorialRange)) {
			checkPlayer ();
		} 
		Debug.DrawRay (transform.position, transform.right * tutorialRange, Color.red);
	}

	void checkPlayer()
	{
		if (isTutorial.collider.CompareTag ("Player")) {
			UIManager.Instance.tutorialImage.sprite = tutImage.sprite;
			UIManager.Instance.EnableTutorial (true);	
			StartCoroutine (Timer (timer));
		} 
	}

	IEnumerator Timer(float timer)
	{
		yield return new WaitForSeconds (timer);
		UIManager.Instance.EnableTutorial (false);	
		self.SetActive (false);
		other.SetActive (false);
	}
}