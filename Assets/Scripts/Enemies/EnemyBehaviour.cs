using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyBehaviour : MonoBehaviour {
	
	public Transform[] target;
	private Transform currentTarget;
	private int targetNr;
	private NavMeshAgent navMesh;
	private float shrineCounter;
	private float turretCounter;

	public float doneDMG;
	
	private Animator anim;
	
	void Start() 
	{
		navMesh = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
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
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Turret")
		{
			navMesh.speed = 0;
			Attack(other);
		}
		if (other.transform.tag == "Shrine") 
		{
			Attack (other);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Turret")
		{
			navMesh.speed = 5f;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.transform.tag == "Turret")
		{
			if(turretCounter > 8f)
			{
				Attack(other);
				turretCounter = 0f;
			}
		}
		else if(other.transform.tag == "Shrine")
		{
			if(shrineCounter > 9f)
			{
				Attack(other);
				shrineCounter = 0f;
			}
			
		}
		
		shrineCounter += Time.deltaTime;
	}
	
	public void Attack(Collider other)
	{
		if (other.transform.tag == "Shrine") 
		{
			other.gameObject.GetComponent<ShrineStats>().TakeDamage(doneDMG);
			anim.SetTrigger("StartAttack");
		}
		else if (other.transform.tag == "Turret")
		{
			other.gameObject.GetComponent<AllTurret>().TakeDamage(doneDMG);
			anim.SetTrigger("StartAttack");
		}
	}
}