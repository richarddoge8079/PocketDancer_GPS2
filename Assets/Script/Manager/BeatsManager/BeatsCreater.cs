using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class BeatsCreater : MonoBehaviour {

	public GameObject beatObject;
	public int beatObjectCount;
	public float gap;

//	public List <GameObject> beatObjects;

	// Use this for initialization
	void Start () {

//		beatObjects = new List<GameObject> ();

		for(int i=1 ; i <= beatObjectCount ; i++){
//			beatObjects.Add((GameObject)
			Instantiate (beatObject,
				new Vector3(transform.position.x + (-gap*i),beatObject.transform.position.y,beatObject.transform.position.z),
					beatObject.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
