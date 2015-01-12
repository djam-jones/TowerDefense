using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	
	public Camera MainCam;
	public Camera TopCam;
	public Camera FreeCam;
	public Texture cameraIconTexture;
	
	void Start()
	{
		MainCam.enabled = true;
		TopCam.enabled = false;
		FreeCam.enabled = false;

		Screen.showCursor = true;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			MainCam.enabled = !MainCam.enabled;
			TopCam.enabled = !TopCam.enabled;
			FreeCam.enabled = false;
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			FreeCam.enabled = true;
		}
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width - 60, 10, 50, 50), cameraIconTexture, GUIStyle.none))
		{
			MainCam.enabled = !MainCam.enabled;
			TopCam.enabled = !TopCam.enabled;
		}
	}
}