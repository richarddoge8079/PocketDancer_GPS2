using UnityEngine;
using System.Collections;

public class BeatsObject : MonoBehaviour {

	public float beatSpeed;
	public float randomBeatSpeed;
	public float randomRange;
	public int counter;
	public Transform resetBeatPosition, initialBeatPosition;

	public bool tombtorial, cloud9;

	// Use this for initialization
	void Start () {
		randomBeatSpeed = beatSpeed;
		if(tombtorial){
			beatSpeed = 13.12f;
			randomRange = 0.03f;
		}
		else if(cloud9){
			beatSpeed = 16.85f;
			randomRange = 0.015f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * randomBeatSpeed * Time.deltaTime);
		if(transform.position.x >= resetBeatPosition.position.x){
			transform.position = new Vector3 (initialBeatPosition.position.x,transform.position.y,transform.position.z);
//			counter += 1;
			if (randomBeatSpeed >= beatSpeed) {
				randomBeatSpeed = Random.Range (beatSpeed - randomRange, beatSpeed);
			} 
			else {
				randomBeatSpeed = Random.Range (beatSpeed, beatSpeed + randomRange);
			}
//			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_EXPLOSION);
//			Debug.Log (counter);
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
