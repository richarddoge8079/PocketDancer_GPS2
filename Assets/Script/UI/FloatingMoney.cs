using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingMoney : MonoBehaviour {
	public bool move;
	// Use this for initialization
	void Start () 
	{
		move = true;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (move) {
			gameObject.GetComponent<RectTransform> ().localPosition = Vector3.Lerp (gameObject.GetComponent<RectTransform> ().localPosition, GameObject.FindGameObjectWithTag ("Wallet").GetComponent<RectTransform> ().localPosition, 0.5f);
			if (gameObject.GetComponent<RectTransform> ().localPosition == GameObject.FindGameObjectWithTag ("Wallet").GetComponent<RectTransform> ().localPosition) {
				Destroy (gameObject);
			}
		} 
	}
}
