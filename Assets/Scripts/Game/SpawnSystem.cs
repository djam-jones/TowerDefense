using UnityEngine;
using System.Collections;

public class SpawnSystem : MonoBehaviour {

	//These are the Enemies that are eligible for the Waves
	public Transform[] AllEnemies;
	private int enemyIndex;

	//The amount of time between Waves and Enemies per wave
	private float spawnDelay = 2.5f;

	//The Current Wave Number
	private int currentWave = 1;
	private bool isSpawning;

	private int maxEnemies;

	private GameObject[] enemiesInScene;
	public Transform spawnPoint;

	void Start()
	{
		//Set the maximum amount of enemies for the first wave
		maxEnemies = 5;

		//Begin the First Wave
		StartCoroutine(NewWave());
	}

	void Update()
	{
		enemyIndex = Random.Range(0, AllEnemies.Length);

		if(!isSpawning)
		{
			//Check how many Enemies are still on the Field
			enemiesInScene = GameObject.FindGameObjectsWithTag("BasicGrunt");
			//If there aren't enemies left, increase current wave
			if(enemiesInScene.Length <= 0)
			{
				IncreaseWave();
			}
		}
	}

	IEnumerator NewWave()
	{
		//We are going to spawn a wave
		isSpawning = true;
		//Spawn up until the maximum number of enemies
		for(int i = 0; i < maxEnemies; i++)
		{
			//Delay between Spawning New Waves
			yield return new WaitForSeconds(spawnDelay);

			//Instantiate Basic Enemy at the spawn location if the wave number is or is below Wave 3
			if(currentWave <= 3)
			{
				Instantiate(AllEnemies[0], spawnPoint.position, spawnPoint.rotation);
			}
			//Instantiate either a Basic Enemy or a Heavy Enemy if the wave number is or is above Wave 4
			else if(currentWave >= 4)
			{
				Instantiate(AllEnemies[enemyIndex], spawnPoint.position, spawnPoint.rotation);
			}
		}

		//Done Spawning enemies for this round
		isSpawning = false;
	}

	void IncreaseWave()
	{
		//Increase the Current Wave by 1
		currentWave++;
		//Increase the Maximum amount of enemies per wave
		maxEnemies += 3;

		//Start the Next Wave
		StartCoroutine(NewWave());
	}

	void OnGUI()
	{
		//Display the Wave Number
		GUI.Label(new Rect(10, Screen.height - 20, 100, 30), "Wave: " + currentWave.ToString());
	}
}
