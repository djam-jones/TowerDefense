using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private float cooldown;
	public Transform bullet;
	public Transform spawnPoint;

	public bool isActive;

	private Animator anim;

	void Start () 
	{
		cooldown = 0f;
		isActive = false;

		anim = gameObject.GetComponentInParent<Animator>();
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
				anim.SetTrigger("StartShoot");

				Shooting();
				cooldown = 6.5f;
			}
		}
		else if(isActive == false)
		{
			anim.SetTrigger("StopShoot");
		}
	}

	void Shooting()
	{
		audio.Play();
		Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
	}
}