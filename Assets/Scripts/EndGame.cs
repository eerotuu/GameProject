using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// End game button control.
/// </summary>
public class EndGame : MonoBehaviour
{


	private PointerController endgame;

	void Start ()
	{

		endgame = GameObject.Find ("Start").GetComponent<PointerController> ();

	}

	void Update ()
	{

		if (endgame.getPressed ()) {
			DestroyObject (GameObject.Find ("Music"));
			SceneManager.LoadScene ("main_menu");
		}

	}
}
