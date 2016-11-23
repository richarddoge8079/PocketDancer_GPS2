using UnityEngine;
using System.Collections;

public class SetVictimMaterial : MonoBehaviour {

	public SkinnedMeshRenderer myMeshRenderer;
	public VictimFollow victimFollowScript;
	public GameObject victimObject;
	public AnimationRandomizer victimAnimationScript2;

	public VictimBehaviour victimBehaviorScript;

	// Use this for initialization
	void Start () {
		myMeshRenderer = this.gameObject.GetComponent<SkinnedMeshRenderer> ();
	}

	public void SetMaterial(){
		victimObject = victimFollowScript.victimObject;
		victimObject.GetComponent<VictimCollision> ().myMeshRenderer = this.myMeshRenderer;

		victimBehaviorScript = victimObject.GetComponent<VictimBehaviour> ();
		victimBehaviorScript.victimAnimationScript = this.victimAnimationScript2;
	}
}
