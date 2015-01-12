using UnityEngine;
using System.Collections;

public class HPBarController : MonoBehaviour {

	private Vector3 target;
	private Camera maincamera;
	private Camera topcamera;
	//private Camera freecamera;

	public Texture LifeBarBack;
	public Texture LifeBarFront;

	private float lifeRatio;
	private float barWidth;
	private float barHeight;
	private float lifeWidth;

	private EnemyStats enemy;
	private AllTurret turret;
	private ShrineStats shrine;

	void Start()
	{
		//Set Object with HP
		enemy = GetComponentInParent<EnemyStats>();
		turret = GetComponentInParent<AllTurret>();
		shrine = GetComponentInParent<ShrineStats>();

		//Sets the Cameras for different views
		maincamera = GameObject.Find("Main Camera").camera;
		topcamera = GameObject.Find("Top Camera").camera;
		//freecamera = GameObject.Find("Free Camera").camera;

		//Sets the width and height for the HP Bar
		barWidth = 60f;
		barHeight = 6f;
	}

	void Update()
	{
		//Determines the size of the HP Bar with the amount of HP it has
		if(enemy != null)
		{
			lifeRatio = enemy.currentHealth / enemy.maxHealth;
		}
		else if(turret != null)
		{
			lifeRatio = turret.currentArmor / turret.maxArmor;
		}
		else if(shrine != null)
		{
			lifeRatio = shrine.currentHealth / shrine.maxHealth;

			barWidth = 120;
			barHeight = 12;
		}

		lifeWidth = lifeRatio * barWidth;
	}

	void OnGUI()
	{
		if(lifeRatio > 0 && lifeRatio < 150)
		{
			//Displays the HP Bar, current HP and max HP that the GO has with the Main Camera view
			if(maincamera.enabled)
			{
				target = maincamera.WorldToScreenPoint(transform.position);

				GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 40), barWidth, barHeight), LifeBarBack);
				GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 40), lifeWidth, barHeight), LifeBarFront);

				if(enemy)
				{
					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 60), 60, 20), enemy.currentHealth + "/" + enemy.maxHealth);
				}
				else if(turret)
				{
					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 60), 60, 20), turret.currentArmor + "/" + turret.maxArmor);
					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 75), 60, 20), "Level: " + turret.lvl);
				}
				else
				{
					GUI.Label(new Rect(target.x - (barWidth / 4f), Screen.height - (target.y + 60), 60, 20), shrine.currentHealth + "/" + shrine.maxHealth);
				}
			}
			//Displays the HP Bar, current HP and max HP that the GO has with the Top Camera view
			else if(topcamera.enabled)
			{
				target = topcamera.WorldToScreenPoint(transform.position);

				GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 20), barWidth, barHeight), LifeBarBack);
				GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 20), lifeWidth, barHeight), LifeBarFront);

				if(enemy)
				{
					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 40), 60, 20), enemy.currentHealth + "/" + enemy.maxHealth);
				}
				else if(turret)
				{
					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 40), 60, 20), turret.currentArmor + "/" + turret.maxArmor);
					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 55), 40, 20), "Level: " + turret.lvl);
				}
				else
				{
					GUI.Label(new Rect(target.x - (barWidth / 4f), Screen.height - (target.y + 40), 60, 20), shrine.currentHealth + "/" + shrine.maxHealth);
				}
			}
			//Displays the HP Bar, current HP and max HP that the GO has with the Free Camera view
//			else
//			{
//				target = freecamera.WorldToScreenPoint(transform.position);
//				
//				GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 80), barWidth, barHeight), LifeBarBack);
//				GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 80), lifeWidth, barHeight), LifeBarFront);
//				
//				if(enemy)
//				{
//					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 100), 60, 20), enemy.currentHealth + "/" + enemy.maxHealth);
//				}
//				else if(turret)
//				{
//					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 100), 60, 20), turret.currentArmor + "/" + turret.maxArmor);
//					GUI.Label(new Rect(target.x - (barWidth / 2.5f), Screen.height - (target.y + 115), 60, 20), "Level: " + turret.lvl);
//				}
//				else
//				{
//					GUI.Label(new Rect(target.x - (barWidth / 4f), Screen.height - (target.y + 100), 60, 20), shrine.currentHealth + "/" + shrine.maxHealth);
//				}
//			}
		}
	}

}
