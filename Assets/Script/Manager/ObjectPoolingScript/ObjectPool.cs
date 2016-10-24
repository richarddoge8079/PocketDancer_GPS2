/*
 * @Author: David Crook
 *
 * Use the object pools to help reduce object instantiation time and performance
 * with objects that are frequently created and used.
 *
 *
 */
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

/// <summary>
/// The object pool is a list of already instantiated game objects of the same type.
/// </summary>
public class ObjectPool
{
	//the list of objects.
	private List<GameObject> pooledObjects;

	//sample of the actual object to store.
	//used if we need to grow the list.
	private GameObject pooledObj;

	//maximum number of objects to have in the list.
	private int maxPoolSize;

	//initial and default number of objects to have in the list.
	private int initialPoolSize;

	/// <summary>
	/// Constructor for creating a new Object Pool.
	/// </summary>
	/// <param name="obj">Game Object for this pool</param>
	/// <param name="initialPoolSize">Initial and default size of the pool.</param>
	/// <param name="maxPoolSize">Maximum number of objects this pool can contain.</param>
	/// <param name="shouldShrink">Should this pool shrink back to the initial size.</param>
	public ObjectPool(GameObject obj, int initialPoolSize, int maxPoolSize)
	{
		//instantiate a new list of game objects to store our pooled objects in.
		pooledObjects = new List<GameObject>();

		//create and add an object based on initial size.
		for (int i = 0; i < initialPoolSize; i++)
		{
			//instantiate and create a game object with useless attributes.
			//these should be reset anyways.
			GameObject nObj = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;

			//make sure the object isn't active.
			nObj.SetActive(false);

			//add the object too our list.
			pooledObjects.Add(nObj);

			//Don't destroy on load, so
			//we can manage centrally.
			GameObject.DontDestroyOnLoad(nObj);
		}

		//store our other variables that are useful.
		this.maxPoolSize = maxPoolSize;
		this.pooledObj = obj;
		this.initialPoolSize = initialPoolSize;
	}

	/// <summary>
	/// Returns an active object from the object pool without resetting any of its values.
	/// You will need to set its values and set it inactive again when you are done with it.
	/// </summary>
	/// <returns>Game Object of requested type if it is available, otherwise null.</returns>
	public GameObject GetObject()
	{
		//iterate through all pooled objects.
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			//look for the first one that is inactive.
			if (pooledObjects[i].activeSelf == false)
			{
				//set the object to active.
				pooledObjects[i].SetActive(true);
				//return the object we found.
				return pooledObjects[i];
			}
		}
		//if we make it this far, we obviously didn't find an inactive object.
		//so we need to see if we can grow beyond our current count.
		if (this.maxPoolSize > this.pooledObjects.Count)
		{
			//Instantiate a new object.
			GameObject nObj = GameObject.Instantiate(pooledObj, Vector3.zero, Quaternion.identity) as GameObject;
			//set it to active since we are about to use it.
			nObj.SetActive(true);
			//add it to the pool of objects
			pooledObjects.Add(nObj);
			//return the object to the requestor.
			return nObj;
		}
		//if we made it this far obviously we didn't have any inactive objects
		//we also were unable to grow, so return null as we can't return an object.
		return null;
	}
}