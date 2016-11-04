﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HideoutCameraMovingScript : MonoBehaviour 
{
	public Image FadeImg;
	public float fadeSpeed = 2.0f;
	bool SwitchColour = true;

	public GameObject UpgSysUI;

	private Animator anim;

	float timer;

	void Awake()
	{
		anim = GetComponent <Animator> ();
		FadeImg.rectTransform.localScale = new Vector2 (Screen.width, Screen.height);
	}

	void Start()
	{
		anim.Play ("CameraMoving");
	}

	void Update()
	{
		StartScene();
		timer += Time.deltaTime;
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
			// ... call the StartScene function.	
	}
		
	void FadeToClear()
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
	}
}
