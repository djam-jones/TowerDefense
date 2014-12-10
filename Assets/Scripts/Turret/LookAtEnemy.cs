using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LookAtEnemy : MonoBehaviour {

	private GameObject target;
	private List<Transform> inRange = new List<Transform>();
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
			Vector3 relativePos = inRange[0].transform.position - transform.position;
			Quaternion enemyLookAt = Quaternion.LookRotation(relativePos);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, enemyLookAt, Time.deltaTime * rotationSpeed);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "BasicGrunt")
		{
			inRange.Add(other.transform);
			shootActive.isActive = true;
		}
		else if(other.tag == "HeavyGrunt")
		{
			inRange.Add(other.transform);
			shootActive.isActive = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "BasicGrunt")
		{
			inRange.Remove(other.transform);
			shootActive.isActive = false;
		}
		else if(other.tag == "HeavyGrunt")
		{
			inRange.Remove(other.transform);
			shootActive.isActive = false;
		}

		if(other.tag == null)
		{
			inRange.Remove(other.transform);
			shootActive.isActive = false;
		}
	}
}