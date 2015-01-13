using UnityEngine;
using System.Collections;

public class FreeCamMovement : MonoBehaviour {

	private float speed = 10f;
	private float speedMult = 1.5f;

	private float sensitivity = 5f;
	private float x;
	private float y;

	void Start()
	{
		Screen.showCursor = true;
	}

	void Update () {

		if(this.camera.enabled)
		{
			//Move the Camera Left, Right, Up and Down
			transform.position += transform.forward * ((speed * speedMult) * Input.GetAxis("Vertical") * Time.deltaTime);
			transform.position += transform.right * ((speed * speedMult) * Input.GetAxis("Horizontal") * Time.deltaTime);

			if(Input.GetKey(KeyCode.E))
			{
				transform.position += transform.up * (speed * Time.deltaTime);
			}
			else if(Input.GetKey(KeyCode.Q))
			{
				transform.position -= transform.up * (speed * Time.deltaTime);
			}

			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				speed = (speed * 3);
			}
			else if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				speed = (speed / 3);
			}

			if(Input.GetKeyDown(KeyCode.LeftAlt))
			{
				speed = (speed / 3);
			}
			else if(Input.GetKeyUp(KeyCode.LeftAlt))
			{
				speed = (speed * 3);
			}

			if(Input.GetMouseButton(1)) 
			{
				Screen.showCursor = false;
				Screen.lockCursor = true;

				x += Input.GetAxis("Mouse X") * sensitivity;
				y += Input.GetAxis("Mouse Y") * sensitivity;
				y = Mathf.Clamp(y, -65, 65);

				transform.localRotation = Quaternion.AngleAxis(x, Vector3.up);
				transform.localRotation *= Quaternion.AngleAxis(y, Vector3.left);
			}
			else {
				Screen.showCursor = true;
				Screen.lockCursor = false;
			}
		}
	}
}
