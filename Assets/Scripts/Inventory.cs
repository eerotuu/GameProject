using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{
	private List<GameItem> inventory;

	Image itemSlot0Image;
	GameObject itemSlot0;


	public Inventory ()
	{
		inventory = new List<GameItem> ();
	}

	public void AddItem (GameItem name)
	{
		inventory.Add (name);
	}

	public void RemoveItem (GameItem name)
	{
		inventory.Remove (name);
	}

	public void ListInventory (GameItem name)
	{
		itemSlot0Image = GameObject.Find ("ItemImage").GetComponent<Image> ();
		if (name.GetGameItem ().Equals ("medicine")) {
			itemSlot0Image.sprite = Resources.Load <Sprite> ("green_checkmark");
			itemSlot0Image.enabled = !itemSlot0Image.enabled;
		}

	}

	public void ListInventory ()
	{
		itemSlot0Image.enabled = !itemSlot0Image.enabled;
	}

}


