using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolingScript : MonoBehaviour 
{
	public static ObjectPoolingScript Current;
	public GameObject PooledObject;
	public int PooledAmount = 1;
	public bool WillGrow = true;

	List<GameObject> PooledObjects;

	void Awake()
	{
		Current = this;
	}

	void Start ()
	{
		PooledObjects = new List<GameObject> ();

		for (int i = 0; i < PooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate (PooledObject);
			obj.SetActive (false);
			PooledObjects.Add (obj);
		}

	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < PooledObjects.Count; i++) 
		{
			if (!PooledObjects [i].activeInHierarchy) 
			{
				return PooledObjects [i];
			}
		}

		if (WillGrow) 
		{
			GameObject obj = (GameObject)Instantiate (PooledObject);
			PooledObjects.Add (obj);
			return obj;
		}

		return null;
	}
}
