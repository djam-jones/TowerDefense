using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public static bool spawnable;
	public Material gridTile;
	public Material gridTileHover;

	void Start()
	{
		spawnable = false;
		renderer.material = gridTile;
	}

	void OnMouseOver()
	{
		renderer.material = gridTileHover;
		spawnable = true;
	}

	void OnMouseExit()
	{
		renderer.material = gridTile;
		spawnable = false;
	}
}
