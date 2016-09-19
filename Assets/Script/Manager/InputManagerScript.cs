using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManagerScript : MonoBehaviour 
{
	private static InputManagerScript mInstance;

	public static InputManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject obj = new GameObject("_InputManager");
				mInstance = obj.AddComponent<InputManagerScript>();
				//DontDestroyOnLoad(obj);
			}			
			return mInstance;
		}
	}

	public delegate bool DelOnTouchEvent(int fingerID, Vector2 pos);
	public event DelOnTouchEvent EvtOnTouchDown;
	public event DelOnTouchEvent EvtOnTouchUp;

	public delegate bool DelOnTouchDragEvent(int fingerID, Vector2 pos, Vector2 delta);
	public event DelOnTouchDragEvent EvtOnTouchDrag;
	public event DelOnTouchDragEvent EvtOnTouchStop;

	//! MACRO
	#if ((UNITY_IPHONE || UNITY_ANDROID))// && !UNITY_EDITOR)
	Vector2 mLastTouchPos;
	#else
	Vector2 mLastMousePos;
	#endif

	void Awake()
	{
		if(mInstance != null)
		{
			// self destroy
			Destroy(gameObject);
		}
	}

	void Update()
	{
		if (UnityEditor.EditorApplication.isRemoteConnected) 
		{
			//Debug.Log("UnityEditor.EditorApplication.isRemoteConnected");
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		#if ((UNITY_IPHONE || UNITY_ANDROID))// && !UNITY_EDITOR)
		{
		// DO TOUCH HERE
		foreach (Touch touch in Input.touches)
		{
		if(touch.phase == TouchPhase.Began)
		{
		foreach (DelOnTouchEvent del in EvtOnTouchDown.GetInvocationList())
		{
		if(del(touch.fingerId,touch.position))
		{
		break;
		}
		}
		}

		else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
		{
		foreach (DelOnTouchEvent del in EvtOnTouchUp.GetInvocationList())
		{
		if(del(touch.fingerId,touch.position))
		{
		break;
		}
		}
		}

		else if(touch.phase == TouchPhase.Moved)
		{
		foreach (DelOnTouchDragEvent del in EvtOnTouchDrag.GetInvocationList())
		{
		if(del(touch.fingerId, touch.position, touch.deltaPosition))
		{
		break;
		}
		}
		}

		else if(touch.phase == TouchPhase.Stationary)
		{
		foreach (DelOnTouchDragEvent del in EvtOnTouchStop.GetInvocationList())
		{
		if(del(touch.fingerId, touch.position, touch.deltaPosition))
		{
		break;
		}
		}
		}
		}
		}
		#else
		{
			// DO MOUSE HERE
			Vector2 pos = Input.mousePosition;
			if(Input.GetMouseButtonDown(0))
			{
				mLastMousePos = pos;
				foreach (DelOnTouchEvent del in EvtOnTouchDown.GetInvocationList())
				{
					if(del(0,pos))
					{
						break;
					}
				}
			}

			else if (Input.GetMouseButtonUp(0))
			{
				foreach (DelOnTouchEvent del in EvtOnTouchUp.GetInvocationList())
				{
					if(del(0,pos)) 
					{
						break;
					}
				}           
			}

			if(/*pos != mLastMousePos && */Input.GetMouseButton(0))
			{
				//Debug.Log("Pos : " + pos + " , Last Mouse Pos : " + mLastMousePos);
				Vector2 delta = pos - mLastMousePos;
				mLastMousePos = pos;
				//Debug.Log("After \tPos : " + pos + " , Last Mouse Pos : " + mLastMousePos);
				foreach (DelOnTouchDragEvent del in EvtOnTouchDrag.GetInvocationList())
				{
					if(del(0,pos,delta))
					{
						break;
					}
				}
			}

			else if(/*pos == mLastMousePos && */!Input.GetMouseButton(0))
			{
				//Debug.Log("Pos : " + pos + " , Last Mouse Pos : " + mLastMousePos);
				//Debug.Log("Stoped Moving But Still Touching");
				Vector2 delta = pos - mLastMousePos;
				mLastMousePos = pos;
				//Debug.Log("After \tPos : " + pos + " , Last Mouse Pos : " + mLastMousePos);
				foreach (DelOnTouchDragEvent del in EvtOnTouchStop.GetInvocationList())
				{
					if(del(0,pos,delta))
					{
						break;
					}
				}
			}		
		}
		#endif
	}

}
