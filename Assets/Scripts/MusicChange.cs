using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Music change.
/// </summary>
public class MusicChange : MonoBehaviour
{
	public AudioClip audio;

	// Use this for initialization
	void Start ()
	{
		Music.current.gameObject.GetComponent<AudioSource> ().clip = audio;
		Music.current.gameObject.GetComponent<AudioSource> ().Play ();
	}
	

}
