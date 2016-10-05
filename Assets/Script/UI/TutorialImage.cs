using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour {
	public GameObject tutorialndicator;
	public GameObject tutorialndicator2;
	public float timer;
	public float tutorialRange;
	RaycastHit hit;
	public Image tutImage;
	public bool displayed;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Ray tutorialRay = new Ray (transform.position, transform.right);
		if (Physics.Raycast (tutorialRay, out hit, tutorialRange)) {
			checkPlayer ();
		} 
		Debug.DrawRay (transform.position, transform.right * tutorialRange, Color.red);
	}

	void checkPlayer()
	{
		if (hit.collider.CompareTag ("Player")) {
			UIManager.Instance.tutorialImage.sprite = tutImage.sprite;
			UIManager.Instance.EnableTutorial (true);
			StartCoroutine (EndDisplay (timer));
		} 
	}

	IEnumerator EndDisplay(float delay)
	{
		yield return new WaitForSeconds (delay);
		UIManager.Instance.EnableTutorial (false);
		tutorialndicator.SetActive(false);
		tutorialndicator2.SetActive(false);
	}
}