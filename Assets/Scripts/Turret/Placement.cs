using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Placement : MonoBehaviour {

	private bool _hitting;
	public static bool buildAble;

	private List<Material> allChildrenMaterials = new List<Material>();

	void Start()
	{
		Renderer[] allChildrenRenderers = GetComponentsInChildren<Renderer>();
		foreach(Renderer renderer in allChildrenRenderers)
		{
			allChildrenMaterials.Add(renderer.material);
		}
	}

	void Update()
	{
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 2f);
		int wallcounter = 0;
		for (int i = 0; i < hitColliders.Length; i++) {
			string colliderTag = hitColliders[i].transform.tag;
			if(colliderTag != "Level")
			{
				if(hitColliders[i].isTrigger == false)
				{
					_hitting = true;
					break;
				}
			}
		}

		if(!_hitting)
		{
			ChangeColor(Color.green);
			buildAble = true;
		} else {
			ChangeColor(Color.red);
			buildAble = false;
		}
	}

	private void ChangeColor(Color color)
	{
		Color newColor = color;
		newColor.a = 0.5f;
		foreach(Material material in allChildrenMaterials)
		{
			material.color = newColor;
		}
	}
}
