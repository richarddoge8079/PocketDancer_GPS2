using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private static GameManager mInstance;

	public static GameManager Instance{
		get{
			if(mInstance == null){
				GameObject tempObject = GameObject.FindGameObjectWithTag ("GameManager");

				if (tempObject == null) {
					GameObject obj = new GameObject ("_GameManager");
					obj.tag = "GameManager";
					mInstance = obj.AddComponent<GameManager> ();
				} 
				else {
					mInstance = tempObject.GetComponent<GameManager> ();
				}

			}
			return mInstance;
		}
	}

	public GameObject playerObject;
	public PlayerMovement playerMovementScript;
	public PlayerStats playerStatsScript;
	public PlayerCollsion playerCollisionScript;

	public Vector3 playerPreviousPosition;

	public bool startBeat;

	public float songLength;
	public bool songEnded;

	public GameObject beatCreator;

	//Just for POC
	public int pickPocket;
	//End of POC

	public bool inSight;

	// Use this for initialization
	void Awake () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerMovementScript = playerObject.GetComponent<PlayerMovement> ();
		playerStatsScript = playerObject.GetComponent<PlayerStats> ();
		playerCollisionScript = playerObject.GetComponent<PlayerCollsion> ();
	}

	void Start(){
//		beatCreator.SetActive (true);
		StartCoroutine ("StartMusic", 2.0f);
	}

	// Update is called once per frame
	void Update () {
		if(!songEnded){
			songLength -= Time.deltaTime;
		}
	}

	public void RestartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator StartMusic(float t){
		yield return new WaitForSeconds (t);
		SoundManagerScript.Instance.PlayBGM (AudioClipID.BGM_BATTLE);
		startBeat = true;
	}
}
