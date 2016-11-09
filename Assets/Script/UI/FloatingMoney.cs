using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingMoney : MonoBehaviour {

	public Text moneyUI;
	public Image Money;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Money.rectTransform.localPosition = Vector2.Lerp (Money.rectTransform.localPosition, moneyUI.rectTransform.localPosition, 1.5f);
	}
}
