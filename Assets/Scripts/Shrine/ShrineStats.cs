using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShrineStats : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;

	public Text displayText;

	void Start()
	{
		currentHealth = maxHealth;
	}

	void Update()
	{
		if(currentHealth >= maxHealth)
		{
			currentHealth = maxHealth;
		}
	}

	public void TakeDamage(float dmg)
	{
		//Health decreases with damage done
		currentHealth -= dmg;
		
		//If the health of the Shrine reaches zero. Destroy the Shrine and Lose the Game
		if(currentHealth <= 0)
		{
			displayText.text = "YOU LOSE!";
			Time.timeScale = 0;

			Death();
		}
	}
	
	void Death( )
	{
		Destroy(this.gameObject);
	}

}
