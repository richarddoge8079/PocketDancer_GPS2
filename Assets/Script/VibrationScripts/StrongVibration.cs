using UnityEngine;
using System.Collections;

public class StrongVibration : MonoBehaviour {

	public bool canVibrate;
	public float vibrationalTimer;
	// Use this for initialization
	void Start () 
	{
		canVibrate = false;
	}

	// Update is called once per frame
	void Update () {
		if (canVibrate) 
		{
			Debug.Log ("Vibrating");
			//			Timer (vibratio'nalTimer);
			StartCoroutine("Timer", vibrationalTimer);
		} 

	}
	public void VibrateFunction ()
	{
		canVibrate = true;
	}

	IEnumerator Timer(float t)
	{
		yield return new WaitForSeconds (t);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (t);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (t);
		Handheld.Vibrate ();
		canVibrate = false;
	}
}
