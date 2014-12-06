using UnityEngine;
using System.Collections;

public class AllTurret : MonoBehaviour {

	public enum TurretKind {
		StandardTurret,
		HeavyTurret,
		RapidTurret
	}

	public TurretKind currentTurret;
	public bool hitting = false;

	private float armor;

	void Start()
	{

	}

	void Update()
	{
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 1f);
		for (int i = 0; i < hitColliders.Length; i++) {
			if(hitColliders[i].transform.tag != "Hotspot" && !hitColliders[i].isTrigger)
			{
				hitting = true;
				break;
			} else {
				hitting = false;
			}
		}

//		if(currentTurret == Turret.StandardTurret)
//		{
//			armor = 100f;
//		}
//		else if(currentTurret == Turret.HeavyTurret)
//		{
//			armor = 200f;
//		}
//		else if(currentTurret = Turret.RapidTurret)
//		{
//			armor = 75f;
//		}
	}
}
