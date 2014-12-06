using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public static bool spawnable;
	private bool hit;

	void Start()
	{
		spawnable = false;
	}

	void OnMouseOver()
	{
		renderer.material.color -= new Color(2f, 0f, 2f) * Time.deltaTime;
		spawnable = true;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
		spawnable = false;
	}
}
