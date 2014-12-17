using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	protected 	float 			destroyTime 	= 4f;
	protected 	float 			speed 			= 100f;
	private 	float 			mass			= 10f;
	private		GameObject		target;
	private		Vector3			targetPos		= Vector3.zero;
	private		LookAtEnemy		lae;

	protected float bulletDMG;
	
	void Start() 
	{
		//rigidbody.velocity = new Vector3(0, 0, 1) * speed;
		target = null;

		Destroy(this.gameObject, destroyTime);
		bulletDMG = Random.Range(15, 20);
	}
	
	void Update() 
	{
		//Seek();

		this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void Seek()
	{
		if(target != null)
		{
			targetPos = target.transform.position;
		}
		if(targetPos != null)
		{
			Vector3 desiredStep				=	targetPos - rigidbody.position;		
			desiredStep.Normalize();
			Vector3 desiredVelocity			=	desiredStep	* speed;
			Vector3 steeringForce			=	desiredVelocity - rigidbody.velocity;
			rigidbody.velocity				=	rigidbody.velocity + steeringForce / mass;
		} 
		else 
		{
			//transform.position += Vector3.forward * speed / 2 * Time.deltaTime;
			this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		Vector3 currentPos				=	rigidbody.position;
		currentPos.y = 1;
		rigidbody.position				=	currentPos;
	}

	void OnTriggerEnter(Collider myTarget)
	{
		if(target == null)
		{
			if(myTarget.transform.tag == "Grunt")
			{
				FindTarget(this.transform.position);
			}
		}
	}

	void FindTarget(Vector3 pos)
	{
		Collider[] cols = Physics.OverlapSphere(pos, 0.1f);

		float dist = Mathf.Infinity;
		GameObject nearest = null;

		foreach(Collider col in cols)
		{
			float d = Vector3.Distance(pos, col.transform.position);
			if(d < dist)
			{
				dist = d;
				nearest = col.gameObject;
			}
		}
		target = nearest;
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Grunt")
		{
			other.gameObject.GetComponent<EnemyStats>().TakeDamage(bulletDMG);
			Destroy(this.gameObject);
		}

		if(other.transform.tag != "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
