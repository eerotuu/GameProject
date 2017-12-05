using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Button Control for some menu buttons.
/// </summary>
public class StartButton : MonoBehaviour
{
	//Saves pointer controllers for menu buttons.
	private PointerController button;
	private PointerController credits;
	private PointerController exit;

	void Start ()
	{
		button = GameObject.Find ("StartGame").GetComponent<PointerController> ();
		credits = GameObject.Find ("Credits").GetComponent<PointerController> ();
		exit = GameObject.Find ("ExitGame").GetComponent<PointerController> ();


	}

	void Update ()
	{
		if (button.getPressed ()) {
			SceneManager.LoadScene ("intro");
		}

		if (credits.getPressed ()) {
			
			SceneManager.LoadScene ("Credits");
		}
		if (exit.getPressed ()) {
			//Debug.Log ("peliloppu");
			Application.Quit ();

		}

	}
}
