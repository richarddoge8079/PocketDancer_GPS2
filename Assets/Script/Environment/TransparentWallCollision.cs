using UnityEngine;
using System.Collections;

public class TransparentWallCollision : MonoBehaviour {

	public GameObject[] childObjects;
	public MeshRenderer[] childWallsMaterials;
	public Color materialColor;
	public float transparencyValue;

	// Use this for initialization
	void Start () {
//		childObjects = gameObject.GetComponentsInChildren
//
//		for(int i = 0; i < transforms.Length; i++){
//			childWallsMaterials[i] = transforms.
//		}

//		childWallsMaterials = gameObject.GetComponentsInChildren<Material> ();
//		materialColor = childWallsMaterials [0].color;
		childWallsMaterials = gameObject.GetComponentsInChildren<MeshRenderer>();
		if(childWallsMaterials.Length >= 1){
			materialColor = childWallsMaterials [0].material.color;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.CompareTag("Player")){
			for(int i = 0; i < childWallsMaterials.Length; i++){
				materialColor.a = transparencyValue;
				childWallsMaterials [i].material.color = materialColor;
			}
		}
	}
	void OnTriggerExit(Collider coll){
		if(coll.CompareTag("Player")){
			for(int i = 0; i < childWallsMaterials.Length; i++){
				materialColor.a = 1;
				childWallsMaterials [i].material.color = materialColor;
			}
		}
	}
}
