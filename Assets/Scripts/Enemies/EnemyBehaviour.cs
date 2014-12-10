﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyBehaviour : MonoBehaviour {
	
	public Transform[] target;
	private Transform currentTarget;
	private int targetNr;
	private NavMeshAgent navMesh;

	void Start() 
	{
		navMesh = GetComponent<NavMeshAgent>();
	}

	void Update() 
	{
		navMesh.destination = target[targetNr].position;

		float dist = Vector3.Distance(target[targetNr].position, transform.position);
		currentTarget = target[targetNr];

		if(dist < 1f)
		{
			navMesh.destination = navMesh.nextPosition;

			if(targetNr < target.Length)
			{
				targetNr++;
				navMesh.nextPosition = target[targetNr].position;
			}
		}
	}
}