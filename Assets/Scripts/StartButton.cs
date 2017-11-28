using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	private PointerController button;
	private PointerController credits;

	void Start()
	{
		button = GameObject.Find ("StartGame").GetComponent<PointerController> ();
		credits = GameObject.Find ("Credits").GetComponent<PointerController> ();


	}

	void Update(){
		if (button.getPressed()) {
			SceneManager.LoadScene ("intro");
		}

		if (credits.getPressed()) {
			
			SceneManager.LoadScene ("Credits");
		}

	}
}
