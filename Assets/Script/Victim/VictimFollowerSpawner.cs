using UnityEngine;
using System.Collections;

public class VictimFollowerSpawner : MonoBehaviour {

	public GameObject victimFollower;
	public GameObject ga;

	public GameObject navMeshObject;
	public GameObject navMeshFollow;
	public VictimBehaviour victimBehaviorScript;
	public VictimCollision victimCollisionScript;

	// Use this for initialization
	void Start () {
//		ga = Instantiate (victimFollower,transform.position,Quaternion.identity);
		ga = Instantiate (victimFollower);
		ga.SendMessage ("SetFollow", this.gameObject);

		navMeshFollow = Instantiate (navMeshObject);
		navMeshFollow.transform.position = transform.position;

		victimBehaviorScript.navMeshChaserObject = navMeshFollow.GetComponent<NavMeshAgent>();
//		victimCollisionScript.myMaterial = ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
