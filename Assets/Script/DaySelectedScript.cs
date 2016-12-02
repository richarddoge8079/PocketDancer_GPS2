using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DaySelectedScript : MonoBehaviour 
{
	public GameObject MainCamera;
	public bool IsSelected = false;

	public GameObject Story;

	bool Day1 = false;
	bool Day2 = false;
	bool Day3 = false;
	bool Day4 = false;
	bool Day5 = false;
	bool Day6 = false;
	bool Credit = false;

	private Animator anim;

	public Text StoryWords;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () 
	{
		MainCamera = GameObject.Find ("MainCamera"); 

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Day1 == true) 
		{
			Story.SetActive (true);
			StoryWords.text = "Ok so maybe I shouldn’t have borrowed that much." + "\n\n" + "What was I to do?" + "\n\n" + " It wasn’t like getting a loan from the bank was an option; already blew credit on getting the room as it is!" + "\n\n" + "All in all tho, this brand new mini computer thingy from FutureCo is sweet." + "\n\n" + "Who would’ve thought touchscreens would be possible?" + "\n\n" + " It’s like it’s from the 20th century or something.";
		}
		else if (Day2 == true) 
		{
			Story.SetActive (true);
			StoryWords.text = "Who’dve thought stealing from party goers would be this easy?" + "\n\n" + "Just bump into them and do the ol fishhook slip." + "\n\n" + "Figure I’ll probably need to step up the pace; 5 days left to get that much cash that isn’t going to be a walk in the park.";
		}
		else if (Day3 == true) 
		{
			Story.SetActive (true);
			StoryWords.text = "I’m starting to wonder if FutureCo’s actually the real deal." + "\n\n" + "The mini computer is one thing, but what I buy from Instashop always appear on the doorstep instantly with like a flash and the package is still smoking!" + "\n\n" + "I mean… they aren’t actually teleporting all this to my doorstep, are they?";
		}
		else if (Day4 == true) 
		{
			Story.SetActive (true);
			StoryWords.text = "This isn’t good." + "\n\n" + "Three days left and I’m still nowhere near my goal." + "\n\n" + " I’ve got to step it up with my next few heists or I’ll be swimming with the fishes soon.";
		}
		else if (Day5 == true) 
		{
			Story.SetActive (true);
			StoryWords.text = "I’m already in the safe, but heh, why stop there?" + "\n\n" + "Let’s go for the big leagues!" + "\n\n" + "Every dollar I get in this last heist I’ll put into keeping myself afloat for at least another two months to come!";
		}
		else if (Day6 == true) 
		{
			Story.SetActive (true);
			StoryWords.text = "Last heists." + "\n\n" + "No more screw ups." + "\n\n" + "Gotta go big or broke, as they say.";
		}
	}

	public void GoToDay1()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			if (DataManager.Instance.dayCount > 1)
			{
				anim.Play ("Day1Selected");
				IsSelected = true;
				Day1 = true;
			}
			else
			{
				anim.Play ("Day1SelectedInTutorial");
				IsSelected = true;
				Day1 = true;
			}
		}
	}

	public void GoToDay2()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			anim.Play ("Day2Selected");
			IsSelected = true;
			Day2 = true;
		}
	}

	public void GoToDay3()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			anim.Play ("Day3Selected");
			IsSelected = true;
			Day3 = true;
		}
	}

	public void GoToDay4()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			anim.Play ("Day4Selected");
			IsSelected = true;
			Day4 = true;
		}
	}

	public void GoToDay5()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			anim.Play ("Day5Selected");
			IsSelected = true;
			Day5 = true;
		}
	}

	public void GoToDay6()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			anim.Play ("Day6Selected");
			IsSelected = true;
			Day6 = true;
		}
	}

	public void GoToCredit()
	{
		if (MainCamera.GetComponent<HideoutCameraMovingScript> ().OnTheBoard == true) 
		{
			if (DataManager.Instance.dayCount > 1)
			{
				anim.Play ("CreditSelected");
				IsSelected = true;
				Credit = true;
			}
			else
			{
				anim.Play ("CreditSelectedInTutorial");
				IsSelected = true;
				Credit = true;
			}
		}
	}

	public void BackFromReading()
	{
		if (Day1 == true && IsSelected == true) 
		{
			if (DataManager.Instance.dayCount > 1)
			{
				anim.Play ("Day1Back");
				IsSelected = false;
				Day1 = false;
			}
			else
			{
				anim.Play ("Day1BackInTutorial");
				IsSelected = false;
				Day1 = false;
			}
		}
		else if (Day2 == true && IsSelected == true) 
		{
			anim.Play ("Day2Back");
			IsSelected = false;
			Day2 = false;
		}
		else if (Day3 == true && IsSelected == true) 
		{
			anim.Play ("Day3Back");
			IsSelected = false;
			Day3 = false;
		}
		else if (Day4 == true && IsSelected == true) 
		{
			anim.Play ("Day4Back");
			IsSelected = false;
			Day4 = false;
		}
		else if (Day5 == true && IsSelected == true) 
		{
			anim.Play ("Day5Back");
			IsSelected = false;
			Day5 = false;
		}
		else if (Day6 == true && IsSelected == true) 
		{
			anim.Play ("Day6Back");
			IsSelected = false;
			Day6 = false;
		}
		else if (Credit == true && IsSelected == true) 
		{
			if (DataManager.Instance.dayCount > 1)
			{
				anim.Play ("CreditBack");
				IsSelected = false;
				Credit = false;
			}
			else
			{
				anim.Play ("CreditBackInTutorial");
				IsSelected = false;
				Credit = false;
			}
		}
	}
}
