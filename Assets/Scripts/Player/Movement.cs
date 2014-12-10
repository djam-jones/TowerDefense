using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	//Destination Point
	private Vector3 newPos;
	private Quaternion newRot;

	//Declare speed of the Player/Object
	private float duration = 15f;
	private float rotSpeed = 7f;

	//Set to true if mouse button is clicked
	private bool flag = false;
	public bool mouseOnGUI;

	//Vertical Position of the Player/Object
	private float yAxis;
	
	void Start() 
	{
		yAxis = gameObject.transform.position.y;
	}
	
	void Update()
	{	
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray;

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 100))
			{
				flag = true;
				newPos = hit.point;
				newPos.y = yAxis;
			}
		}
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, newPos.magnitude))
		{
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos, 1/(duration * Vector3.Distance(gameObject.transform.position, newPos)));
			MoveToPos();
		}
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, newPos.magnitude))
		{
			flag = false;
			Debug.Log("Destination Reached.");
		}
	}

	void MoveToPos()
	{
		Quaternion newRot = Quaternion.LookRotation(newPos - transform.position);

		transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotSpeed);
	}
}