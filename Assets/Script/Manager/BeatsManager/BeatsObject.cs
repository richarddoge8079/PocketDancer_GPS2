using UnityEngine;
using System.Collections;

public class BeatsObject : MonoBehaviour {

	public float beatSpeed;
	public float randomBeatSpeed;
	public float randomRange;
	public int counter;
	public Transform resetBeatPosition, initialBeatPosition;

	public bool tombtorial, cloud9;

	public bool check;

//	public float[] test;


	// Use this for initialization
	void Start () {
		randomBeatSpeed = beatSpeed;
		if(tombtorial){
			beatSpeed = 13.11f;
			randomRange = 0.002f;
		}
		else if(cloud9){
			beatSpeed = 16.985f;
			randomRange = 0.002f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.startBeat){
			transform.Translate (Vector3.right * randomBeatSpeed * Time.deltaTime);
		}
		if(transform.position.x >= resetBeatPosition.position.x){
			transform.position = new Vector3 (initialBeatPosition.position.x,transform.position.y,transform.position.z);
			UIManager.Instance.OnBeat ();
			this.gameObject.SetActive(false);
		}

		if(transform.position.x >= resetBeatPosition.position.x-0.5f){
			BeatsManager.Instance.onBeat = true;
		}

	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("OnBeat")){
			BeatsManager.Instance.onBeat = true;
		}
	}
	void OnTriggerExit(Collider coll){
		if(coll.CompareTag("OnBeat")){
			BeatsManager.Instance.onBeat = false;
		}
	}
}
