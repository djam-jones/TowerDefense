using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private float cooldown;
	public Transform bullet;
	public Transform spawnPoint;

	public static bool isActive;

	void Start () 
	{
		cooldown = 0f;
		isActive = false;
	}

	void Update () 
	{
		if(isActive == true)
		{
			if(cooldown > 0)
			{
				cooldown -= 0.1f;
			}

			if(cooldown <= 0)
			{
				Shooting();
				cooldown = 6f;
			}
		}
	}

	void Shooting()
	{
		Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
	}
}
