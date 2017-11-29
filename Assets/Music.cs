using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	public static Music current;

	void Awake() {
		if (current != null) Destroy (gameObject);
		current = this;

		DontDestroyOnLoad(transform.gameObject);
	}
}