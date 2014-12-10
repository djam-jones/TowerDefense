using UnityEngine;
using System.Collections;

public class AllTurret : MonoBehaviour {

	private float armor;
	public static float rateOfFire;

	void Start()
	{
		//
	}

	void Update()
	{
		if(this.transform.tag == "StandardTurret")
		{
			armor = 100f;
			rateOfFire = 5f;
		}
		else if(this.transform.tag == "HeavyTurret")
		{
			armor = 75f;
			rateOfFire = 10f;
		}
		else if(this.transform.tag == "DefenceTurret")
		{
			armor = 200f;
			rateOfFire = 0f;
		}


	}
}
