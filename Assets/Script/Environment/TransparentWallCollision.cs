using UnityEngine;
using System.Collections;

public class TransparentWallCollision : MonoBehaviour {

	public Material[] childWallsMaterials;
	public Color materialColor;
	public float transparencyValue;

	// Use this for initialization
	void Start () {
		childWallsMaterials = gameObject.GetComponentsInChildren<Material> ();
		materialColor = childWallsMaterials [0].color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Player")){
			for(int i = 0; i < childWallsMaterials.Length; i++){
				materialColor.a = transparencyValue;
				childWallsMaterials [i].color = materialColor;
			}
		}
	}
}
