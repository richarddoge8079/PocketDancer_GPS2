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
	public GameObject Noticeboard;

	public bool MoveToSafe = false;
	public bool BackFromWardrobe = false;
	public bool BackFromDoor = false;
	public bool MoveToDoor = false;
	public bool BackFromSafe = false;
	public bool MoveToWardrobe = false;
	public bool OnTheBoard = false;

	bool isPlayingAnimation;
	float AnimTimer;
	bool isDrag;
	float isDragTimer;

	public GameObject UpgSysUI;
	public GameObject GoToWardrobe;
	public GameObject BackFromWardrobes;
	public GameObject ChooseLevel;
	public GameObject GoToBoard;
	public GameObject BackFromBoard;
	public Text DaysCount;
	public int MaxMoney;
	public Text Moneyleft;
	public int MaxDays;

	public GameObject Day1;
	public GameObject Day2;
	public GameObject Day3;
	public GameObject Day4;
	public GameObject Day5;
	public GameObject Day6;

	public int CameraPosition = 0;

	private Animator anim;

	float timer;
	float UITimer;
	bool BackToMM = false;
	bool UpgradeButtonPress = false;
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
		if (DataManager.Instance.dayCount > 1) 
		{
			if(!isPlayingAnimation)
			{
				if (delta.x > dragThresholdRight) 
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
				else if (delta.x < dragThresholdLeft) 
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
		}
		else
		{
			if(!isPlayingAnimation)
			{
				if (delta.x > dragThresholdRight) 
				{
					if (CameraPosition == 0) 
					{
						MoveToSafe = true;
						if (MoveToSafe == true)
						{
							anim.Play ("LookAtTheSafeInTutorial");
							isPlayingAnimation = true;
						}
					} 
					else if (CameraPosition == 1)
					{
						BackFromWardrobe = true;
						if (BackFromWardrobe == true && MoveToWardrobe == true)
						{
							anim.Play ("BackFromWardrobeInTutorial");
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
							anim.Play ("backFromDoorInTutorial");
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
				else if (delta.x < dragThresholdLeft) 
				{
					if (CameraPosition == -1) 
					{
						BackFromSafe = true;
						if (BackFromSafe == true && MoveToSafe == true)
						{
							anim.Play ("BackFromTheSafeInTutorial");
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
							anim.Play ("MoveToWardrobeInTutorial");
							isPlayingAnimation = true;
						}
					}
					else if (CameraPosition == 1)
					{
						MoveToDoor = true;
						if (MoveToDoor == true)
						{
							anim.Play ("LookToDoorInTutorial");
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
		Day1.SetActive(false);
		Day2.SetActive(false);
		Day3.SetActive(false);
		Day4.SetActive(false);
		Day5.SetActive(false);
		Day6.SetActive(false);

		DataManager.Instance.dayCount += 1;

		if(DataManager.Instance.dayCount == 1)
		{
			anim.Play ("CameraMoving");
			Day1.SetActive(true);
		}
		else if(DataManager.Instance.dayCount == 2)
		{
			anim.Play ("CameraMovingAfterTutorial");
			Day1.SetActive(true);
			Day2.SetActive(true);
		}
		else if(DataManager.Instance.dayCount == 3)
		{
			anim.Play ("CameraMovingAfterTutorial");
			Day1.SetActive(true);
			Day2.SetActive(true);
		}
		else if(DataManager.Instance.dayCount == 4)
		{
			anim.Play ("CameraMovingAfterTutorial");
			Day1.SetActive(true);
			Day2.SetActive(true);
			Day3.SetActive(true);

			if (DataManager.Instance.moneyCount < MaxMoney * 3 / 4 )
			{
				Day4.SetActive(true);
			}
		}
		else if(DataManager.Instance.dayCount == 5)
		{
			anim.Play ("CameraMovingAfterTutorial");
			Day1.SetActive(true);
			Day2.SetActive(true);
			Day3.SetActive(true);
			Day4.SetActive(true);
		}
		else if(DataManager.Instance.dayCount == 6 && DataManager.Instance.moneyCount >= MaxMoney)
		{
			anim.Play ("CameraMovingAfterTutorial");
			Day1.SetActive(true);
			Day2.SetActive(true);
			Day3.SetActive(true);
			Day4.SetActive(true);
			Day5.SetActive(true);
		}
		else if(DataManager.Instance.dayCount == 6 && DataManager.Instance.moneyCount < MaxMoney)
		{
			anim.Play ("CameraMovingAfterTutorial");
			Day1.SetActive(true);
			Day2.SetActive(true);
			Day3.SetActive(true);
			Day4.SetActive(true);
			Day6.SetActive(true);
		}

		Noticeboard = GameObject.Find ("Noticeboard");
	}

	void Update()
	{
		float CurrentMoney;

		CurrentMoney = MaxMoney - DataManager.Instance.moneyCount;
		DaysCount.text = (MaxDays -  DataManager.Instance.dayCount).ToString();
		Moneyleft.text = CurrentMoney.ToString ();

		if(DataManager.Instance.dayCount == 3 && (DataManager.Instance.upgrade1Active == true || DataManager.Instance.upgrade2Active == true || DataManager.Instance.upgrade3Active == true || DataManager.Instance.upgrade4Active == true || DataManager.Instance.upgrade5Active == true || DataManager.Instance.upgrade6Active == true || DataManager.Instance.upgrade7Active == true || DataManager.Instance.upgrade8Active == true))
		{
			Day3.SetActive(true);
		}

		if (!isDrag)
		{
			if (UpgradeButtonPress == true)
			{
				GotoUpgradePress ();
			} 
			else if (BoardButtonPress == true)
			{
				timer += Time.deltaTime;

				if (timer >= 1.0f)
				{
					BackFromBoard.SetActive (true);
					timer = 0.0f;
				}
			}
			else if (BoardButtonPress == false)
			{
				timer += Time.deltaTime;

				if (timer >= 1.0f)
				{
					GoToBoard.SetActive (true);
					timer = 0.0f;
				}
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

			if(MoveToSafe = true && AnimTimer >= 1.5f)
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
			else if(BackFromSafe == true && MoveToSafe == true && AnimTimer >= 1.5f)
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

		if (DataManager.Instance.dayCount > 1) 
		{
			anim.Play ("MiddlePartToBoard");
			GoToBoard.SetActive (false);

			OnTheBoard = true;

			timer += Time.deltaTime;

			if (timer >= 1.0f)
			{
				BackFromBoard.SetActive (true);
				timer = 0.0f;
			}
		} 
		else 
		{
			anim.Play ("MiddlePartToBoardInTutorial");
			GoToBoard.SetActive (false);

			OnTheBoard = true;

			timer += Time.deltaTime;

			if (timer >= 1.0f)
			{
				BackFromBoard.SetActive (true);
				timer = 0.0f;
			}
		}
	}

	public void BackFromBoardPress()
	{		
		if (Noticeboard.GetComponent<DaySelectedScript> ().IsSelected == false)
		{
			if (DataManager.Instance.dayCount > 1) 
			{
				BoardButtonPress = false;

				anim.Play ("MiddlePartFromBoard");
				BackFromBoard.SetActive (false);

				OnTheBoard = false;
			} 
			else 
			{
				BoardButtonPress = false;

				anim.Play ("MiddlePartFromBoardInTutorial");
				BackFromBoard.SetActive (false);

				OnTheBoard = false;
			}

		}
	}

	public void BackToMainMenu()
	{
		BackToMM = true;
		SceneManager.LoadScene("MainMenu");
	}

	public void GoToLevel()
	{
		if (DataManager.Instance.dayCount > 1) 
		{
			anim.Play ("GoToChooseLevel");
			GoToWardrobe.SetActive (false);
			ChooseLevel.SetActive (true);
			BackFromWardrobes.SetActive (true);
		} 
		else 
		{
			anim.Play ("GoToChooseLevelInTutorial");
			GoToWardrobe.SetActive (false);
			ChooseLevel.SetActive (true);
			BackFromWardrobes.SetActive (true);
		}
	}

	public void BackFromLevel()
	{
		if (DataManager.Instance.dayCount > 1) 
		{
			anim.Play ("BackFromChooseLevel");
			BackFromWardrobes.SetActive (false);
			ChooseLevel.SetActive (false);
			GoToWardrobe.SetActive(true);
		} 
		else 
		{
			anim.Play ("BackFromChooseLevelInLevel");
			BackFromWardrobes.SetActive (false);
			ChooseLevel.SetActive (false);
			GoToWardrobe.SetActive(true);
		}
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




