using UnityEngine;
using System.Collections;

public class BeatFinder : MonoBehaviour {

	public float timer;
	public float[] timeTrack;
	public int counter;

	public GameObject ga1;
	public GameObject ga2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.UpArrow)){
//			Debug.Log (timer);
			counter+= 1;
//			timeTrack [counter] = timer;
			timer = 0.0f;

			Instantiate (ga1, ga2.transform.position,Quaternion.identity);

		}
	}
}
