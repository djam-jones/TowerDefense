using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	
	public Camera MainCam;
	public Camera TopCam;
	public Texture cameraIconTexture;
	
	void Start()
	{
		MainCam.enabled = true;
		TopCam.enabled = false;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			MainCam.enabled = !MainCam.enabled;
			TopCam.enabled = !TopCam.enabled;
		}
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width - 60, 10, 50, 50), cameraIconTexture, GUIStyle.none) || Input.GetKeyDown(KeyCode.C))
		{
			MainCam.enabled = !MainCam.enabled;
			TopCam.enabled = !TopCam.enabled;
		}
	}
}