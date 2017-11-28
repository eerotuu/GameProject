using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour {


	private PointerController back;

	void Start()
	{

		back = GameObject.Find ("Back").GetComponent<PointerController> ();

	}

	void Update(){

		if (back.getPressed()) {

			SceneManager.LoadScene ("main_menu");
		}

	}
}
