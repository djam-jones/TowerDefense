﻿using UnityEngine;
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

	void Start() 
	{
		turretSelected = false;
		yAxis = allTurrets[selectedTower].transform.position.y;
	}

	void Update()
	{
		//SelectTurret();
		Spawn();
	}
	
//	void SelectTurret()
//	{
//		if(Input.GetKeyDown(KeyCode.Q))
//		{
//			print("Standard Turret Selected.");
//			turretSelected = true;
//		}
//	}

	void OnGUI()
	{
		//Buttons for Turret Selection
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, 0, 600, 100));

		GUI.Box(new Rect(0, 0, 400, 100), "Select a Turret");

		if(GUI.Button(new Rect(40, 30, 100, 50), "Standard Turret") || Input.GetKeyDown(KeyCode.Alpha1))
		{
			print("Standard Turret Selected.");
			turretSelected = true;

			selectedTower = 0;
		}
		if(GUI.Button(new Rect(150, 30, 100, 50), "Rapid Turret") || Input.GetKeyDown(KeyCode.Alpha2))
		{
			print("Rapid Turret Selected.");
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
