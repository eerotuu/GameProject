using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameItem
{
	private string itemName;

	public GameItem (string name)
	{
		this.itemName = name;
	}

	public string GetGameItem ()
	{
		return this.itemName;
	}
}


