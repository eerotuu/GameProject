using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private List<GameItem> inventory;

	public Inventory ()
	{
		inventory = new List<GameItem> ();
	}

	public void AddItem (string name)
	{
		inventory.Add (new GameItem (name));
	}
}


