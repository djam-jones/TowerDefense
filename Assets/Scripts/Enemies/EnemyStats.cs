using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public bool dead;

	private GameManager gm;
	private GameObject gameManager;

	private LookAtEnemy lae;
	private GameObject[] turrets;

	public int gold;
	public int points;

	void Start()
	{
		currentHealth = maxHealth;

		gameManager = GameObject.FindGameObjectWithTag("GameController");
		gm = gameManager.GetComponent<GameManager>();

		turrets = GameObject.FindGameObjectsWithTag("TurretEye");

		dead = false;

		gold = Random.Range(100, 125);
		points = Random.Range(74, 92);
	}

	void Update()
	{
		//
	}

	public void TakeDamage(float dmg)
	{
		//Health decreases with damage done
		currentHealth -= dmg;

		//If the health of the Enemy reaches zero. Destroy Enemy and add Gold & Score
		if(currentHealth <= 0)
		{
			dead = true;

			foreach(GameObject t in turrets)
			{
				lae = t.GetComponent<LookAtEnemy>();
			}

			if(lae)
			{
				lae.inRange.Remove(this.transform);
				Invoke("Death", 1f);
			}

			if(gm)
			{
				//Add Gold
				gm.AddGold(gold);
				
				//Add Score
				gm.AddScore(points);
			}
		}
	}

	void Death( )
	{
		Destroy(this.gameObject);
	}
}
