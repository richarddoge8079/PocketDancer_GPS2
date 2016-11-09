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
	public AudioSource sfx;
	public AudioClip doorOpening;

	private Vector3 tempPosition;
	private AsyncOperation async;
	public string sceneName;
	private bool canLoad = false;
	private bool gotRoutine = false;

	void OnEnable () 
	{
		// Subscribe to events
		InputManagerScript.Instance.EvtOnTouchDown 	+= OnTouchDown;		
		InputManagerScript.Instance.EvtOnTouchUp 	+= OnTouchUp;
	}

	void OnDisable() {
		// Unsubscribe to events
		InputManagerScript.Instance.EvtOnTouchDown 	-= OnTouchDown;		
		InputManagerScript.Instance.EvtOnTouchUp 	-= OnTouchUp;
	}

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


	void Update()
	{
		if (async != null && async.progress<0.9f)
		{
			Debug.Log("done loading");
			StartCoroutine ("StopDoor", 3f);
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
		if (gotRoutine) {
			StartCoroutine ("OpenDoor");
		}
	}

	IEnumerator StopDoor(float time)
	{
		yield return new WaitForSeconds (time);
		verticalSpeed = 0;
		canLoad = true;
	}

	IEnumerator OpenDoor()
	{
		sfx.clip = doorOpening;
		sfx.Play();
		door.GetComponent<SpriteRenderer> ().sprite = openDoor;
		yield return new WaitForSeconds (1f);
		cameraObject.GetComponent<Animator> ().Play ("CameraMovement");
		yield return new WaitForSeconds (1f);
		mat.color = Color.white;		
		yield return new WaitForSeconds (1f);
		async.allowSceneActivation = true;
	}

	bool OnTouchDown(int fingerID, Vector2 pos)
	{
		// move to rayposition on the offset
		//targetPosition = GetRayPosition (pos) + offset;
		if(fingerID == 0 && canLoad){
			if (pos.y >= 0 && pos.x >= 0)
			{
				gotRoutine = true;
				SwitchScene ();
			} 
		}
		return true;
	}

	bool OnTouchUp(int fingerID, Vector2 pos)
	{
		return true;
	}
}