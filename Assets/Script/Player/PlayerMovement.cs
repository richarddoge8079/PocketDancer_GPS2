using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float playerSpeed;
	public bool canMove;
	public float canMoveTimer;

	public Vector3 previousPos;

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
	}

	void Start()
	{

	}

	bool OnTouchDown(int fingerID, Vector2 pos)
	{
		//RestartLevel for POC
		if(fingerID >= 4){
			GameManager.Instance.RestartLevel ();
		}
		//End of RestartLevel for POC

		// move to rayposition on the offset
		//targetPosition = GetRayPosition (pos) + offset;
		if(fingerID == 0 && canMove){
			if (pos.y >= Screen.height / 2 && pos.x <= Screen.width / 2)
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
			else if (pos.y >= Screen.height / 2 && pos.x >= Screen.width / 2)
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
			else if (pos.y <= Screen.height / 2 && pos.x <= Screen.width / 2)
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
			else if (pos.y <= Screen.height / 2 && pos.x >= Screen.width / 2)
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
		if(BeatsManager.Instance.onBeat)
		{
			UIManager.Instance.onBeatFX_Color.r = 1.0f;
			UIManager.Instance.onBeatFX_Color.g = 1.0f;
			UIManager.Instance.onBeatFX_Color.b = 1.0f;

			UIManager.Instance.onBeatFX_Color.a += 0.8f;
			UIManager.Instance.beatImageFX_Color.a += 0.8f;
		}
		else if(!BeatsManager.Instance.onBeat)
		{
			UIManager.Instance.onBeatFX_Color.r = 1.0f;
			UIManager.Instance.onBeatFX_Color.g = 0.0f;
			UIManager.Instance.onBeatFX_Color.b = 0.0f;

			UIManager.Instance.onBeatFX_Color.a += 0.8f;
			UIManager.Instance.beatImageFX_Color.a = 0.0f;
		}
	}

	void MoveFoward(float speed){
		//		transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z + speed);
		//		GameManager.Instance.playerPreviousPosition = transform.position;
//		previousPos = transform.position;
		transform.Translate(Vector3.forward * speed);
//		GameManager.Instance.playerCollisionScript.SetPreviousPosition(previousPos);
		CheckDetection ();
		CheckBeat ();
		canMove = false;
		StartCoroutine ("MoveCooldownTimer", canMoveTimer);
	}

	void CheckDetection(){
		if(!BeatsManager.Instance.onBeat && GameManager.Instance.inSight){
			GameManager.Instance.playerStatsScript.detectionLevel += 28.0f;
		}
	}

	IEnumerator MoveCooldownTimer(float t){
		yield return new WaitForSeconds (t);
		canMove = true;
	}
}
