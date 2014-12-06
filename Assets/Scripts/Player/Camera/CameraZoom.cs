using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	float minFov = 50f;
	float maxFov = 114f;
	float mouseSensitivity = 50f;
	float damping = 5f;

	float fov;

	void Start() 
	{
		fov = Camera.main.fieldOfView;
	}

	void Update() 
	{
		fov -= Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fov, Time.deltaTime * damping);
		//Camera.main.fieldOfView = fov;
	}
}
