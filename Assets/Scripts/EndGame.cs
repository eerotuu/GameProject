using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {


	private PointerController endgame;

	void Start()
	{

		endgame = GameObject.Find ("Start").GetComponent<PointerController> ();

	}

	void Update(){

		if (endgame.getPressed()) {

			SceneManager.LoadScene ("main_menu");
		}

	}
}
