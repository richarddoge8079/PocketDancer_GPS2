using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public Transform nightClubLevelButton;
	public Transform VIPLevelButton;
	// Use this for initialization
	void Start () {
		if (DataManager.Instance.upgrade1Active) 
		{
			nightClubLevelButton.GetComponent<Button> ().interactable = true;
		}
		else if(!DataManager.Instance.upgrade1Active) 
		{
			nightClubLevelButton.GetComponent<Button> ().interactable = false;
		}
		if (DataManager.Instance.upgrade3Active) 
		{
			VIPLevelButton.GetComponent<Button> ().interactable = true;
		}
		else if (!DataManager.Instance.upgrade3Active) 
		{
			VIPLevelButton.GetComponent<Button> ().interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (DataManager.Instance.upgrade1Active) 
		{
			nightClubLevelButton.GetComponent<Button> ().interactable = true;
		}
		if (DataManager.Instance.upgrade3Active) 
		{
			VIPLevelButton.GetComponent<Button> ().interactable = true;
		}
	}
}
