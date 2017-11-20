using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

	Wallet wallet;

	void Start ()
	{
		wallet = GameObject.Find ("Wallet").GetComponent<Wallet> ();
	}

	void OnTriggerEnter2D (Collider2D Player)
	{
		wallet.AddMoney (10);
		Destroy (gameObject);
	}
}
