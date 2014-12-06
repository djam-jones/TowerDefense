using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	private float destroyTime = 5f;
	private float speed = 75f;
	
	void Start() 
	{
		Destroy(gameObject, destroyTime);
	}
	
	void Update() 
	{
		this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
	
	void OnCollisionEnter (Collision other)
	{
		if(other.transform.tag != "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
