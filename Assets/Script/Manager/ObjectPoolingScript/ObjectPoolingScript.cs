using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectPoolingScript
{
	//the variable is declared to be volatile to ensure that
	//assignment to the instance variable completes before the
	//instance variable can be accessed.
	private static volatile ObjectPoolingScript instance;

	//look up list of various object pools.
	private Dictionary<String, ObjectPool> objectPools;

	//object for locking
	private static object syncRoot = new System.Object();

	/// <summary>
	/// Constructor for the class.
	/// </summary>
	private ObjectPoolingScript()
	{
		//Ensure object pools exists.
		this.objectPools = new Dictionary<String, ObjectPool>();
	}

	/// <summary>
	/// Property for retreiving the singleton.  See msdn documentation.
	/// </summary>
	public static ObjectPoolingScript Instance
	{
		get
		{
			//check to see if it doesnt exist
			if (instance == null)
			{
				//lock access, if it is already locked, wait.
				lock (syncRoot)
				{
					//the instance could have been made between
					//checking and waiting for a lock to release.
					if (instance == null)
					{
						//create a new instance
						instance = new ObjectPoolingScript();
					}
				}
			}
			//return either the new instance or the already built one.
			return instance;
		}
	}

	/// <summary>
	/// Create a new object pool of the objects you wish to pool
	/// </summary>
	/// <param name="objToPool">The object you wish to pool.  The name property of the object MUST be unique.</param>
	/// <param name="initialPoolSize">Number of objects you wish to instantiate initially for the pool.</param>
	/// <param name="maxPoolSize">Maximum number of objects allowed to exist in this pool.</param>
	/// <param name="shouldShrink">Should this pool shrink back down to the initial size when it receives a shrink event.</param>
	/// <returns></returns>
	public bool CreatePool(GameObject objToPool, int initialPoolSize, int maxPoolSize)
	{
		//Check to see if the pool already exists.
		if (ObjectPoolingScript.Instance.objectPools.ContainsKey(objToPool.name))
		{
			//let the caller know it already exists, just use the pool out there.
			return false;
		}
		else
		{
			//create a new pool using the properties
			ObjectPool nPool = new ObjectPool(objToPool, initialPoolSize, maxPoolSize);
			//Add the pool to the dictionary of pools to manage
			//using the object name as the key and the pool as the value.
			ObjectPoolingScript.Instance.objectPools.Add(objToPool.name, nPool);
			//We created a new pool!
			return true;
		}
	}

	/// <summary>
	/// Get an object from the pool.
	/// </summary>
	/// <param name="objName">String name of the object you wish to have access to.</param>
	/// <returns>A GameObject if one is available, else returns null if all are currently active and max size is reached.</returns>
	public GameObject GetObject(string objName)
	{
		//Find the right pool and ask it for an object.
		return ObjectPoolingScript.Instance.objectPools[objName].GetObject();
	}
}

/*using UnityEngine;
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
}*/
