using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {


	private PointerController startgame;

	void Start()
	{

		startgame = GameObject.Find ("Start").GetComponent<PointerController> ();

	}

	void Update(){

		if (startgame.getPressed()) {

			SceneManager.LoadScene ("main_scene");
		}

	}
}
