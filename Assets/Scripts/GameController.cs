using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Player player;
	Text MoneyText;
	Text BulkText;
	Wallet wallet;
	Inventory invetory;

	// Use this for initialization
	void Start ()
	{
		
		//DontDestroyOnLoad (this);
		MoneyText = (Text)GameObject.Find ("MoneyText").GetComponent<Text> ();
		BulkText = (Text)GameObject.Find ("BulkText").GetComponent<Text> ();
		player = new Player ();
		SceneManager.LoadScene ("hospital", LoadSceneMode.Additive);
		//SceneManager.LoadScene ("city", LoadSceneMode.Additive);
		//GameObject.Find ("Player").transform.position = new Vector2 (82f, -88f);


		//invetory = GameObject.Find ("inven").GetComponent<Inventory> ();
	}
		
	// Update is called once per frame
	void Update ()
	{
		MoneyText.text = "Money: " + player.wallet.GetSaldo ();
		BulkText.text = "kcal: " + player.GetBulk ();

	}


}
