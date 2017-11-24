using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	private PointerController button;

	void Start()
	{
		button = GameObject.Find ("StartGame").GetComponent<PointerController> ();


	}

	void Update(){
		if (button.getPressed()) {
			SceneManager.LoadScene ("main_scene");
		}

	}
}
