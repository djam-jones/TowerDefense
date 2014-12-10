using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour {

	//The Turret Object
	private bool turretSelected;
	public GameObject[] allTurrets;
	private int selectedTower;

	//The Turret Destination
	private Vector3 turPos;

	//Vertical Position of the Turret
	private float yAxis;

	//Box containing Turret Selection Buttons
	private Rect ButtonBox = new Rect(0, 0, 400, 100);
	private Movement movementScript;

	void Start() 
	{
		turretSelected = false;
		yAxis = allTurrets[selectedTower].transform.position.y + transform.lossyScale.y;
		movementScript = GetComponent<Movement>();
	}

	void Update()
	{
		Spawn();

		//This will determine whether or not the mouse is in the box, so that it can prevent moving upon click a button
		if(ButtonBox.Contains(Input.mousePosition))
		{
			movementScript.mouseOnGUI = true;
			//Debug.Log("Mouse On GUI is " + movementScript.mouseOnGUI + " On Position: " + Input.mousePosition);
		}
		else
		{
			movementScript.mouseOnGUI = false;
			//Debug.Log("Mouse On GUI is " + movementScript.mouseOnGUI);
		}
	}

	//Buttons for Selecting the different kinds of Turrets
	void OnGUI()
	{
		//Buttons for Turret Selection
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, 0, 400, 100));

		GUI.Box(ButtonBox, "Select a Turret");

		if(GUI.Button(new Rect(40, 30, 100, 50), "Standard Turret") || Input.GetKeyDown(KeyCode.Alpha1))
		{
			print("Standard Turret Selected.");
			turretSelected = true;

			selectedTower = 0;
		}
		if(GUI.Button(new Rect(150, 30, 100, 50), "Defence Turret") || Input.GetKeyDown(KeyCode.Alpha2))
		{
			print("Defence Turret Selected.");
			turretSelected = true;

			selectedTower = 1;
		}
		if(GUI.Button(new Rect(260, 30, 100, 50), "Heavy Turret") || Input.GetKeyDown(KeyCode.Alpha3))
		{
			print("Heavy Turret Selected.");
			turretSelected = true;

			selectedTower = 2;
		}

		GUI.EndGroup();
	}

	//Spawn the Selected Turret on the Hotspot you have clicked on
	void Spawn()
	{
		if(Base.spawnable && turretSelected && Input.GetMouseButtonDown(0))
		{
			turretSelected = false;

			Ray ray;
			RaycastHit hit;

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				turPos = hit.point;
				turPos.y = yAxis;

				Instantiate(allTurrets[selectedTower], turPos, Quaternion.identity);
				print("Placed Turret");
			}
		}
	}
}
