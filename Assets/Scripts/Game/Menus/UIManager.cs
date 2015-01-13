using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	//Boolean for pausing
	private bool pausing;

	//Booleans for certain Menus
	private bool showPauseMenu = false;
	private GameObject pauseMenu;

	//Textures for Buttons
	public Texture settingsTexture;

	void Start()
	{
		DontDestroyOnLoad(pauseMenu);
		pauseMenu = GameObject.Find("Pause Menu");
	}

	void Update()
	{
		//Camera.main.transform.position += transform.forward * (0.1f * Time.deltaTime);

		if(pausing)
		{
			PauseGame();
		}
		else
		{
			ResumeGame();
		}

		if(showPauseMenu == true)
		{
			pauseMenu.SetActive(true);
		}
		else if(showPauseMenu == false)
		{
			pauseMenu.SetActive(false);
		}
	}

	void OnGUI()
	{
		//Pause Button
		if(GUI.Button(new Rect(10, 10, 50, 50), settingsTexture, GUIStyle.none) || Input.GetKeyDown(KeyCode.P) && Application.loadedLevelName != "MainMenu")
		{
			pausing = true;
		}
	}

	public void StartGame()
	{
		StartCoroutine(ChangeLevel("Level_1"));
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void ToWebsite()
	{
		Application.OpenURL("http://twilighthour-game.clistoentertainment.com/");
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		showPauseMenu = true;
	}
	public void ResumeGame()
	{
		pausing = false;
		Time.timeScale = 1;
		showPauseMenu = false;
	}

	public void BackToMenu()
	{
		print("Back To Menu");

		pausing = false;
		Time.timeScale = 1;
		StartCoroutine(ChangeLevel("MainMenu"));
	}

	IEnumerator ChangeLevel(string lvlIndex)
	{
		float fadeTime = GameObject.Find("GameManager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(lvlIndex);
	}
}
