using UnityEngine;
using System.Collections;

public class SemiInvisibleWall : MonoBehaviour {

//	public float castDistance;
//	public float castRadius;
//	public LayerMask layerMask;
//
//	public RaycastHit hit;
//
//	public Vector3 offSet;

	public Vector3 playerPosition;
	public Vector3 mainCameraPosition;

	public Material material;
	public Color color;

	public bool longer;

	// Use this for initialization
	void Start () {
		material = GetComponent<MeshRenderer> ().material;
		color = GetComponent<MeshRenderer> ().material.color;
//		color.r = 255;
//		color.g = 255;
//		color.b = 255;
	}
	
	// Update is called once per frame
	void Update () {

//		Vector3 centerPosition = transform.position;
//
////		LayerMask layerMask = LayerMask.NameToLayer ("PhysicsCollision");
//
////		layerMask.value = 1 << layerMask.value;
//
//		Physics.SphereCast (centerPosition + offSet, castRadius, transform.forward, out hit, castDistance ,layerMask.value);
//
//		if(hit.collider != null){
//			Debug.Log (hit.collider.tag);
//		}
//
//		Debug.DrawRay (centerPosition + offSet, (transform.right) * castDistance, Color.blue);

		playerPosition = GameManager.Instance.playerObject.transform.position;
		mainCameraPosition = Camera.main.transform.position;

//		Debug.Log ("Player+Wall : " + Vector3.Distance (playerPosition, transform.position));
//		Debug.Log ("Camera+Wall : " + Vector3.Distance (mainCameraPosition, transform.position));

		if (longer) {

			if (Vector3.Distance (playerPosition, transform.position) < 7f) {
//				Debug.Log ("Near");
				if (Vector3.Distance (mainCameraPosition, transform.position) < 12f) {
					color.a = 0.5f;
//					Debug.Log ("Near");
					material.color = color;
				}
			} else {
				color.a = 1.0f;
				material.color = color;
			}
			
		} 
		else {

			if (Vector3.Distance (playerPosition, transform.position) < 6f) {
				if (Vector3.Distance (mainCameraPosition, transform.position) < 9f) {
					color.a = 0.5f;
//					Debug.Log ("Near");
					material.color = color;
				}
			} 
			else {
				color.a = 1.0f;
				material.color = color;
			}
		
		}

	}
}
