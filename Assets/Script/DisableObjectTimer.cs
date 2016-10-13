using UnityEngine;
using System.Collections;

public class DisableObjectTimer : MonoBehaviour {

	public float timer;

	void OnEnable(){
		StopCoroutine ("DisableTimer");
		StartCoroutine ("DisableTimer",timer);
	}

	IEnumerator DisableTimer(float t){
		yield return new WaitForSeconds (t);
		gameObject.SetActive (false);
	}
}
