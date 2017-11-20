using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	Player player;
	Text MoneyText;
	Wallet wallet;
	Inventory invetory;

	// Use this for initialization
	void Start ()
	{
		MoneyText = (Text)GameObject.Find ("MoneyText").GetComponent<Text> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
		wallet = GameObject.Find ("Wallet").GetComponent<Wallet> ();
		invetory = GameObject.Find ("Wallet").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoneyText.text = "Money: " + wallet.GetSaldo ();

	}
}
