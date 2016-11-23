using UnityEngine;
using System.Collections;

public class UIPlayAnimation : MonoBehaviour {

	public string animationName;
	public Animator animator;

	public void PlayAnimation(){
		animator.Play (animationName);
	}
}