using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Players Wallet.
/// </summary>
public class Wallet
{
	public int money;

	/// <summary>
	/// Initializes a new instance of the <see cref="Wallet"/> class.
	/// </summary>
	public Wallet ()
	{
		this.money = 0;
	}

	/// <summary>
	/// Adds the money in wallet.
	/// </summary>
	/// <param name="ammount">Ammount.</param>
	public void AddMoney (int ammount)
	{
		this.money += ammount;
	}

	/// <summary>
	/// Uses the money in wallet.
	/// </summary>
	/// <param name="ammount">Ammount.</param>
	public void UseMoney (int ammount)
	{
		this.money -= ammount;
	}

	/// <summary>
	/// Gets the saldo.
	/// </summary>
	/// <returns>The saldo.</returns>
	public int GetSaldo ()
	{
		return this.money;
	}
}


