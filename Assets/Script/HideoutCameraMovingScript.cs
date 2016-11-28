using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HideoutCameraMovingScript : MonoBehaviour 
{
	//public Image FadeImg;
	//public float fadeSpeed = 2.0f;
	//bool SwitchColour = true;

	Vector3 offset;		// Offset position of the camera
	Vector3 targetPosition;		// the target position to interpolate/ move to

	public bool MoveToSafe = false;
	public bool BackFromWardrobe = false;
	public bool BackFromDoor = false;
	public bool MoveToDoor = false;
	public bool BackFromSafe = false;
	public bool MoveToWardrobe = false;

	bool isPlayingAnimation;
	float AnimTimer;
	public bool isDrag;
	float isDragTimer;

	public GameObject UpgSysUI;

	int CameraPosition = 0;

	private Animator anim;

	float timer;
	bool UpgradeButtonPress = false;
	bool BackToMM = false;
	bool BoardButtonPress = false;

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

	Vector3 GetRayPosition(Vector2 pos)
	{
		Vector3 rayPosition = Vector2.zero;
		// Fire a ray and return the hit position
		Ray ray = Camera.main.ScreenPointToRay (pos);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 1000f)) 
		{
			rayPosition = hit.point;

		} 
		else 
		{
			Debug.Log ("We hit nothing");
		}

		return rayPosition;
	}

	bool OnTouchDown(int fingerID, Vector2 pos)
	{
		return true;
	}

	bool OnTouchUp(int fingerID, Vector2 pos)
	{
		return true;
	}

	public float dragThresholdLeft = -100;
	public float dragThresholdRight = 100;

	bool OnTouchDrag(int fingerID, Vector2 pos, Vector2 delta)
	{	
		if(!isPlayingAnimation)
		{
			if (delta.x < dragThresholdLeft) 
			{
				if (CameraPosition == 0) 
				{
					MoveToSafe = true;
					if (MoveToSafe == true)
					{
						anim.Play ("LookAtTheSafe");
						isPlayingAnimation = true;
					}
				} 
				else if (CameraPosition == 1)
				{
					BackFromWardrobe = true;
					if (BackFromWardrobe == true && MoveToWardrobe == true)
					{
						anim.Play ("BackFromWardrobe");
						isPlayingAnimation = true;

						BackFromWardrobe = false;
						MoveToWardrobe = false;
					}
				}
				else if (CameraPosition == 2)
				{
					BackFromDoor = true;
					if (BackFromDoor == true && MoveToDoor == true)
					{
						anim.Play ("backFromDoor");
						isPlayingAnimation = true;

						BackFromDoor = false;
						MoveToDoor = false;
						MoveToWardrobe = true;
					}
				}

				CameraPosition -= 1;
				if (CameraPosition <= -1)
				{
					CameraPosition = -1;
				}
			}
			else if (delta.x > dragThresholdRight) 
			{
				if (CameraPosition == -1) 
				{
					BackFromSafe = true;
					if (BackFromSafe == true && MoveToSafe == true)
					{
						anim.Play ("BackFromTheSafe");
						isPlayingAnimation = true;

						MoveToSafe = false;
						BackFromSafe = false;
					}
				} 
				else if (CameraPosition == 0)
				{
					MoveToWardrobe = true;
					if (MoveToWardrobe == true)
					{
						anim.Play ("MoveToWardrobe");
						isPlayingAnimation = true;
					}
				}
				else if (CameraPosition == 1)
				{
					MoveToDoor = true;
					if (MoveToDoor == true)
					{
						anim.Play ("LookToDoor");
						isPlayingAnimation = true;

						MoveToWardrobe = false;
					}
				}

				CameraPosition += 1;
				if (CameraPosition >= 2)
				{
					CameraPosition = 2;
				}
			}
		}

		if (delta.x > 1 || delta.x < -1)
		{
			isDrag = true;
		}

		/*
		Debug.Log ("Magnitude: " + delta.x);

		if (delta.x < dragThresholdLeft && MoveToSafe == false) 
		{
			// move to ray position on the offset
			anim.Play("LookAtTheSafe");
			MoveToSafe = true;
			MoveToWardrobe = false;
			MoveToDoor = false;
		}
		else if (delta.x > dragThresholdRight && MoveToSafe == true) 
		{
			// move to ray position on the offset
			anim.Play("BackFromTheSafe");
			MoveToSafe = false;
			MoveToWardrobe = false;
			MoveToDoor = false;
		}
		else if (delta.x > dragThresholdRight && MoveToWardrobe == false) 
		{
			// move to ray position on the offset
			anim.Play("MoveToWardrobe");
			MoveToSafe = false;
			MoveToWardrobe = true;
			MoveToDoor = false;
		}
		else if (delta.x < dragThresholdLeft && MoveToWardrobe == true) 
		{
			// move to ray position on the offset
			anim.Play("BackFromWardrobe");
			MoveToSafe = false;
			MoveToWardrobe = false;
			MoveToDoor = false;
		}
		else if (delta.x > dragThresholdRight && MoveToDoor == false) 
		{
			// move to ray position on the offset
			anim.Play("LookToDoor");
			MoveToSafe = false;
			MoveToWardrobe = false;
			MoveToDoor = true;

		}
		else if (delta.x < dragThresholdLeft && MoveToDoor == true) 
		{
			// move to ray position on the offset
			anim.Play("backFromDoor");
			MoveToSafe = false;
			MoveToWardrobe = false;
			MoveToDoor = false;

		}*/

		return true;
	}	


	bool OnTouchStop(int fingerID, Vector2 pos, Vector2 delta)
	{
		return true;
	}

	void Awake()
	{
		anim = GetComponent <Animator> ();
		//FadeImg.rectTransform.localScale = new Vector2 (Screen.width, Screen.height);
	}

	void Start()
	{
		anim.Play ("CameraMoving");
	}

	void Update()
	{
		if (!isDrag)
		{
			if (UpgradeButtonPress == true)
			{
				GotoUpgradePress ();
			} 
			else if (BoardButtonPress == true)
			{
				GotoBoardPress ();
			} 
			else if (BackToMM == true)
			{
				SceneManager.LoadScene("MainMenu");
			}
		}

		if (isDrag == true) 
		{
			isDragTimer += Time.deltaTime;

			if (isDragTimer >= 1.0f) 
			{
				isDrag = false;
				isDragTimer = 0.0f;
			}
		}

		if (isPlayingAnimation == true)
		{
			AnimTimer += Time.deltaTime;

			if(MoveToSafe = true && AnimTimer >= 1.0f)
			{
				isPlayingAnimation = false;
				AnimTimer = 0.0f;
			}
			else if(BackFromWardrobe == true && MoveToWardrobe == true && AnimTimer >= 1.0f)
			{
				isPlayingAnimation = false;
				AnimTimer = 0.0f;

			}
			else if(BackFromDoor == true && MoveToDoor == true && AnimTimer >= 1.2f)
			{
				isPlayingAnimation = false;
				AnimTimer = 0.0f;
			}
			else if(BackFromSafe == true && MoveToSafe == true && AnimTimer >= 1.0f)
			{
				isPlayingAnimation = false;
				AnimTimer = 0.0f;
			}
			else if(MoveToWardrobe == true && AnimTimer >= 1.0f)
			{
				isPlayingAnimation = false;
				AnimTimer = 0.0f;

			}
			else if(MoveToDoor == true && AnimTimer >= 1.2f)
			{
				isPlayingAnimation = false;
				AnimTimer = 0.0f;
			}
		}
		//StartScene();
		/*timer += Time.deltaTime;
		// If the scene is starting...
		if (timer >= 4.0f)
		{
			SwitchColour = false;
			StartBlackscreen ();
		} 

		if (timer >= 6.0f)
		{
			UpgSysUI.SetActive(true);
		}
			// ... call the StartScene function.	*/
	}

	public void GotoUpgradePress()
	{
		UpgradeButtonPress = true;
		anim.Play ("MiddlePartToTablet");
		timer += Time.deltaTime;

		if (timer >= 2.0f)
		{
			UpgSysUI.SetActive (true);
			timer = 0.0f;
		}
	}

	public void GotoBoardPress()
	{
		BoardButtonPress = true;
		anim.Play ("MiddlePartToBoard");
		timer += Time.deltaTime;

		if (timer >= 2.0f)
		{
			//UpgSysUI.SetActive (true);
			timer = 0.0f;
		}
	}


	public void BackToMainMenu()
	{
		BackToMM = true;
	}
		
	/*void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		if (SwitchColour == true)
		{
			FadeToClear ();

			// If the texture is almost clear...
			if (FadeImg.color.a <= 0.0f)
			{
				// ... set the colour to clear and disable the RawImage.
				FadeImg.color = Color.clear;
				FadeImg.enabled = false;
			}
		}
	}

	void StartBlackscreen()
	{
		if (SwitchColour == false) 
		{
			FadeToBlack();

			// If the texture is almost clear...
			if (FadeImg.color.a >= 255.0f)
			{
				// ... set the colour to clear and disable the RawImage.
				FadeImg.color = Color.black;
				FadeImg.enabled = true;
			}
		}
	}*/
}

