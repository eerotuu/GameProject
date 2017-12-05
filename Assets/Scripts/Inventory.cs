using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for players inventory.
/// </summary>
public class Inventory
{
	//list for inventory.
	private List<GameItem> inventory;
	//saves the current item.
	private GameItem currentItem;
	//Image for first inventoryslot.
	Image itemSlot0Image;
	//Image for first inventoryslot.
	Image itemSlot1Image;


	/// <summary>
	/// Initializes a new instance of the <see cref="Inventory"/> class.
	/// </summary>
	public Inventory ()
	{
		inventory = new List<GameItem> ();
	}

	/// <summary>
	/// Adds the item.
	/// </summary>
	/// <param name="name">Name.</param>
	public void AddItem (GameItem name)
	{
		if (inventory.Count < 2) {
			inventory.Add (name);
			Debug.Log ("Added " + name.GetGameItem () + " into inventory");
		}
		itemSlot0Image = GameObject.Find ("ItemImage0").GetComponent<Image> ();
		itemSlot1Image = GameObject.Find ("ItemImage1").GetComponent<Image> ();
	}

	/// <summary>
	/// Removes the item.
	/// </summary>
	/// <param name="name">Name.</param>
	public void RemoveItem (GameItem name)
	{
		inventory.Remove (name);
	}

	/// <summary>
	/// Lists the inventory.
	/// </summary>
	public void ListInventory ()
	{
		if (inventory.Count > 0) {
			
			itemSlot0Image.sprite = inventory [0].GetItemImage ();
			itemSlot0Image.enabled = true;

			if (inventory.Count > 1) {
				
				itemSlot1Image.sprite = inventory [1].GetItemImage ();
				itemSlot1Image.enabled = true;
			} else {
				itemSlot1Image.enabled = false;
			}
		} else {
			itemSlot0Image.enabled = false;
			itemSlot1Image.enabled = false;
		}

	}

}


