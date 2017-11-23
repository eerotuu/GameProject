using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int hp;
	public Wallet wallet;





	// Use this for initialization
	void Start ()
	{
		
		hp = 100;

		
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.name.Equals ("Door")) {
			Debug.Log ("osu");
			SceneManager.LoadScene ("main_scene");
		}
	}
		
}
