using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player class.
/// </summary>
public class Player
{
	//Players HP.
	public int hp;
	//Kcal meter.
	public int bulkmeter;
	//Players wallet.
	public Wallet wallet;
	//Players inventory.
	public Inventory inventory;

	/// <summary>
	/// Initializes a new instance of the <see cref="Player"/> class.
	/// </summary>
	public Player ()
	{
		bulkmeter = 0;
		hp = 100;
		wallet = new Wallet ();
		inventory = new Inventory ();
	}

	/// <summary>
	/// Adds gained calories.
	/// </summary>
	/// <param name="ammount">Ammount.</param>
	public void AddBulk (int ammount)
	{
		bulkmeter += ammount;
	}

	/// <summary>
	/// Gets the current calories.
	/// </summary>
	/// <returns>The bulk.</returns>
	public int GetBulk ()
	{
		return bulkmeter;
	}
		
}
