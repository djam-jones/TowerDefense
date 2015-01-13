using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LookAtEnemy : MonoBehaviour {

	public List<GameObject> inRange = new List<GameObject>();
	public float rotationSpeed;

	private Shoot shootActive;

	void Start()
	{
		shootActive = GetComponent<Shoot>();
	}

	void Update()
	{
		if(inRange.Count > 0)
		{
			if (inRange[0] == null)
			{
				inRange.RemoveAt(0);
			}
			else
			{
				Vector3 relativePos = inRange[0].transform.position - transform.position;
				Quaternion enemyLookAt = Quaternion.LookRotation(relativePos);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, enemyLookAt, Time.deltaTime * rotationSpeed);
			}
		}
		else
		{
			shootActive.isActive = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Grunt")
		{
			inRange.Add(other.gameObject);
			shootActive.isActive = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Grunt")
		{
			RemoveFromList(other.gameObject);
			shootActive.isActive = false;
		}
		else if(other.transform.tag == null)
		{
			RemoveFromList(other.gameObject);
			shootActive.isActive = false;
		}
	}

	void RemoveFromList(GameObject obj)
	{
		if (inRange.Contains(obj))
		    inRange.Remove(obj);
	}
}