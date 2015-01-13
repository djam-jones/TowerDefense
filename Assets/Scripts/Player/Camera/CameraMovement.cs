using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public Transform player;
	private float damp = 3.5f;
	private Vector3 newPosition;
	
	private Vector3 offset;

	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate()
	{
		Vector3 desiredPos = player.transform.position + offset;
		Vector3 position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * damp);
		transform.position = position;

		transform.LookAt(player.transform.position);
	}
}
