using UnityEngine;
using System.Collections;

public class ObjectPoolInitializer : MonoBehaviour {
	
	public GameObject[] initializeObject;

	// Use this for initialization
	void Start () {
		for(int i=0; i < initializeObject.Length; i++){
			ObjectPoolingScript.Instance.CreatePool (initializeObject[i],10,50);	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
