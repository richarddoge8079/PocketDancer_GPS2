using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	bool MovingForward = false;
	bool MovingBackward = false;
	public float playerSpeed;
	float timer;

	bool AllowRotate = false;
	float InitialPosition = 0f; 
	float DraggingPosition = 0f;

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
		if (MovingForward == true) 
		{
			transform.Translate (Vector3.forward * Time.deltaTime * playerSpeed);
		} 
		else if (MovingBackward == true) 
		{
			transform.Translate (Vector3.back * Time.deltaTime * playerSpeed);
		}
		timer++;

		if (timer >= 1f) 
		{
			MovingForward = false;
			MovingBackward = false;
			timer = 0f;
		}
	}

	void Start()
	{

	}

	bool OnTouchDown(int fingerID, Vector2 pos)
	{
		// move to rayposition on the offset
		//targetPosition = GetRayPosition (pos) + offset;
		if (pos.y >= Screen.height / 6 * 5)
		{
			MovingForward = true;
		} 
		else if (pos.y <= Screen.height / 6) 
		{
			MovingBackward = true;
		}
		InitialPosition = pos.x;
		DraggingPosition = pos.x;

		return true;
	}

	bool OnTouchUp(int fingerID, Vector2 pos)
	{
		if (AllowRotate == true) 
		{
			MovingForward = false;
			MovingBackward = false;
			if (InitialPosition < DraggingPosition) 
			{
				transform.Rotate (Vector3.up * 90f);
			} 
			else if(InitialPosition > DraggingPosition)
			{
				transform.Rotate (Vector3.up * -90f);
			}
		}

		return true;
	}

	public float dragThreshold = 1f;

	bool OnTouchDrag(int fingerID, Vector2 pos, Vector2 delta)
	{	
		if (delta.magnitude > dragThreshold) 
		{
			// move to ray position on the offset
			AllowRotate = true;
			DraggingPosition = pos.x;
		}

		return true;
	}	


	bool OnTouchStop(int fingerID, Vector2 pos, Vector2 delta)
	{
		return true;
	}

}