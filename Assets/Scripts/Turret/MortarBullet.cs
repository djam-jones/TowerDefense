using UnityEngine;
using System.Collections;

public class MortarBullet : Bullet {

	void Start()
	{
		bulletDMG 	= Random.Range(40, 52);
		speed 		= 60f;
		destroyTime = 6f;
	}

	void Update()
	{
		this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
