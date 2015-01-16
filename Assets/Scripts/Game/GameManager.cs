using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Cheat Code(s)
	private string[] moneyCheat;
	private string[] killEnemiesCheat;
	private string[] timeCheat;
	private int moneyIndex;
	private int enemyIndex;
	private int timeIndex;

	private GameObject[] enemies;

	//Integers for the amount of Gold and Points
	public int totalGold;
	public int totalPoints;

	public Text scoreText;
	public Text goldText;

	void Start()
	{
		totalGold = 250;

		//Strings for The Cheatcodes
		moneyCheat = new string[] {
			"g", "e", "t", "t", "i", "n", "m", "o", "n", "e", "y"
		};
		killEnemiesCheat = new string[] {
			"r", "e", "k", "k", "i", "n", "f", "o", "o", "l", "s"
		};
		timeCheat = new string[] {
			"s", "p", "e", "e", "d", "u", "p", "s"
		};

		moneyIndex 	= 0;
		enemyIndex 	= 0;
		timeIndex 	= 0;
	}

	void Update()
	{
		scoreText.text = "Score: " + totalPoints.ToString();
		goldText.text = "Gold: " + totalGold.ToString();

		//Cheat Code for Money
		GetMoneyCheat();

		//Cheat Code for Enemies
		KillAllEnemies();

		//Cheat Code for Time
		// SpeedUpTime();
	}

	public void AddGold(int earnedGold)
	{
		totalGold += earnedGold;
	}

	public void AddScore(int points)
	{
		totalPoints += points;
	}

	public void LoseGold(int amount)
	{
		totalGold -= amount;
	}

	//Cheats
	void GetMoneyCheat()
	{
		if(Input.anyKeyDown)
		{
			if(Input.GetKeyDown(moneyCheat[moneyIndex]))
			{
				moneyIndex++;
			}
			else
			{
				moneyIndex = 0;
			}
		}
		
		if(moneyIndex == moneyCheat.Length)
		{
			totalGold = 1000000;

			moneyIndex = 0;
		}
	}

	void KillAllEnemies()
	{
		if(Input.anyKeyDown)
		{
			if(Input.GetKeyDown(killEnemiesCheat[enemyIndex]))
			{
				enemyIndex++;
			}
			else
			{
				enemyIndex = 0;
			}
		}
		
		if(enemyIndex == killEnemiesCheat.Length)
		{
			enemies = GameObject.FindGameObjectsWithTag("Grunt");

			for(int i = 0; i < enemies.Length; i++)
			{
				totalPoints += 300;

				Destroy(enemies[i]);
			}

			enemyIndex = 0;
		}
	}

	void SpeedUpTime()
	{
		if(Input.anyKeyDown)
		{
			if(Input.GetKeyDown(timeCheat[timeIndex]))
			{
				timeIndex++;
			}
			else
			{
				timeIndex = 0;
			}
		}

		if(timeIndex == timeCheat.Length)
		{
			Time.timeScale *= 2;
			timeIndex = 0;
		}
	}
}