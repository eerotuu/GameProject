using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player
{
	public int hp;
	public int bulkmeter;
	public Wallet wallet;
	public Inventory inventory;

	public Player ()
	{
		bulkmeter = 0;
		hp = 100;
		wallet = new Wallet ();
		inventory = new Inventory ();
	}

	public void AddBulk (int ammount)
	{
		bulkmeter += ammount;
	}

	public int GetBulk ()
	{
		return bulkmeter;
	}
		
}
