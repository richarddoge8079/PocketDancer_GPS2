using UnityEngine;
using System.Collections;

public class SetVictimMaterial : MonoBehaviour {

	public SkinnedMeshRenderer myMeshRenderer;
	public VictimFollow victimFollowScript;
	public GameObject victimObject;

	// Use this for initialization
	void Start () {
		myMeshRenderer = this.gameObject.GetComponent<SkinnedMeshRenderer> ();
	}

	public void SetMaterial(){
		victimObject = victimFollowScript.victimObject;
		victimObject.GetComponent<VictimCollision> ().myMeshRenderer = this.myMeshRenderer;
	}
}
