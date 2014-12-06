using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public Texture pauseTexture;
	public Texture playTexture;
	private Texture newTexture;

	private bool isPaused;
	private bool pausing;

	private bool showPauseMenu = false;
	
	void Start()
	{
		//
	}

	void Update()
	{
		if(isPaused)
		{
			newTexture = playTexture;
		}
		else if(!isPaused)
		{
			newTexture = pauseTexture;
		}

		if(pausing)
		{
			PauseGame();
		}
		else
		{
			ResumeGame();
		}
	}

	void OnGUI()
	{
		//Pause Button
		if(GUI.Button(new Rect(10, 10, 50, 50), newTexture, GUIStyle.none) || Input.GetKeyDown(KeyCode.P))
		{
			print("Game Paused");
			pausing = true;
		}

		if(showPauseMenu == true)
		{
			GUI.BeginGroup(new Rect(Screen.width/2 - 50, Screen.height/2 - 60, 400, 360));
			
			GUI.Box(new Rect(0, 0, 100, 150), "Menu");
			if(GUI.Button(new Rect(10, 30, 80, 20), "Resume"))
			{
				print("RESUME Game");
				ResumeGame();
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
		isPaused = true;
		Time.timeScale = 0;
		showPauseMenu = true;
	}
	void ResumeGame()
	{
		isPaused = false;
		Time.timeScale = 1;
		showPauseMenu = false;
	}
}