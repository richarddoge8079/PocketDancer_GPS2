using UnityEngine;
using System.Collections;

public class VictimFollowerSpawner : MonoBehaviour {

	public GameObject victimFollower;
	public GameObject ga;

	// Use this for initialization
	void Start () {
//		ga = Instantiate (victimFollower,transform.position,Quaternion.identity);
		ga = Instantiate (victimFollower);
		ga.SendMessage ("SetFollow", this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
