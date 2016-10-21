using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

	public float verticalSpeed;
	public float amplitude;
	public Sprite openDoor;
	public Material mat;

	public GameObject cameraObject;
	public GameObject plane;
	public GameObject door;
	public GameObject button;

	private Vector3 tempPosition;
	private AsyncOperation async;
	public string sceneName;
	private bool gotRoutine = false;

	void Start () 
	{
		mat.color = Color.black;
		tempPosition = transform.position;
		StartCoroutine ("LoadScene");
	}

	IEnumerator LoadScene()
	{
		if (sceneName == "")
			yield break;

		async = SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;
		Debug.Log("start loading");

		yield return async;
	}

	private bool transitioning = false;

	void Update()
	{
		if (async != null && async.progress<0.9f)
		{
			if (!transitioning)
			{
				Debug.Log("done loading");
				transitioning = true;
				StartCoroutine ("StopDoor", 3f);
			}
		}
	}

	void FixedUpdate () 
	{
		tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed)* amplitude;
		transform.position = tempPosition;
	}

	public void SwitchScene()
	{
		Debug.Log("switching");

		if (!gotRoutine)
			StartCoroutine ("OpenDoor");
	}

	IEnumerator StopDoor(float time)
	{
		gotRoutine = true;
		yield return new WaitForSeconds (time);
		verticalSpeed = 0;
		button.SetActive(true);	
		gotRoutine = false;
	}

	IEnumerator OpenDoor()
	{
		button.SetActive(false);	
		door.GetComponent<SpriteRenderer> ().sprite = openDoor;
		yield return new WaitForSeconds (1f);
		cameraObject.GetComponent<Animator> ().Play ("CameraMovement");
		yield return new WaitForSeconds (1f);
		mat.color = Color.white;		
		yield return new WaitForSeconds (1f);
		async.allowSceneActivation = true;
	}
}