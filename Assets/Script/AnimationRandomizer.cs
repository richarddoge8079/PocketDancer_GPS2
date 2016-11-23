using UnityEngine;
using System.Collections;

public class AnimationRandomizer : MonoBehaviour {

	public Animation animationReference;
	public AnimationClip[] clips;
	int _currClip = 0;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("1")) 
		{
			OnCompleteOfClip ();
		}
	}
	void OnCompleteOfClip()
	{
		_currClip = Random.Range(0,2);
		Debug.Log (_currClip);
		if(_currClip == clips.Length) return;
		{
			animationReference.clip = clips [_currClip];
//		Debug.Log (_currClip);
			animationReference.Play ();
		}
	}
}
