﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Actions : MonoBehaviour {

	//The Turret Object
	private bool turretSelected;
	public bool canSelect;
	public GameObject[] allTurrets;
	private int selectedTower;

	//The Turret Destination
	private Vector3 turPos;

	private GameManager gm;
	public Text displayText;

	//Vertical Position of the Turret
	private float yAxis;

	void Start() 
	{
		gm = gameObject.GetComponent<GameManager>();

		canSelect = true;
		turretSelected = false;
		yAxis = allTurrets[selectedTower].transform.position.y + transform.lossyScale.y;
	}
	
	void Update()
	{
		Spawn();

		if(Input.GetKey(KeyCode.Z) && turretSelected == true)
		{
			Debug.Log("Deselect");
			
			canSelect = true;
			turretSelected = false;
			
			if(selectedTower == 0)
			{
				gm.totalGold += 100;
			}
			else if(selectedTower == 1)
			{
				gm.totalGold += 150;
			}
			else if(selectedTower == 2)
			{
				gm.totalGold += 250;
			}
		}
	}
	
	//Buttons for Selecting the different kinds of Turrets
	void OnGUI()
	{
		//Buttons for Turret Selection
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 100));

		GUI.Box(new Rect(0, 0, 400, 100), "Select a Turret");

		if(canSelect)
		{
			if(GUI.Button(new Rect(40, 30, 100, 50), "Standard Turret" + "\n" + "Cost: 100") || Input.GetKey (KeyCode.Alpha1))
			{
				if(gm.totalGold >= 100)
				{
					turretSelected = true;
					gm.totalGold -= 100;
					selectedTower = 0;
					canSelect = false;
				}
				else if(gm.totalGold != 100)
				{
					turretSelected = false;
					canSelect = true;
					print("Insufficient Funds!");
					displayText.text = "Insufficient Funds!";
				}
			}
			if(GUI.Button(new Rect(150, 30, 100, 50), "Defence Turret" + "\n" + "Cost: 150") || Input.GetKey (KeyCode.Alpha2))
			{
				if(gm.totalGold >= 150)
				{
					turretSelected = true;
					gm.totalGold -= 150;
					selectedTower = 1;
					canSelect = false;
				}
				else if(gm.totalGold != 150)
				{
					turretSelected = false;
					canSelect = true;
					print("Insufficient Funds!");
					displayText.text = "Insufficient Funds!";
				}
			}
			if(GUI.Button(new Rect(260, 30, 100, 50), "Heavy Turret" + "\n" + "Cost: 250") || Input.GetKey (KeyCode.Alpha3))
			{
				if(gm.totalGold >= 250)
				{
					turretSelected = true;
					gm.totalGold -= 250;
					selectedTower = 2;
					canSelect = false;
				}
				else if(gm.totalGold != 250)
				{
					turretSelected = false;
					canSelect = true;
					print("Insufficient Funds!");
					displayText.text = "Insufficient Funds!";
				}
			}
		}

		GUI.EndGroup();
	}

	//Spawn the Selected Turret on the Place you have clicked on
	void Spawn()
	{
		if(turretSelected && Input.GetMouseButtonDown(1))
		{
			canSelect = true;
			turretSelected = false;

			Ray ray;
			RaycastHit hit;

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 1 << 6))
			{
				turPos = hit.point;
				turPos.y = yAxis;

				Instantiate(allTurrets[selectedTower], turPos, Quaternion.identity);
				audio.Play();
			}
		}
	}
}
