using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Textures for Buttons
	public Texture pauseTexture;
	public Texture playTexture;
	public Texture settingsTexture;
	private Texture newTexture;

	//Boolean for pausing
	private bool pausing;

	//Integers for the amount of Gold and Points
	public int totalGold;
	public int totalPoints;

	public bool upgradesAvailable;

	//Booleans for certain Menus
	private bool showPauseMenu = false;
	
	void Start()
	{
		totalGold = 100;
		newTexture = settingsTexture;
	}

	void Update()
	{
		if(pausing)
		{
			PauseGame();
		}
		else
		{
			ResumeGame();
		}
	}

	public void AddGold(int earnedGold)
	{
		totalGold += earnedGold;

//		if(totalGold >= 150f && PlayerStats.level == 4)
//		{
//			upgradesAvailable = true;
//		}
//		else
//		{
//			upgradesAvailable = true;
//		}
	}

	public void AddScore(int points)
	{
		totalPoints += points;
	}

	void OnGUI()
	{
		//Pause Button
		if(GUI.Button(new Rect(10, 10, 50, 50), newTexture, GUIStyle.none) || Input.GetKeyDown(KeyCode.P))
		{
			print("Game Paused");
			pausing = true;
		}

		//Display Your Score
		GUI.Label(new Rect(10, Screen.height - 60, 100, 30), "Score: " + totalPoints.ToString());

		//Display the Amount of Gold
		GUI.Label(new Rect(10, Screen.height - 40, 100, 30), "Gold: " + totalGold.ToString());

		if(showPauseMenu == true)
		{
			GUI.BeginGroup(new Rect(Screen.width/2 - 50, Screen.height/2 - 60, 400, 360));
			
			GUI.Box(new Rect(0, 0, 100, 150), "Menu");
			if(GUI.Button(new Rect(10, 30, 80, 20), "Resume"))
			{
				print("RESUME Game");
				pausing = false;
			}
			if(GUI.Button(new Rect(10, 60, 80, 20), "Options"))
			{
				print("OPENING Options Screen");
				//Open Options Menu;
			}
			if(GUI.Button(new Rect(10, 120, 80, 20), "Main Menu"))
			{
				print("RETURNING to Menu");
				Application.LoadLevel("MainMenu");
			}
			
			GUI.EndGroup();
		}
	}
	
	void PauseGame()
	{
		Time.timeScale = 0;
		showPauseMenu = true;
	}
	void ResumeGame()
	{
		Time.timeScale = 1;
		showPauseMenu = false;
	}
}