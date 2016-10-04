using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	//	bool MovingForward = false;
	//	bool MovingBackward = false;
	public float playerSpeed;
	float timer;

	//	bool AllowRotate = false;
	//	float InitialPosition = 0f; 
	//	float DraggingPosition = 0f;

	// Use this for initialization
	void OnEnable () 
	{
		// Subscribe to events
		InputManagerScript.Instance.EvtOnTouchDown 	+= OnTouchDown;		
		InputManagerScript.Instance.EvtOnTouchUp 	+= OnTouchUp;
		InputManagerScript.Instance.EvtOnTouchDrag 	+= OnTouchDrag;
		InputManagerScript.Instance.EvtOnTouchStop 	+= OnTouchStop;
	}

	void OnDisable() {
		// Unsubscribe to events
		InputManagerScript.Instance.EvtOnTouchDown 	-= OnTouchDown;		
		InputManagerScript.Instance.EvtOnTouchUp 	-= OnTouchUp;
		InputManagerScript.Instance.EvtOnTouchDrag 	-= OnTouchDrag;
		InputManagerScript.Instance.EvtOnTouchStop 	-= OnTouchStop;

	}

	// Update is called once per frame
	void Update () 
	{
		//		if (MovingForward == true) 
		//		{
		//			transform.Translate (Vector3.forward * Time.deltaTime * playerSpeed);
		//		} 
		//		else if (MovingBackward == true) 
		//		{
		//			transform.Translate (Vector3.back * Time.deltaTime * playerSpeed);
		//		}
		//		timer++;
		//
		//		if (timer >= 1f) 
		//		{
		//			MovingForward = false;
		//			MovingBackward = false;
		//			timer = 0f;
		//		}
	}

	void Start()
	{

	}

	bool OnTouchDown(int fingerID, Vector2 pos)
	{
		// move to rayposition on the offset
		//targetPosition = GetRayPosition (pos) + offset;
		if (pos.y >= Screen.height / 2 && pos.x <= Screen.width / 6)
		{
			if (this.transform.eulerAngles.y == 0f) 
			{
				// MovingForward = true;
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 90f) 
			{
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 180f) 
			{
				transform.Rotate (Vector3.up * -90f);
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 270f) 
			{
				transform.Rotate (Vector3.up * 90f);
				MoveFoward(playerSpeed);
			}
		} 
		else if (pos.y >= Screen.height / 2 && pos.x >= Screen.width / 6 * 5)
		{
			if (this.transform.eulerAngles.y == 0f) 
			{
				transform.Rotate (Vector3.up * 90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 90f) 
			{
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 180f) 
			{
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 270f) 
			{
				transform.Rotate (Vector3.up * 90f);
				transform.Rotate (Vector3.up * 90f);
				MoveFoward(playerSpeed);
			}
		} 
		else if (pos.y <= Screen.height / 2 && pos.x <= Screen.width / 6)
		{
			if (this.transform.eulerAngles.y == 0f) 
			{
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 90f) 
			{
				transform.Rotate (Vector3.up * -90f);
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 180f) 
			{
				transform.Rotate (Vector3.up * 90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 270f) 
			{
				MoveFoward(playerSpeed);
			}
		} 
		else if (pos.y <= Screen.height / 2 && pos.x >= Screen.width / 6 * 5)
		{
			if (this.transform.eulerAngles.y == 0f) 
			{
				transform.Rotate (Vector3.up * -90f);
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 90f) 
			{
				transform.Rotate (Vector3.up * +90f);
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 180f) 
			{
				MoveFoward(playerSpeed);
			}
			else if (this.transform.eulerAngles.y == 270f) 
			{
				transform.Rotate (Vector3.up * -90f);
				MoveFoward(playerSpeed);
			}
		} 

		return true;
	}

	bool OnTouchUp(int fingerID, Vector2 pos)
	{
		return true;
	}

	bool OnTouchDrag(int fingerID, Vector2 pos, Vector2 delta)
	{	
		return true;
	}	


	bool OnTouchStop(int fingerID, Vector2 pos, Vector2 delta)
	{
		return true;
	}

	void CheckBeat(){
		if(BeatsManager.Instance.onBeat){
			Debug.Log ("Yay");
		}
	}

	void MoveFoward(float speed){
		//		transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z + speed);
		GameManager.Instance.playerPreviousPosition = transform.position;
		transform.Translate(Vector3.forward * speed);
		//CheckDetection ();
	}

	void CheckDetection(){
		if(!BeatsManager.Instance.onBeat){
			GameManager.Instance.playerStatsScript.detectionLevel += 15.0f;
		}
	}
}