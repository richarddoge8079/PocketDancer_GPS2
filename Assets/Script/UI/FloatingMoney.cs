using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingMoney : MonoBehaviour {
	public bool move;
	// Use this for initialization
//	void Start()
//	{
//		StopCoroutine (Timer(1.0f));
//		StartCoroutine (Timer (1.0f));
//	}
	void OnEnable()
	{
		StopCoroutine (Timer(0.5f));
		StartCoroutine (Timer (0.5f));
	}

	// Update is called once per frame
	void Update () 
	{
		if (move) 
		{
			gameObject.GetComponent<RectTransform> ().localPosition = Vector2.Lerp (gameObject.GetComponent<RectTransform> ().localPosition, GameObject.FindGameObjectWithTag ("Wallet").GetComponent<RectTransform> ().localPosition, 0.5f);
			if (gameObject.GetComponent<RectTransform> ().localPosition == GameObject.FindGameObjectWithTag ("Wallet").GetComponent<RectTransform> ().localPosition) {
				Destroy (gameObject);
				Debug.Log ("AA");
			}
		}
	}
	IEnumerator Timer (float Delay)
	{
		yield return new WaitForSeconds (Delay);
		move = true;
	}

}
