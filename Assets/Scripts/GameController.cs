using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Player player;
	Text MoneyText;
	Wallet wallet;
	Inventory invetory;

	// Use this for initialization
	void Start ()
	{
		
		//DontDestroyOnLoad (this);
		MoneyText = (Text)GameObject.Find ("MoneyText").GetComponent<Text> ();
		player = new Player ();
		SceneManager.LoadScene ("hospital", LoadSceneMode.Additive);


		//invetory = GameObject.Find ("inven").GetComponent<Inventory> ();
	}

	/*void Awake ()
	{
		DontDestroyOnLoad (this);
		MoneyText = (Text)GameObject.Find ("MoneyText").GetComponent<Text> ();
		//player = GameObject.Find ("Player").GetComponent<Player> ();
		//wallet = GameObject.Find ("Wallet").GetComponent<Wallet> ();
		//invetory = GameObject.Find ("Wallet").GetComponent<Inventory> ();
	}*/
	// Update is called once per frame
	void Update ()
	{
		MoneyText.text = "Money: " + player.wallet.GetSaldo ();

	}


}
