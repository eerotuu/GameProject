using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera controller.
/// </summary>
public class CameraController : MonoBehaviour
{

	public GameObject player;
	private static CameraController CameraInstance;

	//Private variable to store the offset distance between the player and camera
	private Vector3 offset;




	// Use this for initialization
	void Start ()
	{
		transform.position = new Vector3 (0, 0, -10) + player.transform.position;
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;

	}

	// LateUpdate is called after Update each frame
	void LateUpdate ()
	{
		//Sets the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;

	}
}