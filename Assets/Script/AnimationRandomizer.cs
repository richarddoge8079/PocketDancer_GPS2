using UnityEngine;
using System.Collections;

public class AnimationRandomizer : MonoBehaviour {

	public string interChangeAnimationName;
	public string[] animationName;
	public int randomInt;

	public Animator animator;

	// Update is called once per frame
	void Update () 
	{
//		if (Input.GetKeyDown ("1")) 
//		{
////			OnCompleteOfClip ();
//		}
	}

	public void PlayAnimation()
	{
		randomInt = Random.Range (1, animationName.Length + 1);
		animator.SetInteger ("AnimationNumber", randomInt);
		animator.Play (interChangeAnimationName);
//		for(int i = 0; i < animationName.Length; i++){
//			if(i == randomInt){
////				animator.Play (animationName [i]);
//				break;
//			}
//		}
	}
}
