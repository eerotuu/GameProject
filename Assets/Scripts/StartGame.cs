using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Start game control.
/// </summary>
public class StartGame : MonoBehaviour
{

	//saves pointercontroller for startgame button.
	private PointerController startgame;

	void Start ()
	{

		startgame = GameObject.Find ("Start").GetComponent<PointerController> ();

	}

	void Update ()
	{

		if (startgame.getPressed ()) {

			SceneManager.LoadScene ("main_scene");
		}

	}
}
