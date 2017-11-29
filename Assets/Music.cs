using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	public static Music current;

	void Awake() {
		if (current) {
			Destroy (gameObject);
			return;
		}

		current = this;

		DontDestroyOnLoad(transform.gameObject);
	}
}