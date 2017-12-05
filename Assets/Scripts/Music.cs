using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Music controller.
/// </summary>
public class Music : MonoBehaviour
{
	public static Music current;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake ()
	{
		if (current) {
			Destroy (gameObject);
			return;
		}

		current = this;

		DontDestroyOnLoad (transform.gameObject);
	}
}