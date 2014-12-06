using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LookAtEnemy : MonoBehaviour {

	private GameObject target;
	public static List<Transform> inRange = new List<Transform>();
	public float rotationSpeed;

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
		if(other.tag == "EnemyNormal")
		{
			inRange.Add(other.transform);
			Shoot.isActive = true;
		}
		else if(other.tag == "EnemyFast")
		{
			inRange.Add(other.transform);
			Shoot.isActive = true;
		}
		else if(other.tag == "EnemyStrong")
		{
			inRange.Add(other.transform);
			Shoot.isActive = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "EnemyNormal")
		{
			inRange.Remove(other.transform);
			Shoot.isActive = false;
		}
		else if(other.tag == "EnemyFast")
		{
			inRange.Remove(other.transform);
			Shoot.isActive = false;
		}
		else if(other.tag == "EnemyStrong")
		{
			inRange.Remove(other.transform);
			Shoot.isActive = false;
		}

		if(other.tag == null)
		{
			inRange.Remove(other.transform);
			Shoot.isActive = false;
		}
	}
}