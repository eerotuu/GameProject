using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
	public int money;

	public Wallet ()
	{
		this.money = 0;
	}

	public void AddMoney (int ammount)
	{
		this.money += ammount;
	}

	public void UseMoney (int ammount)
	{
		this.money -= ammount;
	}

	public int GetSaldo ()
	{
		return this.money;
	}
}


