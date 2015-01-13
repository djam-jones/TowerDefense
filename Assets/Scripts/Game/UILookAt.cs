using UnityEngine;
using System.Collections;

public class UILookAt : MonoBehaviour {

	public Camera maincam;

	void Update() 
	{
		transform.LookAt(maincam.transform.position);
	}
}
